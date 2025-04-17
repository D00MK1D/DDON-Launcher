using System.Text;
using System.Text.Json;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Diagnostics;
using Arrowgene.Ddon.Client;
using System.ComponentModel;
using static Arrowgene.Ddon.Client.GmdActions;
using System.IO.Compression;
using Arrowgene.Ddon.Client.Resource.Texture.Dds;
using Arrowgene.Ddon.Client.Resource.Texture.Tex;
using Arrowgene.Ddon.Client.Resource.Texture;
using Arrowgene.Buffers;

namespace DDO_Launcher
{
    public partial class launcherPrincipal : Form
    {
        private readonly ServerManager ServerManager;
        private bool dragging = false;
        private Point startPoint;

        public launcherPrincipal(ServerManager serverManager)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            ServerManager = serverManager;

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
            try
            {
                //Will search for "/launcher/bg.png" to apply on launcher
                string bg = "http://" + ServerManager.Servers[ServerManager.SelectedServer].DLIP + ":" + ServerManager.Servers[ServerManager.SelectedServer].DLPort + "/launcher/bg.png";
                this.BackgroundImage = System.Drawing.Image.FromStream(new System.IO.MemoryStream(new System.Net.WebClient().DownloadData(bg)));
            }
            catch
            {
                this.BackgroundImage = Properties.Resources.Background;
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
                    "DDO.exe not found! Make sure the launcher is located in the game folder",
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
            CustomBackground();
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

                string name, author;

                using (var selectedModFilePath = File.OpenRead(selectModFileDialog.FileName))
                using (var zip = new ZipArchive(selectedModFilePath, ZipArchiveMode.Read))
                {
                    int arcsCount;
                    JsonElement.ArrayEnumerator arcsEnumerator;
                    try
                    {
                        JsonDocument manifest;
                        var manifestFile = zip.Entries.Where(e => e.FullName == "manifest.json").Single();
                        using (var stream = manifestFile.Open())
                        {
                            manifest = JsonDocument.Parse(stream);
                        }

                        name = manifest.RootElement.GetProperty("name").GetString() ?? throw new Exception("\"name\" property is null");
                        author = manifest.RootElement.GetProperty("author").GetString() ?? throw new Exception("\"author\" property is null");
                        var arcs = manifest.RootElement.GetProperty("arcs");
                        arcsCount = arcs.GetArrayLength();
                        arcsEnumerator = arcs.EnumerateArray();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Couldn\'t find manifest.json in the mod archive.\n\n" +
                                            "Make sure the mod archive is a zip file that contains a valid manifest.json file with the \"name\", \"author\", and \"arcs\" list.\n\n" +
                                            "Error: " + ex.Message);
                    }

                    waitForm.Show();
                    waitForm.MessageLabel.Text = "Installing \"" + name + "\"\nAuthor:" + author;
                    waitForm.ProgressBar.Style = ProgressBarStyle.Continuous;
                    waitForm.ProgressBar.Minimum = 1;
                    waitForm.ProgressBar.Step = 1;
                    waitForm.ProgressBar.Maximum = arcsCount;
                    await Task.Run(() =>
                    {
                        foreach (var arc in arcsEnumerator)
                        {
                            string arcProperty = arc.GetProperty("arc").GetString() ?? throw new Exception("\"arc\" property is null");
                            var pathToArcFile = Path.Combine("nativePC/rom/", arcProperty);
                            ArcArchive archive = new ArcArchive();
                            archive.Open(pathToArcFile);

                            if (archive.MagicTag == null)
                            {
                                throw new Exception("Couldn\'t open " + arcProperty + "\n" +
                                                    "Make sure the path is relative to the rom folder\n" +
                                                    "(e.g. \"ui/gui_cmn.arc\" instead of \"nativePC/rom/ui/gui_cmn.arc\"))");
                            }

                            foreach (var action in arc.GetProperty("actions").EnumerateArray())
                            {
                                string actionProperty = action.GetProperty("action").GetString() ?? throw new Exception("\"action\" property is null");

                                var src = action.GetProperty("src").GetString();
                                ZipArchiveEntry srcZipEntry;
                                try
                                {
                                    srcZipEntry = zip.Entries.Where(e => e.FullName == src).Single();
                                }
                                catch (Exception ex)
                                {
                                    throw new Exception("Couldn\'t find " + src + " in the mod archive.\n\n" +
                                                        "Error: " + ex.Message);
                                }

                                var dst = action.GetProperty("dst").GetString();
                                ArcArchive.ArcFile dstArcFile;
                                try
                                {
                                    dstArcFile = archive.GetFile(ArcArchive.Search().ByArcPath(dst));
                                }
                                catch (Exception ex)
                                {
                                    throw new Exception("Couldn\'t find " + dst + " in the ARC " + arcProperty + ".\n" +
                                                        "Make sure the path separator is an escaped backward slash (\\\\) and that the path doesn\'t include the file\'s extension\n" +
                                                        "(e.g. \"ui\\\\00_font\\\\button_win_00_ID_HQ\" instead of \"ui/00_font/button_win_00_ID_HQ.tex\")\n\n" +
                                                        "Error: " + ex.Message);
                                }

                                switch (actionProperty)
                                {
                                    case "replace":
                                        dstArcFile.Data = new byte[srcZipEntry.Length];
                                        srcZipEntry.Open().ReadExactly(dstArcFile.Data);
                                        break;

                                    case "convert":
                                        var txt = action.GetProperty("txt").GetString();
                                        TexHeader originalTexHeader;
                                        try
                                        {
                                            var entry = zip.Entries.Where(e => e.FullName == txt).Single();
                                            var sr = new StreamReader(entry.Open(), Encoding.UTF8);
                                            string txtContents = sr.ReadToEnd();
                                            originalTexHeader = TexConvert.ReadTexHeaderDump(txtContents);
                                        }
                                        catch (Exception ex)
                                        {
                                            throw new Exception("Couldn\'t read the original TEX headers from " + txt + " in the mod archive.\n\n" +
                                                                "Error: " + ex.Message);
                                        }

                                        var data = new byte[srcZipEntry.Length];
                                        srcZipEntry.Open().ReadExactly(data);
                                        var ddsBuffer = new StreamBuffer(data);
                                        DdsTexture ddsTexture = new DdsTexture();
                                        ddsTexture.Open(ddsBuffer);
                                        TexTexture texTexture = TexConvert.ToTexTexture(ddsTexture, originalTexHeader);
                                        var texBuffer = new StreamBuffer();
                                        texTexture.Write(texBuffer);
                                        dstArcFile.Data = texBuffer.GetAllBytes();
                                        break;

                                    default:
                                        throw new Exception("Unrecognized action: " + actionProperty);
                                }
                            }

                            byte[] savedArc = archive.Save();
                            File.WriteAllBytes(pathToArcFile, savedArc);

                            waitForm.Invoke(() => waitForm.ProgressBar.PerformStep());
                        }
                    });
                }
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
                var result = ShowInputDialog("Install translation patch?", "Translation Patch", out string url, Properties.Settings.Default.translationPatchUrl);
                Properties.Settings.Default.translationPatchUrl = url;
                if (result != DialogResult.OK)
                {
                    return;
                }

