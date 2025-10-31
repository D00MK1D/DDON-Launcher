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
            buttonConfig = new Button();
            buttonClose = new Button();
            buttonMinimize = new Button();
            labelAccountID = new Label();
            labelPassword = new Label();
            serverComboBox = new ComboBox();
            buttonTranslationPatch = new Button();
            buttonInstallMod = new Button();
            pingPictureBox = new PictureBox();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)pingPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            SuspendLayout();
            // 
            // buttonConfig
            // 
            buttonConfig.BackColor = Color.Transparent;
            buttonConfig.BackgroundImage = Properties.Resources.BtnConfig;
            buttonConfig.BackgroundImageLayout = ImageLayout.Stretch;
            buttonConfig.Location = new Point(19, 388);
            buttonConfig.Name = "buttonConfig";
            buttonConfig.Size = new Size(28, 28);
            buttonConfig.TabIndex = 6;
            buttonConfig.UseVisualStyleBackColor = false;
            buttonConfig.Click += buttonConfig_Click;
            // 
            // buttonClose
            // 
            buttonClose.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonClose.BackColor = Color.White;
            buttonClose.BackgroundImage = Properties.Resources.BtnClose;
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
            buttonMinimize.BackgroundImage = Properties.Resources.BtnMinimize;
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
            labelAccountID.Font = new Font("Calibri", 15F, FontStyle.Bold, GraphicsUnit.Pixel);
            labelAccountID.Location = new Point(50, 156);
            labelAccountID.Name = "labelAccountID";
            labelAccountID.Size = new Size(62, 18);
            labelAccountID.TabIndex = 0;
            labelAccountID.Text = "Account:";
            labelAccountID.Visible = false;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.BackColor = Color.Transparent;
            labelPassword.Font = new Font("Calibri", 15F, FontStyle.Bold, GraphicsUnit.Pixel);
            labelPassword.Location = new Point(50, 228);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(71, 18);
            labelPassword.TabIndex = 0;
            labelPassword.Text = "Password:";
            labelPassword.Visible = false;
            // 
            // serverComboBox
            // 
            serverComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            serverComboBox.Font = new Font("Calibri", 15F, FontStyle.Bold, GraphicsUnit.Pixel);
            serverComboBox.FormattingEnabled = true;
            serverComboBox.Location = new Point(53, 389);
            serverComboBox.Name = "serverComboBox";
            serverComboBox.Size = new Size(142, 26);
            serverComboBox.TabIndex = 7;
            serverComboBox.DropDown += serverComboBox_DropDown;
            serverComboBox.SelectedIndexChanged += serverComboBox_SelectedIndexChanged;
            // 
            // buttonTranslationPatch
            // 
            buttonTranslationPatch.BackColor = Color.Transparent;
            buttonTranslationPatch.BackgroundImage = Properties.Resources.BtnTranslation;
            buttonTranslationPatch.BackgroundImageLayout = ImageLayout.Zoom;
            buttonTranslationPatch.Location = new Point(242, 388);
            buttonTranslationPatch.Name = "buttonTranslationPatch";
            buttonTranslationPatch.Size = new Size(28, 28);
            buttonTranslationPatch.TabIndex = 9;
            buttonTranslationPatch.UseVisualStyleBackColor = false;
            buttonTranslationPatch.Click += buttonTranslationPatch_Click;
            // 
            // buttonInstallMod
            // 
            buttonInstallMod.BackColor = Color.Transparent;
            buttonInstallMod.BackgroundImage = Properties.Resources.BtnInstallMod;
            buttonInstallMod.BackgroundImageLayout = ImageLayout.Zoom;
            buttonInstallMod.Location = new Point(211, 388);
            buttonInstallMod.Name = "buttonInstallMod";
            buttonInstallMod.Size = new Size(28, 28);
            buttonInstallMod.TabIndex = 8;
            buttonInstallMod.UseVisualStyleBackColor = false;
            buttonInstallMod.Click += buttonInstallMod_Click;
            // 
            // pingPictureBox
            // 
            pingPictureBox.BackColor = Color.White;
            pingPictureBox.BackgroundImage = Properties.Resources.Ping0;
            pingPictureBox.BackgroundImageLayout = ImageLayout.Center;
            pingPictureBox.Enabled = false;
            pingPictureBox.ErrorImage = null;
            pingPictureBox.InitialImage = null;
            pingPictureBox.Location = new Point(842, 395);
            pingPictureBox.Name = "pingPictureBox";
            pingPictureBox.Size = new Size(32, 32);
            pingPictureBox.TabIndex = 11;
            pingPictureBox.TabStop = false;
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Location = new Point(0, 0);
            webView21.Name = "webView21";
            webView21.Size = new Size(874, 427);
            webView21.TabIndex = 12;
            webView21.ZoomFactor = 1D;
            // 
            // launcherPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(874, 427);
            ControlBox = false;
            Controls.Add(buttonInstallMod);
            Controls.Add(buttonTranslationPatch);
            Controls.Add(serverComboBox);
            Controls.Add(buttonMinimize);
            Controls.Add(buttonClose);
            Controls.Add(buttonConfig);
            Controls.Add(pingPictureBox);
            Controls.Add(labelPassword);
            Controls.Add(labelAccountID);
            Controls.Add(webView21);
            DoubleBuffered = true;
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "launcherPrincipal";
            Text = "Dragon's Dogma Online Launcher";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pingPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonConfig;
        private Button buttonClose;
        private Button buttonMinimize;
        private Label labelAccountID;
        private Label labelPassword;
        private ComboBox serverComboBox;
        private Button buttonTranslationPatch;
        private Button buttonInstallMod;
        private PictureBox pingPictureBox;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
    }
}
