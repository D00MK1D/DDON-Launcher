using System.Text;
using System.Text.Json;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Diagnostics;
using IniParser.Model;
using IniParser;
using static DDO_Launcher.launcherPrincipal;

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
        }

        private void serverComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServerManager.SelectServer(serverComboBox.Text);
        }

        private void serverComboBox_DropDown(object sender, EventArgs e)
        {
            UpdateServerList();
        }
    }
}
