namespace DDON_Launcher
{
    partial class FormDdonLauncher
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDdonLauncher));
            this.buttonLogin = new System.Windows.Forms.Button();
            this.textGameServerIp = new System.Windows.Forms.TextBox();
            this.textDownloadServerIP = new System.Windows.Forms.TextBox();
            this.textDownloadServerPort = new System.Windows.Forms.TextBox();
            this.textGameServerPort = new System.Windows.Forms.TextBox();
            this.labelGameServerIP = new System.Windows.Forms.Label();
            this.labelDownLoadServerIP = new System.Windows.Forms.Label();
            this.labelGameServerPort = new System.Windows.Forms.Label();
            this.labelDownLoadServerPort = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelAccountID = new System.Windows.Forms.Label();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.textAccount = new System.Windows.Forms.TextBox();
            this.labelRemember = new System.Windows.Forms.Label();
            this.checkRemember = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonLogin.BackColor = System.Drawing.Color.Transparent;
            this.buttonLogin.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.buttonLogin.Location = new System.Drawing.Point(95, 374);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(100, 29);
            this.buttonLogin.TabIndex = 5;
            this.buttonLogin.Text = "LOGIN";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // textGameServerIp
            // 
            this.textGameServerIp.AcceptsTab = true;
            this.textGameServerIp.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textGameServerIp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textGameServerIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.textGameServerIp.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textGameServerIp.Location = new System.Drawing.Point(77, 175);
            this.textGameServerIp.MaxLength = 15;
            this.textGameServerIp.Name = "textGameServerIp";
            this.textGameServerIp.Size = new System.Drawing.Size(100, 20);
            this.textGameServerIp.TabIndex = 1;
            // 
            // textDownloadServerIP
            // 
            this.textDownloadServerIP.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textDownloadServerIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textDownloadServerIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.textDownloadServerIP.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textDownloadServerIP.Location = new System.Drawing.Point(77, 204);
            this.textDownloadServerIP.MaxLength = 15;
            this.textDownloadServerIP.Name = "textDownloadServerIP";
            this.textDownloadServerIP.Size = new System.Drawing.Size(100, 20);
            this.textDownloadServerIP.TabIndex = 3;
            // 
            // textDownloadServerPort
            // 
            this.textDownloadServerPort.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textDownloadServerPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textDownloadServerPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.textDownloadServerPort.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textDownloadServerPort.Location = new System.Drawing.Point(223, 204);
            this.textDownloadServerPort.MaxLength = 5;
            this.textDownloadServerPort.Name = "textDownloadServerPort";
            this.textDownloadServerPort.Size = new System.Drawing.Size(46, 20);
            this.textDownloadServerPort.TabIndex = 4;
            // 
            // textGameServerPort
            // 
            this.textGameServerPort.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textGameServerPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textGameServerPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.textGameServerPort.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textGameServerPort.Location = new System.Drawing.Point(223, 175);
            this.textGameServerPort.MaxLength = 5;
            this.textGameServerPort.Name = "textGameServerPort";
            this.textGameServerPort.Size = new System.Drawing.Size(46, 20);
            this.textGameServerPort.TabIndex = 2;
            // 
            // labelGameServerIP
            // 
            this.labelGameServerIP.AutoSize = true;
            this.labelGameServerIP.BackColor = System.Drawing.Color.Transparent;
            this.labelGameServerIP.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelGameServerIP.Location = new System.Drawing.Point(9, 175);
            this.labelGameServerIP.Name = "labelGameServerIP";
            this.labelGameServerIP.Size = new System.Drawing.Size(67, 18);
            this.labelGameServerIP.TabIndex = 6;
            this.labelGameServerIP.Text = "Server IP:";
            // 
            // labelDownLoadServerIP
            // 
            this.labelDownLoadServerIP.AutoSize = true;
            this.labelDownLoadServerIP.BackColor = System.Drawing.Color.Transparent;
            this.labelDownLoadServerIP.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelDownLoadServerIP.Location = new System.Drawing.Point(33, 204);
            this.labelDownLoadServerIP.Name = "labelDownLoadServerIP";
            this.labelDownLoadServerIP.Size = new System.Drawing.Size(42, 18);
            this.labelDownLoadServerIP.TabIndex = 7;
            this.labelDownLoadServerIP.Text = "DL IP:";
            // 
            // labelGameServerPort
            // 
            this.labelGameServerPort.AutoSize = true;
            this.labelGameServerPort.BackColor = System.Drawing.Color.Transparent;
            this.labelGameServerPort.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelGameServerPort.Location = new System.Drawing.Point(185, 175);
            this.labelGameServerPort.Name = "labelGameServerPort";
            this.labelGameServerPort.Size = new System.Drawing.Size(38, 18);
            this.labelGameServerPort.TabIndex = 8;
            this.labelGameServerPort.Text = "Port:";
            // 
            // labelDownLoadServerPort
            // 
            this.labelDownLoadServerPort.AutoSize = true;
            this.labelDownLoadServerPort.BackColor = System.Drawing.Color.Transparent;
            this.labelDownLoadServerPort.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelDownLoadServerPort.Location = new System.Drawing.Point(185, 204);
            this.labelDownLoadServerPort.Name = "labelDownLoadServerPort";
            this.labelDownLoadServerPort.Size = new System.Drawing.Size(38, 18);
            this.labelDownLoadServerPort.TabIndex = 9;
            this.labelDownLoadServerPort.Text = "Port:";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.BackColor = System.Drawing.Color.Transparent;
            this.labelPassword.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelPassword.Location = new System.Drawing.Point(12, 306);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(71, 18);
            this.labelPassword.TabIndex = 13;
            this.labelPassword.Text = "Password:";
            // 
            // labelAccountID
            // 
            this.labelAccountID.AutoSize = true;
            this.labelAccountID.BackColor = System.Drawing.Color.Transparent;
            this.labelAccountID.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelAccountID.Location = new System.Drawing.Point(19, 277);
            this.labelAccountID.Name = "labelAccountID";
            this.labelAccountID.Size = new System.Drawing.Size(62, 18);
            this.labelAccountID.TabIndex = 12;
            this.labelAccountID.Text = "Account:";
            // 
            // textPassword
            // 
            this.textPassword.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.textPassword.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textPassword.Location = new System.Drawing.Point(83, 306);
            this.textPassword.MaxLength = 30;
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '•';
            this.textPassword.Size = new System.Drawing.Size(186, 20);
            this.textPassword.TabIndex = 11;
            // 
            // textAccount
            // 
            this.textAccount.AcceptsTab = true;
            this.textAccount.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.textAccount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textAccount.Location = new System.Drawing.Point(83, 277);
            this.textAccount.MaxLength = 30;
            this.textAccount.Name = "textAccount";
            this.textAccount.Size = new System.Drawing.Size(186, 20);
            this.textAccount.TabIndex = 10;
            // 
            // labelRemember
            // 
            this.labelRemember.AutoSize = true;
            this.labelRemember.BackColor = System.Drawing.Color.Transparent;
            this.labelRemember.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelRemember.Location = new System.Drawing.Point(118, 329);
            this.labelRemember.Name = "labelRemember";
            this.labelRemember.Size = new System.Drawing.Size(84, 18);
            this.labelRemember.TabIndex = 14;
            this.labelRemember.Text = "Remember?";
            // 
            // checkRemember
            // 
            this.checkRemember.AutoSize = true;
            this.checkRemember.BackColor = System.Drawing.Color.Transparent;
            this.checkRemember.Location = new System.Drawing.Point(207, 332);
            this.checkRemember.Name = "checkRemember";
            this.checkRemember.Size = new System.Drawing.Size(15, 14);
            this.checkRemember.TabIndex = 15;
            this.checkRemember.UseVisualStyleBackColor = false;
            // 
            // FormDdonLauncher
            // 
            this.AcceptButton = this.buttonLogin;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::DDON_Launcher.Properties.Resources.image1_4;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(876, 427);
            this.Controls.Add(this.checkRemember);
            this.Controls.Add(this.labelRemember);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelAccountID);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.textAccount);
            this.Controls.Add(this.labelDownLoadServerPort);
            this.Controls.Add(this.labelGameServerPort);
            this.Controls.Add(this.labelDownLoadServerIP);
            this.Controls.Add(this.labelGameServerIP);
            this.Controls.Add(this.textDownloadServerPort);
            this.Controls.Add(this.textGameServerPort);
            this.Controls.Add(this.textDownloadServerIP);
            this.Controls.Add(this.textGameServerIp);
            this.Controls.Add(this.buttonLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormDdonLauncher";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dragon\'s Dogma Online Launcher";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textGameServerIp;
        private System.Windows.Forms.TextBox textGameServerPort;
        private System.Windows.Forms.TextBox textDownloadServerIP;
        private System.Windows.Forms.TextBox textDownloadServerPort;
        private System.Windows.Forms.TextBox textAccount;
        private System.Windows.Forms.TextBox textPassword;

        private System.Windows.Forms.Label labelGameServerIP;
        private System.Windows.Forms.Label labelGameServerPort;
        private System.Windows.Forms.Label labelDownLoadServerIP;
        private System.Windows.Forms.Label labelDownLoadServerPort;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelAccountID;
        private System.Windows.Forms.Label labelRemember;

        private System.Windows.Forms.CheckBox checkRemember;

        private System.Windows.Forms.Button buttonLogin;
    }
}

