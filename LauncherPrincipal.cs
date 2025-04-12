using System.Text;
using System.Text.Json;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Diagnostics;
using IniParser.Model;
using IniParser;
using static DDO_Launcher.launcherPrincipal;
using Arrowgene.Ddon.Client;
using System.ComponentModel;
using static Arrowgene.Ddon.Client.GmdActions;
using System.Security.Policy;
using System.IO.Compression;
using System.IO;
using System.Reflection.Metadata;
using System.Xml.Linq;
using Arrowgene.Ddon.Shared.Csv;
using Arrowgene.Ddon.Shared;

namespace DDO_Launcher
{
    public partial class launcherPrincipal : Form
    {
        private readonly ServerManager ServerManager;

        public launcherPrincipal(ServerManager serverManager)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            ServerManager = serverManager;

            UpdateServerList();
        }

        private void OpenSettings()
        {
            FormServerSettings f2 = new FormServerSettings(ServerManager);
            f2.FormClosed += (s, args) => UpdateServerList();
            f2.ShowDialog();
        }

        private void UpdateServerList()
        {
            int oldSelectionIndex = serverComboBox.SelectedIndex;

            serverComboBox.BeginUpdate();
            serverComboBox.Items.Clear();
            foreach (var server in ServerManager.Servers)
            {
                int addedItemIndex = serverComboBox.Items.Add(server.Key);
                if (serverComboBox.SelectedIndex == -1 && server.Key == ServerManager.SelectedServer)
                {
                    serverComboBox.Select(addedItemIndex, 1);
                }
            }
            serverComboBox.EndUpdate();

            serverComboBox.SelectedIndex = oldSelectionIndex;
            if (serverComboBox.SelectedIndex == -1 && serverComboBox.Items.Count > 0)
            {
                serverComboBox.SelectedIndex = 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.rememberMe)
            {
                textAccount.Text = Properties.Settings.Default.accountText;
                textPassword.Text = Properties.Settings.Default.passwordText;
                rememberCheckBox.Checked = true;
            }
            else
            {
                rememberCheckBox.Checked = false;
            }

            if (ServerManager.SelectedServer == null)
            {
                OpenSettings();
            }
        }

        [DllImport("user32.dll")]
        static extern IntPtr Setparent(IntPtr hwc, IntPtr hwp);


