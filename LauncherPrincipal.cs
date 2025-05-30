using System.Text;
using System.Text.Json;
using System.Net.Sockets;
using System.Diagnostics;
using Arrowgene.Ddon.Client;
using System.ComponentModel;
using static Arrowgene.Ddon.Client.GmdActions;
using System.Drawing.Imaging;
using System.Net.NetworkInformation;
using DDO_Launcher.Mods;
using Arrowgene.Ddon.Shared.Csv;


namespace DDO_Launcher
{
    public partial class launcherPrincipal : Form
    {
        private readonly ServerManager ServerManager;
        private readonly ModManager ModManager;

        private bool dragging = false;
        private Point startPoint;

        private System.Windows.Forms.Timer fadeTimer = new System.Windows.Forms.Timer();
        private float opacity = 0f;
        private System.Drawing.Image currentImage;
        private bool fadingIn = true;


        public launcherPrincipal(ServerManager serverManager, ModManager modManager)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            ServerManager = serverManager;
            ModManager = modManager;

            UpdateServerList();
            CustomBackground();
        }

        private void OpenSettings()
        {
            FormServerSettings f2 = new FormServerSettings(ServerManager);
            f2.FormClosed += (s, args) => UpdateServerList();
            f2.ShowDialog();
        }

        private void UpdateServerList()
        {
            serverComboBox.BeginUpdate();
            serverComboBox.Items.Clear();
            foreach (var server in ServerManager.Servers)
            {
                int addedItemIndex = serverComboBox.Items.Add(server.Key);
                if (serverComboBox.SelectedIndex == -1 && server.Key == ServerManager.SelectedServer)
                {
                    serverComboBox.SelectedIndex = addedItemIndex;
                }
            }
            serverComboBox.EndUpdate();

            if (serverComboBox.SelectedIndex == -1)
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

            if (Properties.Settings.Default.firstInstalledTranslation == false)
            {
                buttonTranslationPatch_Click(null, EventArgs.Empty);
            }

            if (ServerManager.SelectedServer == null)
            {
                OpenSettings();
            }
        }

