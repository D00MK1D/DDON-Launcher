namespace DDO_Launcher
{
    partial class FormServerSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormServerSettings));
            label4 = new Label();
            label3 = new Label();
            labelDownLoadServerIP = new Label();
            labelGameServerIP = new Label();
            textDownloadServerPort = new TextBox();
            textGameServerPort = new TextBox();
            textDownloadServerIP = new TextBox();
            textGameServerIp = new TextBox();
            buttonSave = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Calibri", 11.25F, FontStyle.Bold);
            label4.Location = new Point(229, 60);
            label4.Name = "label4";
            label4.Size = new Size(38, 18);
            label4.TabIndex = 8;
            label4.Text = "Port:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Calibri", 11.25F, FontStyle.Bold);
            label3.Location = new Point(229, 31);
            label3.Name = "label3";
            label3.Size = new Size(38, 18);
            label3.TabIndex = 9;
            label3.Text = "Port:";
            // 
            // labelDownLoadServerIP
            // 
            labelDownLoadServerIP.AutoSize = true;
            labelDownLoadServerIP.BackColor = Color.Transparent;
            labelDownLoadServerIP.Font = new Font("Calibri", 11.25F, FontStyle.Bold);
            labelDownLoadServerIP.Location = new Point(44, 60);
            labelDownLoadServerIP.Name = "labelDownLoadServerIP";
            labelDownLoadServerIP.Size = new Size(42, 18);
            labelDownLoadServerIP.TabIndex = 10;
            labelDownLoadServerIP.Text = "DL IP:";
            // 
            // labelGameServerIP
            // 
            labelGameServerIP.AutoSize = true;
            labelGameServerIP.BackColor = Color.Transparent;
            labelGameServerIP.Font = new Font("Calibri", 11.25F, FontStyle.Bold);
            labelGameServerIP.Location = new Point(23, 31);
            labelGameServerIP.Name = "labelGameServerIP";
            labelGameServerIP.Size = new Size(64, 18);
            labelGameServerIP.TabIndex = 11;
            labelGameServerIP.Text = "Lobby IP:";
            // 
            // textDownloadServerPort
            // 
            textDownloadServerPort.BackColor = SystemColors.InactiveBorder;
            textDownloadServerPort.BorderStyle = BorderStyle.FixedSingle;
            textDownloadServerPort.Cursor = Cursors.IBeam;
            textDownloadServerPort.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            textDownloadServerPort.ForeColor = SystemColors.ActiveCaptionText;
            textDownloadServerPort.ImeMode = ImeMode.NoControl;
            textDownloadServerPort.Location = new Point(267, 60);
            textDownloadServerPort.MaxLength = 5;
            textDownloadServerPort.Name = "textDownloadServerPort";
            textDownloadServerPort.Size = new Size(69, 20);
            textDownloadServerPort.TabIndex = 4;
            // 
            // textGameServerPort
            // 
            textGameServerPort.BackColor = SystemColors.InactiveBorder;
            textGameServerPort.BorderStyle = BorderStyle.FixedSingle;
            textGameServerPort.Cursor = Cursors.IBeam;
            textGameServerPort.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            textGameServerPort.ForeColor = SystemColors.ActiveCaptionText;
            textGameServerPort.ImeMode = ImeMode.NoControl;
            textGameServerPort.Location = new Point(267, 31);
            textGameServerPort.MaxLength = 5;
            textGameServerPort.Name = "textGameServerPort";
            textGameServerPort.Size = new Size(69, 20);
            textGameServerPort.TabIndex = 2;
            // 
            // textDownloadServerIP
            // 
            textDownloadServerIP.BackColor = SystemColors.InactiveBorder;
            textDownloadServerIP.BorderStyle = BorderStyle.FixedSingle;
            textDownloadServerIP.Cursor = Cursors.IBeam;
            textDownloadServerIP.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            textDownloadServerIP.ForeColor = SystemColors.ActiveCaptionText;
            textDownloadServerIP.ImeMode = ImeMode.NoControl;
            textDownloadServerIP.Location = new Point(89, 60);
            textDownloadServerIP.MaxLength = 200;
            textDownloadServerIP.Name = "textDownloadServerIP";
            textDownloadServerIP.Size = new Size(122, 20);
            textDownloadServerIP.TabIndex = 3;
            // 
            // textGameServerIp
            // 
            textGameServerIp.BackColor = SystemColors.InactiveBorder;
            textGameServerIp.BorderStyle = BorderStyle.FixedSingle;
            textGameServerIp.Cursor = Cursors.IBeam;
            textGameServerIp.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            textGameServerIp.ForeColor = SystemColors.ActiveCaptionText;
            textGameServerIp.ImeMode = ImeMode.NoControl;
            textGameServerIp.Location = new Point(89, 31);
            textGameServerIp.MaxLength = 200;
            textGameServerIp.Name = "textGameServerIp";
            textGameServerIp.Size = new Size(122, 20);
            textGameServerIp.TabIndex = 1;
            // 
            // buttonSave
            // 
            buttonSave.Font = new Font("Calibri", 10F, FontStyle.Bold);
            buttonSave.Location = new Point(110, 114);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(63, 25);
            buttonSave.TabIndex = 5;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Font = new Font("Calibri", 10F, FontStyle.Bold);
            buttonCancel.Location = new Point(195, 114);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(63, 25);
            buttonCancel.TabIndex = 6;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // FormServerSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(367, 157);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(labelDownLoadServerIP);
            Controls.Add(labelGameServerIP);
            Controls.Add(textDownloadServerPort);
            Controls.Add(textGameServerPort);
            Controls.Add(textDownloadServerIP);
            Controls.Add(textGameServerIp);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormServerSettings";
            Text = "Server Connection Settings";
            Load += FormServerSettings_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private Label label3;
        public Label labelDownLoadServerIP;
        public Label labelGameServerIP;
        public TextBox textDownloadServerPort;
        public TextBox textGameServerPort;
        public TextBox textDownloadServerIP;
        public TextBox textGameServerIp;
        private Button buttonSave;
        private Button buttonCancel;
    }
}