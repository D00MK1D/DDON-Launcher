namespace DDO_Launcher
{
    partial class FormRegister
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegister));
            textRegisterPassword = new TextBox();
            textRegisterAccount = new TextBox();
            textRegisterEmail = new TextBox();
            dragPicturebox = new PictureBox();
            buttonRegister = new Button();
            buttonCancel = new Button();
            buttonClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dragPicturebox).BeginInit();
            SuspendLayout();
            // 
            // textRegisterPassword
            // 
            textRegisterPassword.BackColor = SystemColors.InactiveBorder;
            textRegisterPassword.BorderStyle = BorderStyle.FixedSingle;
            textRegisterPassword.Cursor = Cursors.IBeam;
            textRegisterPassword.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Pixel);
            textRegisterPassword.ForeColor = SystemColors.ActiveCaptionText;
            textRegisterPassword.ImeMode = ImeMode.NoControl;
            textRegisterPassword.Location = new Point(104, 412);
            textRegisterPassword.MaxLength = 200;
            textRegisterPassword.Name = "textRegisterPassword";
            textRegisterPassword.PasswordChar = '•';
            textRegisterPassword.Size = new Size(190, 20);
            textRegisterPassword.TabIndex = 2;
            // 
            // textRegisterAccount
            // 
            textRegisterAccount.BackColor = SystemColors.InactiveBorder;
            textRegisterAccount.BorderStyle = BorderStyle.FixedSingle;
            textRegisterAccount.Cursor = Cursors.IBeam;
            textRegisterAccount.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Pixel);
            textRegisterAccount.ForeColor = SystemColors.ActiveCaptionText;
            textRegisterAccount.ImeMode = ImeMode.NoControl;
            textRegisterAccount.Location = new Point(104, 346);
            textRegisterAccount.MaxLength = 200;
            textRegisterAccount.Name = "textRegisterAccount";
            textRegisterAccount.Size = new Size(190, 20);
            textRegisterAccount.TabIndex = 1;
            // 
            // textRegisterEmail
            // 
            textRegisterEmail.BackColor = SystemColors.InactiveBorder;
            textRegisterEmail.BorderStyle = BorderStyle.FixedSingle;
            textRegisterEmail.Cursor = Cursors.IBeam;
            textRegisterEmail.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Pixel);
            textRegisterEmail.ForeColor = SystemColors.ActiveCaptionText;
            textRegisterEmail.ImeMode = ImeMode.NoControl;
            textRegisterEmail.Location = new Point(104, 476);
            textRegisterEmail.MaxLength = 50;
            textRegisterEmail.Name = "textRegisterEmail";
            textRegisterEmail.Size = new Size(190, 20);
            textRegisterEmail.TabIndex = 3;
            // 
            // dragPicturebox
            // 
            dragPicturebox.BackColor = Color.Transparent;
            dragPicturebox.ErrorImage = null;
            dragPicturebox.InitialImage = null;
            dragPicturebox.Location = new Point(0, 0);
            dragPicturebox.Name = "dragPicturebox";
            dragPicturebox.Size = new Size(400, 600);
            dragPicturebox.TabIndex = 6;
            dragPicturebox.TabStop = false;
            dragPicturebox.MouseDown += dragPictureBox_MouseDown;
            dragPicturebox.MouseMove += dragPictureBox_MouseMove;
            dragPicturebox.MouseUp += dragPictureBox_MouseUp;
            // 
            // buttonRegister
            // 
            buttonRegister.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonRegister.BackColor = Color.Transparent;
            buttonRegister.Font = new Font("Calibri", 16F, FontStyle.Bold, GraphicsUnit.Pixel);
            buttonRegister.Location = new Point(104, 526);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(81, 29);
            buttonRegister.TabIndex = 4;
            buttonRegister.Text = "Register";
            buttonRegister.UseVisualStyleBackColor = false;
            buttonRegister.Click += buttonRegister_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonCancel.BackColor = Color.Transparent;
            buttonCancel.Font = new Font("Calibri", 16F, FontStyle.Bold, GraphicsUnit.Pixel);
            buttonCancel.Location = new Point(213, 526);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(81, 29);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += buttonClose_Click;
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
            buttonClose.Location = new Point(372, 0);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(28, 28);
            buttonClose.TabIndex = 9;
            buttonClose.TabStop = false;
            buttonClose.UseVisualStyleBackColor = false;
            buttonClose.Click += buttonClose_Click;
            // 
            // FormRegister
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(400, 600);
            Controls.Add(buttonClose);
            Controls.Add(buttonCancel);
            Controls.Add(buttonRegister);
            Controls.Add(textRegisterEmail);
            Controls.Add(textRegisterPassword);
            Controls.Add(textRegisterAccount);
            Controls.Add(dragPicturebox);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormRegister";
            Text = "Dragon's dogma Online - Register Account";
            ((System.ComponentModel.ISupportInitialize)dragPicturebox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void dragPicturebox_MouseUp(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private TextBox textRegisterPassword;
        private TextBox textRegisterAccount;
        private TextBox textRegisterEmail;
        private PictureBox dragPicturebox;
        private Button buttonRegister;
        private Button buttonCancel;
        private Button buttonClose;
    }
}