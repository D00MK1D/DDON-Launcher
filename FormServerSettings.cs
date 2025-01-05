using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IniParser.Model;
using IniParser;
using IniParser.Parser;

namespace DDO_Launcher
{
    public partial class FormServerSettings : Form
    {
        private FileIniDataParser parser;

        public FormServerSettings()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.parser = new FileIniDataParser();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {


            // Se o arquivo não existir, criar o arquivo com os valores das TextBoxes
            string[] lines = new string[]
            {
                    textGameServerIp.Text,
                    textGameServerPort.Text,
                    textDownloadServerIP.Text,
                    textDownloadServerPort.Text
            };

            // Criar o arquivo e escrever as informações nas linhas
            IniData data = new IniData();
            data.Sections.AddSection("General");
            data["General"].AddKey("LobbyIP", textGameServerIp.Text);
            data["General"].AddKey("LPort", textGameServerPort.Text);
            data["General"].AddKey("DLIP", textDownloadServerIP.Text);
            data["General"].AddKey("DLPort", textDownloadServerPort.Text);
            this.parser.WriteFile("DDO_Launcher.ini", data);

            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormServerSettings_Load(object sender, EventArgs e)
        {
            if (File.Exists("DDO_Launcher.ini"))
            {
                IniData data = this.parser.ReadFile("DDO_Launcher.ini");
                if(data.Sections.ContainsSection("General"))
                {
                    textGameServerIp.Text = data["General"]["LobbyIP"];
                    textGameServerPort.Text = data["General"]["LPort"];
                    textDownloadServerIP.Text = data["General"]["DLIP"];
                    textDownloadServerPort.Text = data["General"]["DLPort"];
                }
            }
        }


    }
}
