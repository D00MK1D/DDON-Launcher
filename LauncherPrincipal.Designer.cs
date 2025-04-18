﻿namespace DDO_Launcher
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
            textAccount = new TextBox();
            textPassword = new TextBox();
            rememberCheckBox = new CheckBox();
            buttonRegister = new Button();
            serverComboBox = new ComboBox();
<<<<<<< Updated upstream
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
=======
            buttonTranslationPatch = new Button();
            buttonInstallMod = new Button();
            dragPictureBox = new PictureBox();
            labelPassword = new Label();
            labelAccountID = new Label();
            ((System.ComponentModel.ISupportInitialize)dragPictureBox).BeginInit();
>>>>>>> Stashed changes
            SuspendLayout();
            this.AutoScaleMode = AutoScaleMode.None;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = Properties.Resources.Background;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(874, 427);
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
            buttonLogin.Font = new Font("Calibri", 16F, FontStyle.Bold, GraphicsUnit.Pixel);
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
<<<<<<< Updated upstream
            buttonConfig.BackgroundImage = Properties.Resources.emojione__gear;
=======
            buttonConfig.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonConfig.BackgroundImage = Properties.Resources.BtnConfig;
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
            // labelAccountID
            // 
            labelAccountID.AutoSize = true;
            labelAccountID.BackColor = Color.Transparent;
            labelAccountID.Font = new Font("Calibri", 15F, FontStyle.Bold, GraphicsUnit.Pixel);
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
            labelPassword.Font = new Font("Calibri", 15F, FontStyle.Bold, GraphicsUnit.Pixel);
            labelPassword.Location = new Point(50, 222);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(71, 18);
            labelPassword.TabIndex = 0;
            labelPassword.Text = "Password:";
            // 
=======
>>>>>>> Stashed changes
            // textAccount
            // 
            textAccount.BackColor = SystemColors.InactiveBorder;
            textAccount.BorderStyle = BorderStyle.FixedSingle;
            textAccount.Cursor = Cursors.IBeam;
            textAccount.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Pixel);
            textAccount.ForeColor = SystemColors.ActiveCaptionText;
            textAccount.ImeMode = ImeMode.NoControl;
<<<<<<< Updated upstream
            textAccount.Location = new Point(53, 187);
=======
            textAccount.Location = new Point(53, 154);
>>>>>>> Stashed changes
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
            textPassword.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Pixel);
            textPassword.ForeColor = SystemColors.ActiveCaptionText;
            textPassword.ImeMode = ImeMode.NoControl;
<<<<<<< Updated upstream
            textPassword.Location = new Point(53, 242);
=======
            textPassword.Location = new Point(53, 228);
>>>>>>> Stashed changes
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
            rememberCheckBox.Font = new Font("Calibri", 15F, FontStyle.Bold, GraphicsUnit.Pixel);
            rememberCheckBox.Location = new Point(90, 273);
            rememberCheckBox.Name = "rememberCheckBox";
            rememberCheckBox.Size = new Size(25, 13);
            rememberCheckBox.TabIndex = 3;
            rememberCheckBox.UseVisualStyleBackColor = true;
            rememberCheckBox.CheckedChanged += rememberCheckBox_CheckedChanged;
            // 
            // buttonRegister
            // 
            buttonRegister.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonRegister.BackColor = Color.Transparent;
            buttonRegister.Font = new Font("Calibri", 16F, FontStyle.Bold, GraphicsUnit.Pixel);
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
            serverComboBox.Font = new Font("Calibri", 15F, FontStyle.Bold, GraphicsUnit.Pixel);
            serverComboBox.FormattingEnabled = true;
            serverComboBox.Location = new Point(46, 389);
            serverComboBox.Name = "serverComboBox";
            serverComboBox.Size = new Size(121, 26);
            serverComboBox.TabIndex = 7;
            serverComboBox.DropDown += serverComboBox_DropDown;
            serverComboBox.SelectedIndexChanged += serverComboBox_SelectedIndexChanged;
            // 
<<<<<<< Updated upstream
=======
            // buttonTranslationPatch
            // 
            buttonTranslationPatch.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonTranslationPatch.BackgroundImage = Properties.Resources.BtnTranslation;
            buttonTranslationPatch.BackgroundImageLayout = ImageLayout.Zoom;
            buttonTranslationPatch.Location = new Point(242, 388);
            buttonTranslationPatch.Name = "buttonTranslationPatch";
            buttonTranslationPatch.Size = new Size(28, 28);
            buttonTranslationPatch.TabIndex = 9;
            buttonTranslationPatch.UseVisualStyleBackColor = true;
            buttonTranslationPatch.Click += buttonTranslationPatch_Click;
            // 
            // buttonInstallMod
            // 
            buttonInstallMod.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonInstallMod.BackgroundImage = Properties.Resources.BtnInstallMod;
            buttonInstallMod.BackgroundImageLayout = ImageLayout.Zoom;
            buttonInstallMod.Location = new Point(211, 388);
            buttonInstallMod.Name = "buttonInstallMod";
            buttonInstallMod.Size = new Size(28, 28);
            buttonInstallMod.TabIndex = 8;
            buttonInstallMod.UseVisualStyleBackColor = true;
            buttonInstallMod.Click += buttonInstallMod_Click;
            // 
            // dragPictureBox
            // 
            dragPictureBox.BackColor = Color.Transparent;
            dragPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            dragPictureBox.ErrorImage = null;
            dragPictureBox.InitialImage = null;
            dragPictureBox.Location = new Point(0, 0);
            dragPictureBox.Name = "dragPictureBox";
            dragPictureBox.Size = new Size(874, 427);
            dragPictureBox.TabIndex = 10;
            dragPictureBox.TabStop = false;
            dragPictureBox.MouseDown += dragPictureBox_MouseDown;
            dragPictureBox.MouseMove += dragPictureBox_MouseMove;
            dragPictureBox.MouseUp += dragPictureBox_MouseUp;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.BackColor = Color.Transparent;
            labelPassword.Font = new Font("Calibri", 15F, FontStyle.Bold, GraphicsUnit.Pixel);
            labelPassword.Location = new Point(50, 213);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(71, 18);
            labelPassword.TabIndex = 0;
            labelPassword.Text = "Password:";
            labelPassword.Visible = false;
            // 
            // labelAccountID
            // 
            labelAccountID.AutoSize = true;
            labelAccountID.BackColor = Color.Transparent;
            labelAccountID.Font = new Font("Calibri", 15F, FontStyle.Bold, GraphicsUnit.Pixel);
            labelAccountID.Location = new Point(50, 156);
            labelAccountID.Name = "labelAccountID";
            labelAccountID.Size = new Size(62, 18);
            labelAccountID.TabIndex = 0;
            labelAccountID.Text = "Account:";
            labelAccountID.Visible = false;
            // 
>>>>>>> Stashed changes
            // launcherPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
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
            DoubleBuffered = true;
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
        private TextBox textAccount;
        private TextBox textPassword;
        private CheckBox rememberCheckBox;
        private Button buttonRegister;
        private ComboBox serverComboBox;
<<<<<<< Updated upstream
=======
        private Button buttonTranslationPatch;
        private Button buttonInstallMod;
        private PictureBox dragPictureBox;
        private Label labelPassword;
        private Label labelAccountID;
>>>>>>> Stashed changes
    }
}
