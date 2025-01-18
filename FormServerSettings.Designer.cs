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
            label1 = new Label();
            nameTextBox = new TextBox();
            serverComboBox = new ComboBox();
            label2 = new Label();
            buttonAddServer = new Button();
            buttonRemoveServer = new Button();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Calibri", 15F, FontStyle.Bold, GraphicsUnit.Pixel);
            label4.Location = new Point(387, 236);
            label4.Name = "label4";
            label4.Size = new Size(38, 18);
            label4.TabIndex = 8;
            label4.Text = "Port:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Calibri", 15F, FontStyle.Bold, GraphicsUnit.Pixel);
            label3.Location = new Point(387, 178);
            label3.Name = "label3";
            label3.Size = new Size(38, 18);
            label3.TabIndex = 9;
            label3.Text = "Port:";
            // 
            // labelDownLoadServerIP
            // 
            labelDownLoadServerIP.AutoSize = true;
            labelDownLoadServerIP.BackColor = Color.Transparent;
            labelDownLoadServerIP.Font = new Font("Calibri", 15F, FontStyle.Bold, GraphicsUnit.Pixel);
            labelDownLoadServerIP.Location = new Point(75, 236);
            labelDownLoadServerIP.Name = "labelDownLoadServerIP";
            labelDownLoadServerIP.Size = new Size(42, 18);
            labelDownLoadServerIP.TabIndex = 10;
            labelDownLoadServerIP.Text = "DL IP:";
            // 
            // labelGameServerIP
            // 
            labelGameServerIP.AutoSize = true;
            labelGameServerIP.BackColor = Color.Transparent;
            labelGameServerIP.Font = new Font("Calibri", 15F, FontStyle.Bold, GraphicsUnit.Pixel);
            labelGameServerIP.Location = new Point(38, 178);
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
            textDownloadServerPort.Enabled = false;
            textDownloadServerPort.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Pixel);
            textDownloadServerPort.ForeColor = SystemColors.ActiveCaptionText;
            textDownloadServerPort.ImeMode = ImeMode.NoControl;
            textDownloadServerPort.Location = new Point(459, 236);
            textDownloadServerPort.Margin = new Padding(3, 6, 3, 6);
            textDownloadServerPort.MaxLength = 5;
            textDownloadServerPort.Name = "textDownloadServerPort";
            textDownloadServerPort.Size = new Size(119, 20);
            textDownloadServerPort.TabIndex = 8;
            textDownloadServerPort.TextChanged += textDownloadServerPort_TextChanged;
            // 
            // textGameServerPort
            // 
            textGameServerPort.BackColor = SystemColors.InactiveBorder;
            textGameServerPort.BorderStyle = BorderStyle.FixedSingle;
            textGameServerPort.Cursor = Cursors.IBeam;
            textGameServerPort.Enabled = false;
            textGameServerPort.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Pixel);
            textGameServerPort.ForeColor = SystemColors.ActiveCaptionText;
            textGameServerPort.ImeMode = ImeMode.NoControl;
            textGameServerPort.Location = new Point(459, 178);
            textGameServerPort.Margin = new Padding(3, 6, 3, 6);
            textGameServerPort.MaxLength = 5;
            textGameServerPort.Name = "textGameServerPort";
            textGameServerPort.Size = new Size(119, 20);
            textGameServerPort.TabIndex = 6;
            textGameServerPort.TextChanged += textGameServerPort_TextChanged;
            // 
            // textDownloadServerIP
            // 
            textDownloadServerIP.BackColor = SystemColors.InactiveBorder;
            textDownloadServerIP.BorderStyle = BorderStyle.FixedSingle;
            textDownloadServerIP.Cursor = Cursors.IBeam;
            textDownloadServerIP.Enabled = false;
            textDownloadServerIP.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Pixel);
            textDownloadServerIP.ForeColor = SystemColors.ActiveCaptionText;
            textDownloadServerIP.ImeMode = ImeMode.NoControl;
            textDownloadServerIP.Location = new Point(154, 236);
            textDownloadServerIP.Margin = new Padding(3, 6, 3, 6);
            textDownloadServerIP.MaxLength = 200;
            textDownloadServerIP.Name = "textDownloadServerIP";
            textDownloadServerIP.Size = new Size(208, 20);
            textDownloadServerIP.TabIndex = 7;
            textDownloadServerIP.TextChanged += textDownloadServerIP_TextChanged;
            // 
            // textGameServerIp
            // 
            textGameServerIp.BackColor = SystemColors.InactiveBorder;
            textGameServerIp.BorderStyle = BorderStyle.FixedSingle;
            textGameServerIp.Cursor = Cursors.IBeam;
            textGameServerIp.Enabled = false;
            textGameServerIp.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Pixel);
            textGameServerIp.ForeColor = SystemColors.ActiveCaptionText;
            textGameServerIp.ImeMode = ImeMode.NoControl;
            textGameServerIp.Location = new Point(154, 178);
            textGameServerIp.Margin = new Padding(3, 6, 3, 6);
            textGameServerIp.MaxLength = 200;
            textGameServerIp.Name = "textGameServerIp";
            textGameServerIp.Size = new Size(208, 20);
            textGameServerIp.TabIndex = 5;
            textGameServerIp.TextChanged += textGameServerIp_TextChanged;
            // 
            // buttonSave
            // 
            buttonSave.Font = new Font("Calibri", 16F, FontStyle.Bold, GraphicsUnit.Pixel);
            buttonSave.Location = new Point(190, 318);
            buttonSave.Margin = new Padding(3, 6, 3, 6);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(108, 50);
            buttonSave.TabIndex = 9;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Font = new Font("Calibri", 16F, FontStyle.Bold, GraphicsUnit.Pixel);
            buttonCancel.Location = new Point(334, 318);
            buttonCancel.Margin = new Padding(3, 6, 3, 6);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(108, 50);
            buttonCancel.TabIndex = 10;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Calibri", 15F, FontStyle.Bold, GraphicsUnit.Pixel);
            label1.Location = new Point(63, 124);
            label1.Name = "label1";
            label1.Size = new Size(49, 18);
            label1.TabIndex = 13;
            label1.Text = "Name:";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // nameTextBox
            // 
            nameTextBox.BackColor = SystemColors.InactiveBorder;
            nameTextBox.BorderStyle = BorderStyle.FixedSingle;
            nameTextBox.Cursor = Cursors.IBeam;
            nameTextBox.Enabled = false;
            nameTextBox.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Pixel);
            nameTextBox.ForeColor = SystemColors.ActiveCaptionText;
            nameTextBox.ImeMode = ImeMode.NoControl;
            nameTextBox.Location = new Point(154, 126);
            nameTextBox.Margin = new Padding(3, 6, 3, 6);
            nameTextBox.MaxLength = 200;
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(424, 20);
            nameTextBox.TabIndex = 4;
            nameTextBox.TextChanged += nameTextBox_TextChanged;
            // 
            // serverComboBox
            // 
            serverComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            serverComboBox.Font = new Font("Calibri", 15F, FontStyle.Bold, GraphicsUnit.Pixel);
            serverComboBox.FormattingEnabled = true;
            serverComboBox.Location = new Point(154, 42);
            serverComboBox.Margin = new Padding(3, 6, 3, 6);
            serverComboBox.Name = "serverComboBox";
            serverComboBox.Size = new Size(325, 26);
            serverComboBox.TabIndex = 1;
            serverComboBox.SelectedIndexChanged += serverComboBox_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Calibri", 15F, FontStyle.Bold, GraphicsUnit.Pixel);
            label2.Location = new Point(58, 48);
            label2.Name = "label2";
            label2.Size = new Size(52, 18);
            label2.TabIndex = 15;
            label2.Text = "Server:";
            label2.TextAlign = ContentAlignment.TopRight;
            // 
            // buttonAddServer
            // 
            buttonAddServer.Font = new Font("Calibri", 15F, FontStyle.Bold, GraphicsUnit.Pixel);
            buttonAddServer.ImageAlign = ContentAlignment.MiddleLeft;
            buttonAddServer.Location = new Point(538, 42);
            buttonAddServer.Margin = new Padding(3, 6, 3, 6);
            buttonAddServer.Name = "buttonAddServer";
            buttonAddServer.Size = new Size(41, 52);
            buttonAddServer.TabIndex = 3;
            buttonAddServer.Text = "+";
            buttonAddServer.UseVisualStyleBackColor = true;
            buttonAddServer.Click += buttonAddServer_Click;
            // 
            // buttonRemoveServer
            // 
            buttonRemoveServer.Enabled = false;
            buttonRemoveServer.Font = new Font("Calibri", 15F, FontStyle.Bold, GraphicsUnit.Pixel);
            buttonRemoveServer.Location = new Point(490, 42);
            buttonRemoveServer.Margin = new Padding(3, 6, 3, 6);
            buttonRemoveServer.Name = "buttonRemoveServer";
            buttonRemoveServer.Size = new Size(41, 52);
            buttonRemoveServer.TabIndex = 2;
            buttonRemoveServer.Text = "X";
            buttonRemoveServer.UseVisualStyleBackColor = true;
            buttonRemoveServer.Click += buttonRemoveServer_Click;
            // 
            // FormServerSettings
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(627, 392);
            Controls.Add(buttonRemoveServer);
            Controls.Add(buttonAddServer);
            Controls.Add(label2);
            Controls.Add(serverComboBox);
            Controls.Add(label1);
            Controls.Add(nameTextBox);
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
            Margin = new Padding(3, 6, 3, 6);
            Name = "FormServerSettings";
            Text = "Server Connection Settings";
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
        public Label label1;
        public TextBox nameTextBox;
        private ComboBox serverComboBox;
        public Label label2;
        private Button buttonAddServer;
        private Button buttonRemoveServer;
    }
}