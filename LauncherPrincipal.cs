using System.Text;
using System.Text.Json;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Diagnostics;
using IniParser.Model;
using IniParser;

namespace DDO_Launcher
{
    public partial class launcherPrincipal : Form
    {
        public launcherPrincipal()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
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
            FormServerSettings f2 = new FormServerSettings();
            f2.ShowDialog();
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
            var requestData = new
            {
                Action = Action,
                Account = textAccount.Text,
                Password = textPassword.Text,
                Email = ""
            };

            try
            {
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile("DDO_Launcher.ini");

                var dlIp = data["General"]["DLIP"];
                var dlPort = data["General"]["DLPort"];
                var lobbyIp = data["General"]["LobbyIP"];
                var lobbyPort = data["General"]["LPort"];

                var path = "/api/account";

                if (Action == "create" || Action == "login" && (textAccount.Text != null && textPassword.Text != null) && (dlIp != null && dlPort != null))
                {

                    string jsonData = JsonSerializer.Serialize(requestData);

                    string request = $"POST {path} HTTP/1.1\r\n";
                    request += $"Host: {dlIp}:{dlPort}\r\n";
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
                        client.Connect(dlIp, int.Parse(dlPort));

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

                            if (serverResponse.Error == null)
                            {
                                MessageBox.Show(
                                    serverResponse.Message,
                                    "Dragon's Dogma Online",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                if (serverResponse.Message == "Login Success")
                                {
                                    Process.Start("ddo.exe",
                                        " addr=" +
                                        lobbyIp +
                                        " port=" +
                                        lobbyPort +
                                        " token=" +
                                        serverResponse.Token +
                                        " DL=http://" +
                                        dlIp +
                                        ":" +
                                        dlPort +
                                        "/win/ LVer=03.04.003.20181115.0 RVer=3040008");
                                   
                                    this.Close();
                                }
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
                    }
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
            catch (Exception ex)
            {

                if(ex.Message == "The input string '' was not in a correct format.")
                {
                    FormServerSettings f2 = new FormServerSettings();
                    f2.ShowDialog();
                }
                else
                {
                    MessageBox.Show(
                        ex.Message,    
                        "Error",    
                        MessageBoxButtons.OK,    
                        MessageBoxIcon.Error);
                }

            }
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
    }
}
