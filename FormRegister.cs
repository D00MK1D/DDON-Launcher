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
        private bool dragging = false;
        private Point startPoint;

        public FormRegister(string user, string pwd)
        {
            InitializeComponent();

            this.textRegisterAccount.Text = user;
            this.textRegisterPassword.Text = pwd;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.textRegisterAccount.Text = "";
            this.textRegisterPassword.Text = "";
            this.textRegisterEmail.Text = "";

            this.Close();
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

        private void buttonRegister_Click(object sender, EventArgs e)
        {

        }
    }
}
