using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DDO_Launcher;

namespace DDO_Launcher
{
    public partial class FormRegister : Form
    {
        private readonly ServerManager serverManager;

        FormServerSettings f = new FormServerSettings(serverManager);

        public FormRegister(ServerManager ServerManager)
        {
            InitializeComponent();

            this.textRegisterAccount.Text = textAccount.Text;
            this.textRegisterPassword.Text = "";
            this.textRegisterEmail.Text = "";

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.textRegisterAccount.Text = "";
            this.textRegisterPassword.Text = "";
            this.textRegisterEmail.Text = "";

            this.Close();
        }

    }
}
