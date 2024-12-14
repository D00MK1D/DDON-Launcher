using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDO_Launcher
{
    public partial class FormServerSettings : Form
    {
        public FormServerSettings()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
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
            File.WriteAllLines("LaunchConfig.cfg", lines);

            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormServerSettings_Load(object sender, EventArgs e)
        {
            if (File.Exists("LaunchConfig.cfg"))
            {
                string[] lines = File.ReadAllLines("LaunchConfig.cfg");

                if (lines.Length > 0)
                    textGameServerIp.Text = lines[0];
                if (lines.Length > 1)
                    textGameServerPort.Text = lines[1];
                if (lines.Length > 2)
                    textDownloadServerIP.Text = lines[2];
                if (lines.Length > 3)
                    textDownloadServerPort.Text = lines[3];
            }
        }


    }
}
