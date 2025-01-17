namespace DDO_Launcher
{
    partial class launcherPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(launcherPrincipal));
            pictureBox1 = new PictureBox();
            buttonLogin = new Button();
            buttonConfig = new Button();
            buttonClose = new Button();
            buttonMinimize = new Button();
            labelAccountID = new Label();
            labelPassword = new Label();
            textAccount = new TextBox();
            textPassword = new TextBox();
            rememberCheckBox = new CheckBox();
            buttonRegister = new Button();
            serverComboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = Properties.Resources.Background;
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Location = new Point(2, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(872, 427);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            // 
            // buttonLogin
            // 
            buttonLogin.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonLogin.BackColor = Color.Transparent;
            buttonLogin.Font = new Font("Calibri", 12F, FontStyle.Bold);
            buttonLogin.Location = new Point(53, 314);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(81, 29);
            buttonLogin.TabIndex = 4;
            buttonLogin.Text = "LOGIN";
            buttonLogin.UseVisualStyleBackColor = false;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // buttonConfig
            // 
            buttonConfig.BackgroundImage = Properties.Resources.emojione__gear;
            buttonConfig.BackgroundImageLayout = ImageLayout.Center;
            buttonConfig.Location = new Point(12, 388);
            buttonConfig.Name = "buttonConfig";
            buttonConfig.Size = new Size(28, 28);
            buttonConfig.TabIndex = 6;
            buttonConfig.UseVisualStyleBackColor = true;
            buttonConfig.Click += buttonConfig_Click;
            // 
            // buttonClose
            // 
            buttonClose.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonClose.BackColor = Color.White;
            buttonClose.BackgroundImage = Properties.Resources.BtnClose2;
            buttonClose.BackgroundImageLayout = ImageLayout.Center;
            buttonClose.FlatAppearance.BorderSize = 0;
            buttonClose.FlatAppearance.MouseDownBackColor = Color.DarkRed;
            buttonClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(222, 0, 0);
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.ForeColor = Color.Transparent;
            buttonClose.Location = new Point(846, 0);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(28, 28);
            buttonClose.TabIndex = 0;
            buttonClose.TabStop = false;
            buttonClose.UseVisualStyleBackColor = false;
            buttonClose.Click += buttonClose_Click;
            // 
            // buttonMinimize
            // 
            buttonMinimize.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonMinimize.BackColor = Color.White;
            buttonMinimize.BackgroundImage = Properties.Resources.BtnMinimize2;
            buttonMinimize.BackgroundImageLayout = ImageLayout.Center;
            buttonMinimize.FlatAppearance.BorderSize = 0;
            buttonMinimize.FlatAppearance.MouseDownBackColor = Color.Gray;
            buttonMinimize.FlatAppearance.MouseOverBackColor = Color.LightGray;
            buttonMinimize.FlatStyle = FlatStyle.Flat;
            buttonMinimize.ForeColor = Color.Transparent;
            buttonMinimize.Location = new Point(818, 0);
            buttonMinimize.Name = "buttonMinimize";
            buttonMinimize.Size = new Size(28, 28);
            buttonMinimize.TabIndex = 0;
            buttonMinimize.TabStop = false;
            buttonMinimize.UseVisualStyleBackColor = false;
            buttonMinimize.Click += buttonMinimize_Click;
            // 
            // labelAccountID
            // 
            labelAccountID.AutoSize = true;
            labelAccountID.BackColor = Color.Transparent;
            labelAccountID.Font = new Font("Calibri", 11.25F, FontStyle.Bold);
            labelAccountID.Location = new Point(50, 168);
            labelAccountID.Name = "labelAccountID";
            labelAccountID.Size = new Size(62, 18);
            labelAccountID.TabIndex = 0;
            labelAccountID.Text = "Account:";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.BackColor = Color.Transparent;
            labelPassword.Font = new Font("Calibri", 11.25F, FontStyle.Bold);
            labelPassword.Location = new Point(50, 222);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(71, 18);
            labelPassword.TabIndex = 0;
            labelPassword.Text = "Password:";
            // 
            // textAccount
            // 
            textAccount.BackColor = SystemColors.InactiveBorder;
            textAccount.BorderStyle = BorderStyle.FixedSingle;
            textAccount.Cursor = Cursors.IBeam;
            textAccount.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            textAccount.ForeColor = SystemColors.ActiveCaptionText;
            textAccount.ImeMode = ImeMode.NoControl;
            textAccount.Location = new Point(53, 187);
            textAccount.MaxLength = 200;
            textAccount.Name = "textAccount";
            textAccount.Size = new Size(186, 20);
            textAccount.TabIndex = 1;
            // 
            // textPassword
            // 
            textPassword.BackColor = SystemColors.InactiveBorder;
            textPassword.BorderStyle = BorderStyle.FixedSingle;
            textPassword.Cursor = Cursors.IBeam;
            textPassword.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            textPassword.ForeColor = SystemColors.ActiveCaptionText;
            textPassword.ImeMode = ImeMode.NoControl;
            textPassword.Location = new Point(53, 242);
            textPassword.MaxLength = 200;
            textPassword.Name = "textPassword";
            textPassword.PasswordChar = '•';
            textPassword.Size = new Size(186, 20);
            textPassword.TabIndex = 2;
            // 
            // rememberCheckBox
            // 
            rememberCheckBox.AutoSize = true;
            rememberCheckBox.FlatAppearance.BorderSize = 0;
            rememberCheckBox.FlatStyle = FlatStyle.System;
            rememberCheckBox.Font = new Font("Calibri", 11.25F, FontStyle.Bold);
            rememberCheckBox.Location = new Point(89, 275);
            rememberCheckBox.Name = "rememberCheckBox";
            rememberCheckBox.Size = new Size(126, 23);
            rememberCheckBox.TabIndex = 3;
            rememberCheckBox.Text = "Remember Me";
            rememberCheckBox.UseVisualStyleBackColor = true;
            rememberCheckBox.CheckedChanged += rememberCheckBox_CheckedChanged;
            // 
            // buttonRegister
            // 
            buttonRegister.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonRegister.BackColor = Color.Transparent;
            buttonRegister.Font = new Font("Calibri", 12F, FontStyle.Bold);
            buttonRegister.Location = new Point(158, 314);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(81, 29);
            buttonRegister.TabIndex = 5;
            buttonRegister.Text = "REGISTER";
            buttonRegister.UseVisualStyleBackColor = false;
            buttonRegister.Click += buttonRegister_Click;
            // 
            // serverComboBox
            // 
            serverComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            serverComboBox.FormattingEnabled = true;
            serverComboBox.Location = new Point(46, 391);
            serverComboBox.Name = "serverComboBox";
            serverComboBox.Size = new Size(121, 23);
            serverComboBox.TabIndex = 7;
            serverComboBox.DropDown += serverComboBox_DropDown;
            serverComboBox.SelectedIndexChanged += serverComboBox_SelectedIndexChanged;
            // 
            // launcherPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Background;
            ClientSize = new Size(874, 427);
            ControlBox = false;
            Controls.Add(serverComboBox);
            Controls.Add(buttonRegister);
            Controls.Add(rememberCheckBox);
            Controls.Add(textPassword);
            Controls.Add(textAccount);
            Controls.Add(labelPassword);
            Controls.Add(labelAccountID);
            Controls.Add(buttonMinimize);
            Controls.Add(buttonClose);
            Controls.Add(buttonConfig);
            Controls.Add(buttonLogin);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "launcherPrincipal";
            Text = "Dragon's Dogma Online Launcher";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button buttonLogin;
        private Button buttonConfig;
        private Button buttonClose;
        private Button buttonMinimize;
        private Label labelAccountID;
        private Label labelPassword;
        private TextBox textAccount;
        private TextBox textPassword;
        private CheckBox rememberCheckBox;
        private Button buttonRegister;
        private ComboBox serverComboBox;
    }
}