                // Check if there's a newer version of the translation patch
                waitForm.Show();
                waitForm.MessageLabel.Text = "Checking for translation patch updates...";
                string upToDateWarning = "";
                var request = new HttpRequestMessage(HttpMethod.Head, Properties.Settings.Default.translationPatchUrl);
                request.Headers.Add("If-None-Match", Properties.Settings.Default.installedTranslationPatchETag);
                var response = await client.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.NotModified)
                {
                    upToDateWarning = "\nYou already have installed the latest translation patch.";
                }
                waitForm.Hide();

                // Select language
                string[] languages = { "English", "Japanese" };
                string? selectedLanguage = ShowDropdownDialog("Select language"+upToDateWarning, "Translation Patch", languages);
                if (selectedLanguage == null)
                {
                    return;
                }

                // Download latest translation patch
                waitForm.Show();
                waitForm.MessageLabel.Text = "Downloading translation patch...";
                string gmdCsvFilePath = Path.GetTempFileName();
                using (var gmdCsvFile = new StreamWriter(gmdCsvFilePath))
                {
                    var patchDownload = await client.GetAsync(Properties.Settings.Default.translationPatchUrl);
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
                await Task.Run(() => GmdActions.Pack(gmdCsvFilePath, "nativePC/rom", selectedLanguage, progress));

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

        public static DialogResult ShowInputDialog(string message, string title, out string input, string value = "")
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

            inputBox.Text = value;
            DialogResult dialogResult = inputForm.ShowDialog();
            input = inputBox.Text;
            return dialogResult;
        }
        
        public static string ShowDropdownDialog(string message, string title, string[] options)
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
            return dialogResult == DialogResult.OK ? optionsBox.SelectedItem?.ToString() : null;
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