        private bool dragging = false;
        private Point startPoint;


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                startPoint = e.Location;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point currentPoint = e.Location;
                this.Location = new Point(this.Location.X + (currentPoint.X - startPoint.X),
                                          this.Location.Y + (currentPoint.Y - startPoint.Y));
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }


        public class ServerResponse
        {
            public string Error { get; set; }
            public string Message { get; set; }
            public string Token { get; set; }
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Operation("login");
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            Operation("create");
        }

        private void buttonConfig_Click(object sender, EventArgs e)
        {
            OpenSettings();
        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void Operation(string Action)
        {
            if (rememberCheckBox.Checked)
            {
                Properties.Settings.Default.accountText = textAccount.Text;
                Properties.Settings.Default.passwordText = textPassword.Text;
            }
            else
            {
                Properties.Settings.Default.accountText = string.Empty;
                Properties.Settings.Default.passwordText = string.Empty;
            }
            Properties.Settings.Default.Save();

            if (ServerManager.SelectedServer == null)
            {
                MessageBox.Show(
                    "Please select a server",
                    "Dragon's Dogma Online",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            var requestData = new
            {
                Action = Action,
                Account = textAccount.Text,
                Password = textPassword.Text,
                Email = ""
            };

            var path = "/api/account";

            if ((Action == "create" || Action == "login") && (textAccount.Text != "" && textPassword.Text != ""))
            {
                string jsonData = JsonSerializer.Serialize(requestData);

                string request = $"POST {path} HTTP/1.1\r\n";
                request += $"Host: {ServerManager.Servers[ServerManager.SelectedServer].DLIP}:{ServerManager.Servers[ServerManager.SelectedServer].DLPort}\r\n";
                request += "Content-Type: application/json\r\n";
                request += $"Content-Length: {jsonData.Length}\r\n";
                request += "Connection: close\r\n";
                request += "\r\n";
                request += jsonData;

                var utf8Encoding = new UTF8Encoding(false);

                using (TcpClient client = new TcpClient())
                {
                    client.ReceiveTimeout = 5000;
                    client.SendTimeout = 5000;

                    client.Connect(ServerManager.Servers[ServerManager.SelectedServer].DLIP, ServerManager.Servers[ServerManager.SelectedServer].DLPort);

                    using (NetworkStream stream = client.GetStream())

                    using (StreamWriter writer = new StreamWriter(stream, utf8Encoding))

                    using (StreamReader reader = new StreamReader(stream, utf8Encoding))

                    {
                        writer.Write(request);
                        writer.Flush();

                        StringBuilder sb = new StringBuilder();
                        string line;

                        stream.ReadTimeout = 5000;

                        while ((line = reader.ReadLine()) != null)
                        {
                            sb.AppendLine(line);
                        }

                        string response = sb.ToString();

                        var bodyStartIndex = response.IndexOf("\r\n\r\n") + 4;
                        var responseBody = response.Substring(bodyStartIndex);

                        ServerResponse serverResponse = JsonSerializer.Deserialize<ServerResponse>(responseBody);


                        if (serverResponse.Message == "Login Success")
                        {
                            // Try to show the admin prompt to launch DDOn
                            ProcessStartInfo pStartInfo = new ProcessStartInfo
                            {
                                FileName = "ddo.exe",

                                Arguments = (" addr=" +
                                             ServerManager.Servers[ServerManager.SelectedServer].LobbyIP +
                                             " port=" +
                                             ServerManager.Servers[ServerManager.SelectedServer].LPort +
                                             " token=" +
                                             serverResponse.Token +
                                             " DL=http://" +
                                             ServerManager.Servers[ServerManager.SelectedServer].DLIP +
                                             ":" +
                                             ServerManager.Servers[ServerManager.SelectedServer].DLPort +
                                             "/win/ LVer=03.04.003.20181115.0 RVer=3040008"),

                                Verb = "runas",
                                UseShellExecute = true
                            };

                            Process.Start(pStartInfo);

                            this.Close();
                        }
                        else if (serverResponse.Error == null)
                        {
                            MessageBox.Show(
                                serverResponse.Message,
                                "Dragon's Dogma Online",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(
                                serverResponse.Error,
                                "Dragon's Dogma Online",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }

                    //-------For a future implementation of "Select DDOn folder"--------
                    /*try
                    {
                    }
                    catch //(Exception ex)
                    {
                        if (ex is System.ComponentModel.Win32Exception winEx) 
                        {
                            MessageBox.Show(
                                "DDO.exe not found!",
                                "Dragon's Dogma Online",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show(
                                "Invalid response from server",
                                "Dragon's Dogma Online",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        
                    }*/


                }
            }
            else
            {
                MessageBox.Show(
                "Account or Password must not be empty!",
                "Dragon's Dogma Online",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }

            /* --------COMMENTED UNTIL E-MAIL USE TURN INTO A REAL THING------
            else
            {
                MessageBox.Show(
                    "Register is lacking the e-mail information",
                    "Dragon's Dogma Online",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            */
        }

        private void rememberCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.rememberMe = rememberCheckBox.Checked;
        }

        private void serverComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServerManager.SelectServer(serverComboBox.Text);
        }

        private void serverComboBox_DropDown(object sender, EventArgs e)
        {
            UpdateServerList();
        }

        private async void buttonTranslationPatch_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            var waitForm = new ProgressWindow();
            try
            {
                // Check if there's a newer version of the translation patch
                waitForm.Show();
                waitForm.MessageLabel.Text = "Checking for translation patch updates...";
                string upToDateWarning = "";
                var request = new HttpRequestMessage(HttpMethod.Head, "https://raw.githubusercontent.com/Sapphiratelaemara/DDON-translation/refs/heads/main/gmd.csv");
                request.Headers.Add("If-None-Match", Properties.Settings.Default.installedTranslationPatchETag);
                var response = await client.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.NotModified)
                {
                    upToDateWarning = "You already have the latest translation patch installed.";
                }
                waitForm.Hide();

                // Show confirmation before proceeding
                var result = MessageBox.Show("Install latest translation patch?\n" + upToDateWarning, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }

                // Download latest translation patch
                waitForm.Show();
                waitForm.MessageLabel.Text = "Downloading translation patch...";
                string gmdCsvFilePath = Path.GetTempFileName();
                using (var gmdCsvFile = new StreamWriter(gmdCsvFilePath))
                {
                    var patchDownload = await client.GetAsync("https://raw.githubusercontent.com/Sapphiratelaemara/DDON-translation/refs/heads/main/gmd.csv");
                    Properties.Settings.Default.installedTranslationPatchETag = patchDownload.Headers.ETag.ToString();
                    await (await patchDownload.Content.ReadAsStreamAsync()).CopyToAsync(gmdCsvFile.BaseStream);
                }

                // Patch the client
                waitForm.MessageLabel.Text = "Patching client...";
                waitForm.ProgressBar.Style = ProgressBarStyle.Continuous;
                waitForm.ProgressBar.Minimum = 1;
                waitForm.ProgressBar.Step = 1;
                var progress = new Progress<PackProgressReport>(progressReport =>
                {
                    waitForm.ProgressBar.Maximum = progressReport.Total;
                    waitForm.ProgressBar.Value = progressReport.Current;
                    waitForm.ProgressBar.PerformStep();
                });
                await Task.Run(() => GmdActions.Pack(gmdCsvFilePath, "nativePC/rom", "English", progress));

                waitForm.Close();
                Properties.Settings.Default.Save();
                MessageBox.Show("Translation patch applied successfully", "Translation applied", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                waitForm.Close();
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

public class ProgressWindow : Form
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Label MessageLabel { get; private set; }


    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ProgressBar ProgressBar { get; private set; }

    public ProgressWindow()
    {
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.StartPosition = FormStartPosition.CenterScreen;
        this.ControlBox = false;
        this.Width = 300;
        this.Height = 150;

        MessageLabel = new Label
        {
            Text = "Please wait...",
            Dock = DockStyle.Fill,
            TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
            Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold)
        };
        this.Controls.Add(MessageLabel);

        ProgressBar = new ProgressBar
        {
            Dock = DockStyle.Bottom,
            Style = ProgressBarStyle.Marquee,
            Height = 20
        };
        this.Controls.Add(ProgressBar);

        this.BackColor = System.Drawing.Color.White;
    }
}
