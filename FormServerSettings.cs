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
        private readonly ServerManager ServerManager;

        public FormServerSettings(ServerManager serverManager)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            ServerManager = serverManager;

            if (ServerManager.Servers.Count == 0)
            {
                AddNewServer();
            }
            else
            {
                UpdateServerList();
            }
        }

        private void AddNewServer()
        {
            string newServerName;
            int i = 1;
            do
            {
                newServerName = "Server #" + (ServerManager.Servers.Count + i);
                i++;
            } while (ServerManager.Servers.ContainsKey(newServerName));

            ServerManager.AddServer(newServerName, new Server());
            UpdateServerList();
            serverComboBox.SelectedIndex = serverComboBox.Items.Count - 1;
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

            if (oldSelectionIndex == -1 && serverComboBox.Items.Count > 0)
            {
                serverComboBox.SelectedIndex = 0;
            }
            else if (oldSelectionIndex < serverComboBox.Items.Count)
            {
                serverComboBox.SelectedIndex = oldSelectionIndex;
            }

            UpdateServerFields();
        }

        private void UpdateServerFields()
        {
            if (!ServerManager.Servers.ContainsKey(serverComboBox.Text))
            {
                nameTextBox.Text = "";
                nameTextBox.Enabled = false;
                textGameServerIp.Text = "";
                textGameServerIp.Enabled = false;
                textGameServerPort.Text = "";
                textGameServerPort.Enabled = false;
                textDownloadServerIP.Text = "";
                textDownloadServerIP.Enabled = false;
                textDownloadServerPort.Text = "";
                textDownloadServerPort.Enabled = false;
                buttonRemoveServer.Enabled = false;
            }
            else
            {
                Server server = ServerManager.Servers[serverComboBox.Text];
                nameTextBox.Text = serverComboBox.Text;
                nameTextBox.Enabled = true;
                textGameServerIp.Text = server.LobbyIP;
                textGameServerIp.Enabled = true;
                textGameServerPort.Text = server.LPort.ToString();
                textGameServerPort.Enabled = true;
                textDownloadServerIP.Text = server.DLIP;
                textDownloadServerIP.Enabled = true;
                textDownloadServerPort.Text = server.DLPort.ToString();
                textDownloadServerPort.Enabled = true;
                buttonRemoveServer.Enabled = true;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Criar o arquivo e escrever as informações nas linhas
            ServerManager.SaveServers();

            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            // Restore original values from the file
            ServerManager.LoadServers();

            this.Close();
        }

        private void serverComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateServerFields();
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            string oldName = serverComboBox.Text;
            string newName = nameTextBox.Text;
            if(oldName != "" && newName != "")
            {
                serverComboBox.Text = newName;
                ServerManager.RenameServer(oldName, newName);
            }
            UpdateServerList();
        }

        private void textGameServerIp_TextChanged(object sender, EventArgs e)
        {
            Server server = ServerManager.Servers[serverComboBox.Text];
            server.LobbyIP = textGameServerIp.Text;
            UpdateServerFields();
        }

        private void textGameServerPort_TextChanged(object sender, EventArgs e)
        {
            Server server = ServerManager.Servers[serverComboBox.Text];
            if(ushort.TryParse(textGameServerPort.Text, out ushort port))
            {
                server.LPort = port;
            }
            UpdateServerFields();
        }

        private void textDownloadServerIP_TextChanged(object sender, EventArgs e)
        {
            Server server = ServerManager.Servers[serverComboBox.Text];
            server.DLIP = textDownloadServerIP.Text;
            UpdateServerFields();
        }

        private void textDownloadServerPort_TextChanged(object sender, EventArgs e)
        {
            Server server = ServerManager.Servers[serverComboBox.Text];
            if(ushort.TryParse(textDownloadServerPort.Text, out ushort port))
            {
                server.DLPort = port;
            }
            UpdateServerFields();
        }

        private void buttonRemoveServer_Click(object sender, EventArgs e)
        {
            ServerManager.RemoveServer(serverComboBox.Text);
            UpdateServerList();
        }

        private void buttonAddServer_Click(object sender, EventArgs e)
        {
            AddNewServer();
        }
    }
}