        private void dragPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                startPoint = e.Location;
            }
        }

        private void dragPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point currentPoint = e.Location;
                this.Location = new Point(this.Location.X + (currentPoint.X - startPoint.X),
                                          this.Location.Y + (currentPoint.Y - startPoint.Y));
            }
        }

        private void dragPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private async void CustomBackground()
        {
            System.Drawing.Image img;
            try
            {
                FadeOutBackground();
                
                //Will search for "/launcher/bg.png" to apply on launcher

                byte[] bg = await new HttpClient().GetByteArrayAsync("http://" + ServerManager.Servers[ServerManager.SelectedServer].DLIP + ":" + ServerManager.Servers[ServerManager.SelectedServer].DLPort + "/launcher/bg.png");
                img = System.Drawing.Image.FromStream(new MemoryStream(bg));

                FadeInBackground(img);
                await Task.Delay(600);
                this.BackgroundImage = img;
                FadeOutBackground();

            }

            catch
            {

                FadeInBackground(Properties.Resources.Background);
                await Task.Delay(600);
                this.BackgroundImage = Properties.Resources.Background;
                FadeOutBackground();
            }
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

        private void Operation(string Action)
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

            if ((Action != "create" && Action != "login") || textAccount.Text == "" || textPassword.Text == "")
            {
                MessageBox.Show(
                    "Account or Password must not be empty!",
                    "Dragon's Dogma Online",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            string responseBody = string.Empty;
            try
            {

                using (TcpClient client = new TcpClient())
                {
                    var path = "/api/account";
                    var requestData = new
                    {
                        Action = Action,
                        Account = textAccount.Text,
                        Password = textPassword.Text,
                        Email = ""
                    };

                    string jsonData = JsonSerializer.Serialize(requestData);
                    string request = $"POST {path} HTTP/1.1\r\n";
                    request += $"Host: {ServerManager.Servers[ServerManager.SelectedServer].DLIP}:{ServerManager.Servers[ServerManager.SelectedServer].DLPort}\r\n";
                    request += "Content-Type: application/json\r\n";
                    request += $"Content-Length: {jsonData.Length}\r\n";
                    request += "Connection: close\r\n";
                    request += "\r\n";
                    request += jsonData;

                    client.ReceiveTimeout = 5000;
                    client.SendTimeout = 5000;
                    client.Connect(ServerManager.Servers[ServerManager.SelectedServer].DLIP, ServerManager.Servers[ServerManager.SelectedServer].DLPort);

                    var utf8Encoding = new UTF8Encoding(false);

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
                        responseBody = response.Substring(bodyStartIndex);
                    }
                }
            }
            catch (SocketException ex)
            {
                MessageBox.Show(
                    "Failed to connect to the server. Please verify the launcher's connection settings.",
                    "Dragon's Dogma Online",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var token = string.Empty;
            try
            {
                ServerResponse serverResponse = JsonSerializer.Deserialize<ServerResponse>(responseBody);
                if (serverResponse.Message == "Login Success")
                {
                    // Login
                    token = serverResponse.Token;
                }
                else if (serverResponse.Error == null)
                {
                    // Register
                    MessageBox.Show(
                        serverResponse.Message,
                        "Dragon's Dogma Online",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    MessageBox.Show(
                        serverResponse.Error,
                        "Dragon's Dogma Online",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }
            catch (JsonException e)
            {
                MessageBox.Show(
                    "Invalid response from server",
                    "Dragon's Dogma Online",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            try
            {
                /* Try to show the admin prompt to launch DDOn
                ProcessStartInfo pStartInfo = new ProcessStartInfo
                {
                    FileName = "ddo.exe",
                    Arguments = (" addr=" +
                                    ServerManager.Servers[ServerManager.SelectedServer].LobbyIP +
                                    " port=" +
                                    ServerManager.Servers[ServerManager.SelectedServer].LPort +
                                    " token=" +
                                    token +
                                    " DL=http://" +
                                    ServerManager.Servers[ServerManager.SelectedServer].DLIP +
                                    ":" +
                                    ServerManager.Servers[ServerManager.SelectedServer].DLPort +
                                    "/win/ LVer=03.04.003.20181115.0 RVer=3040008"),

                    //Verb = "runas",
                    //UseShellExecute = true
                };
                Process.Start(pStartInfo);*/

                Process.Start("ddo.exe",
                              " addr=" +
                              ServerManager.Servers[ServerManager.SelectedServer].LobbyIP +
                              " port=" +
                              ServerManager.Servers[ServerManager.SelectedServer].LPort +
                              " token=" +
                              token +
                              " DL=http://" +
                              ServerManager.Servers[ServerManager.SelectedServer].DLIP +
                              ":" +
                              ServerManager.Servers[ServerManager.SelectedServer].DLPort +
                              "/win/ LVer=03.04.003.20181115.0 RVer=3040008");

                this.Close();
            }
            catch (Win32Exception ex)
            {
                MessageBox.Show(
                    "DDO.exe not found! Make sure the launcher is located in the game folder and you're running the launcher as Admin.",
                    "Dragon's Dogma Online",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
        }

        private void rememberCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.rememberMe = rememberCheckBox.Checked;
        }

        private void serverComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServerManager.SelectServer(serverComboBox.Text);
            ServerManager.SaveServers();
            CustomBackground();
            PingIndicator(ServerManager.Servers[ServerManager.SelectedServer].DLIP);
        }

        private void serverComboBox_DropDown(object sender, EventArgs e)
        {
            UpdateServerList();
        }

        private async void buttonInstallMod_Click(object sender, EventArgs e)
        {
            var waitForm = new ProgressWindow();
            try
            {
                OpenFileDialog selectModFileDialog = new OpenFileDialog();
                selectModFileDialog.InitialDirectory = ".";
                selectModFileDialog.Filter = "DDOn Mod Zip Files (*.zip)|*.zip";
                selectModFileDialog.FilterIndex = 0;
                selectModFileDialog.RestoreDirectory = true;
                if (selectModFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                waitForm.Show();
                waitForm.ProgressBar.Style = ProgressBarStyle.Continuous;
                waitForm.ProgressBar.Minimum = 0;
                waitForm.ProgressBar.Step = 1;

                string name = "", author = "";
                await ModManager.InstallMod(selectModFileDialog.FileName, new Progress<ModInstallProgress>((progressReport) =>
                {
                    name = progressReport.Name;
                    author = progressReport.Author;
                    waitForm.MessageLabel.Text = "Installing \"" + name + "\"\nAuthor:" + author;
                    waitForm.ProgressBar.Maximum = progressReport.TotalActionCount;
                    waitForm.ProgressBar.Value = progressReport.ProcessedTotalActions;
                    waitForm.ProgressBar.PerformStep();
                }));
                waitForm.Close();
                Properties.Settings.Default.Save();
                MessageBox.Show("Successfully installed " + name + " (Author " + author + ")", "Mod installed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                waitForm.Close();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonTranslationPatch_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            var waitForm = new ProgressWindow();
            try
            {
                // Show confirmation before proceeding
                string[] labels = { "Translated texts", "Original texts" };
                string[] languages = { "English", "Japanese" };
                int selectedLanguageIndex = ShowDropdownDialog("Select language", "Translation Patch", labels);
                if (selectedLanguageIndex == -1)
                {
                    return;
                }

                // Choose patch source
                var result = ShowInputDialog("Install translation patch?", "Translation Patch", out string url, Properties.Settings.Default.translationPatchUrl);
                Properties.Settings.Default.translationPatchUrl = url;
                if (result != DialogResult.OK)
                {
                    return;
                }

                // Check if there's a newer version of the translation patch
                waitForm.Show();
                waitForm.MessageLabel.Text = "Checking for translation patch updates...";
                var request = new HttpRequestMessage(HttpMethod.Head, Properties.Settings.Default.translationPatchUrl);
                request.Headers.Add("If-None-Match", Properties.Settings.Default.installedTranslationPatchETag);
                var response = await client.SendAsync(request);
                waitForm.Hide();                
                
                if (response.StatusCode == System.Net.HttpStatusCode.NotModified)
                {
                    var confirmation = MessageBox.Show("Translation patch is already up to date.\nDo you want to reinstall it?", "Translation Patch", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmation == DialogResult.No)
                    {
                        return;
                    }
                }

                // Download latest translation patch
                waitForm.Show();
                waitForm.MessageLabel.Text = "Downloading translation patch...";
                var patchDownload = await client.GetAsync(Properties.Settings.Default.translationPatchUrl);
                Properties.Settings.Default.installedTranslationPatchETag = patchDownload.Headers.ETag.ToString();
                Stream stream = await patchDownload.Content.ReadAsStreamAsync();

                GmdCsv gmdCsvReader = new GmdCsv();
                List<GmdCsv.Entry> gmdCsvEntries = gmdCsvReader.Read(stream);

                // Patch the client
                waitForm.MessageLabel.Text = "Patching client...";
                waitForm.ProgressBar.Style = ProgressBarStyle.Continuous;
                waitForm.ProgressBar.Minimum = 0;
                waitForm.ProgressBar.Step = 1;
                var progress = new Progress<PackProgressReport>(progressReport =>
                {
                    waitForm.ProgressBar.Maximum = progressReport.Total;
                    waitForm.ProgressBar.Value = progressReport.Current;
                    waitForm.ProgressBar.PerformStep();
                });
                await Task.Run(() => GmdActions.Pack(gmdCsvEntries, "nativePC/rom", languages[selectedLanguageIndex], progress));

                waitForm.Close();
                Properties.Settings.Default.firstInstalledTranslation = true;
                Properties.Settings.Default.Save();
                MessageBox.Show("Translation patch applied successfully", "Translation applied", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
            }
            catch (Exception ex)
            {
                waitForm.Close();
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static DialogResult ShowInputDialog(string message, string title, out string chosenUrl, string defaultUrl = "")
        {
            Form inputForm = new Form()
            {
                Width = 400,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = title,
                StartPosition = FormStartPosition.CenterScreen
            };

            Label messageLabel = new Label() { Left = 20, Top = 20, Text = message, Width = 340 };
            TextBox inputBox = new TextBox() { Left = 20, Top = 50, Width = 340 };
            Button okButton = new Button() { Text = "OK", Left = 220, Width = 100, Top = 100, DialogResult = DialogResult.OK };
            Button cancelButton = new Button() { Text = "Cancel", Left = 100, Width = 100, Top = 100, DialogResult = DialogResult.Cancel };

            okButton.Click += (sender, e) => { inputForm.Close(); };
            cancelButton.Click += (sender, e) => { inputForm.Close(); };

            inputForm.Controls.Add(messageLabel);
            inputForm.Controls.Add(inputBox);
            inputForm.Controls.Add(okButton);
            inputForm.Controls.Add(cancelButton);
            inputForm.AcceptButton = okButton;
            inputForm.CancelButton = cancelButton;

            inputBox.Text = defaultUrl;
            DialogResult dialogResult = inputForm.ShowDialog();
            chosenUrl = inputBox.Text;
            return dialogResult;
        }

        public static int ShowDropdownDialog(string message, string title, string[] options)
        {
            Form dropdownForm = new Form()
            {
                Width = 400,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = title,
                StartPosition = FormStartPosition.CenterScreen
            };

            Label messageLabel = new Label() { Left = 20, Top = 20, Text = message, Width = 340, AutoSize = false, Height = 40 };
            ComboBox optionsBox = new ComboBox() { Left = 20, Top = 60, Width = 340 };
            optionsBox.DropDownStyle = ComboBoxStyle.DropDownList;
            optionsBox.Items.AddRange(options);
            optionsBox.SelectedIndex = 0;
            Button okButton = new Button() { Text = "OK", Left = 220, Width = 100, Top = 100, DialogResult = DialogResult.OK };
            Button cancelButton = new Button() { Text = "Cancel", Left = 100, Width = 100, Top = 100, DialogResult = DialogResult.Cancel };

            okButton.Click += (sender, e) => { dropdownForm.Close(); };
            cancelButton.Click += (sender, e) => { dropdownForm.Close(); };

            dropdownForm.Controls.Add(messageLabel);
            dropdownForm.Controls.Add(optionsBox);
            dropdownForm.Controls.Add(okButton);
            dropdownForm.Controls.Add(cancelButton);
            dropdownForm.AcceptButton = okButton;
            dropdownForm.CancelButton = cancelButton;

            DialogResult dialogResult = dropdownForm.ShowDialog();
            return dialogResult == DialogResult.OK
                ? optionsBox.SelectedIndex
                : -1;
        }


        //---- Background fade (this shit is strange af)
        public void FadeInBackground(System.Drawing.Image img)
        {
            if (img == null) return;

            fadeTimer.Stop();
            currentImage = img;
            opacity = 0f;
            fadingIn = true;

            fadeTimer.Interval = 30;
            fadeTimer.Tick += FadeProgress;
            fadeTimer.Start();
        }

        public void FadeOutBackground()
        {
            if (currentImage == null) return;

            fadeTimer.Stop();
            opacity = 1f;
            fadingIn = false;

            fadeTimer.Interval = 30;
            fadeTimer.Tick += FadeProgress;
            fadeTimer.Start();
        }

        private void FadeProgress(object sender, EventArgs e)
        {
            if (fadingIn)
            {
                if (opacity < 1f)
                {
                    opacity += 0.05f;
                    this.Invalidate();
                }
                else
                {
                    fadeTimer.Tick -= FadeProgress;
                    fadeTimer.Stop();
                    opacity = 1f;
                    this.Invalidate();
                }
            }
            else
            {
                if (opacity > 0f)
                {
                    opacity -= 0.05f;
                    this.Invalidate();
                }
                else
                {
                    fadeTimer.Tick -= FadeProgress;
                    fadeTimer.Stop();
                    opacity = 0f;
                    currentImage = null;
                    this.Invalidate();
                }
            }
        }

        private void Background_Paint(object sender, PaintEventArgs e)
        {
            if (currentImage != null)
            {
                ColorMatrix matrix = new ColorMatrix { Matrix33 = opacity };
                ImageAttributes attributes = new();
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                e.Graphics.DrawImage(currentImage, dragPictureBox.ClientRectangle, 0, 0, currentImage.Width, currentImage.Height, GraphicsUnit.Pixel, attributes);
            }
        }
        //-- Background fade (this shit is strange af)

        private async void PingIndicator(string server)
        {
            int sum = 0;
            int avg = 0;
            Ping ping = new Ping();
            try
            {
                for (int i = 0; i < 3; i++)
                {
                    PingReply pong = await ping.SendPingAsync(server);
                    //IPStatus p = pong.Status; //Maybe useful sometime?...
                    
                    sum = (int)pong.RoundtripTime + sum;

                    await Task.Delay(500);
                }

                avg = sum / 4;

                if (avg < 90 && avg > 0)
                {
                    pingPictureBox.BackgroundImage = Properties.Resources.Ping3;
                }

                else if(avg >= 90 && avg <= 180)
                {
                    pingPictureBox.BackgroundImage = Properties.Resources.Ping2;
                }

                else if(avg > 180 && avg <= 270)
                {
                    pingPictureBox.BackgroundImage = Properties.Resources.Ping1;
                }

                else
                {
                    pingPictureBox.BackgroundImage = Properties.Resources.Ping0;
                }

            }
            catch
            {
                pingPictureBox.BackgroundImage = Properties.Resources.Ping0;
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