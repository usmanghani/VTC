namespace VTC
{
	partial class StreamingForm
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
			this.components = new System.ComponentModel.Container();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.sbGeneralStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.sbPortText = new System.Windows.Forms.ToolStripStatusLabel();
			this.sbStreamStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.txtServer = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.txtChannelTitle = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtLog = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnLogin = new System.Windows.Forms.Button();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.lstUsers = new System.Windows.Forms.ListView();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.statusStrip1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbGeneralStatus,
            this.sbPortText,
            this.sbStreamStatus});
			this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
			this.statusStrip1.Location = new System.Drawing.Point(0, 297);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(603, 28);
			this.statusStrip1.TabIndex = 4;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// sbGeneralStatus
			// 
			this.sbGeneralStatus.Name = "sbGeneralStatus";
			this.sbGeneralStatus.Spring = true;
			this.sbGeneralStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// sbPortText
			// 
			this.sbPortText.IsLink = true;
			this.sbPortText.Name = "sbPortText";
			this.sbPortText.Text = "Port:";
			this.sbPortText.Click += new System.EventHandler(this.sbPortText_Click);
			// 
			// sbStreamStatus
			// 
			this.sbStreamStatus.AutoSize = false;
			this.sbStreamStatus.Name = "sbStreamStatus";
			this.sbStreamStatus.Size = new System.Drawing.Size(50, 23);
			this.sbStreamStatus.Text = "Status";
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(603, 297);
			this.tabControl1.TabIndex = 5;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.button2);
			this.tabPage2.Controls.Add(this.button1);
			this.tabPage2.Location = new System.Drawing.Point(4, 26);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(595, 267);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Capturing";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(74, 88);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(248, 32);
			this.button2.TabIndex = 4;
			this.button2.Text = "Stop Streaming Engine";
			this.button2.Click += new System.EventHandler(this.button2_Click_1);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(74, 26);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(248, 34);
			this.button1.TabIndex = 3;
			this.button1.Text = "Start Streaming Engine";
			this.button1.Click += new System.EventHandler(this.button1_Click_1);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.txtServer);
			this.tabPage1.Controls.Add(this.button3);
			this.tabPage1.Controls.Add(this.txtChannelTitle);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.txtLog);
			this.tabPage1.Controls.Add(this.txtPassword);
			this.tabPage1.Controls.Add(this.txtUsername);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.btnLogin);
			this.tabPage1.Location = new System.Drawing.Point(4, 26);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(595, 267);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Streaming";
			// 
			// txtServer
			// 
			this.txtServer.Location = new System.Drawing.Point(271, 193);
			this.txtServer.Name = "txtServer";
			this.txtServer.Size = new System.Drawing.Size(207, 24);
			this.txtServer.TabIndex = 9;
			this.txtServer.Text = "doomsday";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(118, 187);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(137, 30);
			this.button3.TabIndex = 8;
			this.button3.Text = "Disconnect";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// txtChannelTitle
			// 
			this.txtChannelTitle.Location = new System.Drawing.Point(31, 103);
			this.txtChannelTitle.Name = "txtChannelTitle";
			this.txtChannelTitle.Size = new System.Drawing.Size(225, 24);
			this.txtChannelTitle.TabIndex = 7;
			this.txtChannelTitle.Text = "My Test Channel";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(32, 83);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(81, 17);
			this.label3.TabIndex = 6;
			this.label3.Text = "Channel Title";
			// 
			// txtLog
			// 
			this.txtLog.Location = new System.Drawing.Point(271, 25);
			this.txtLog.Multiline = true;
			this.txtLog.Name = "txtLog";
			this.txtLog.Size = new System.Drawing.Size(207, 155);
			this.txtLog.TabIndex = 5;
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(102, 51);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(154, 24);
			this.txtPassword.TabIndex = 2;
			this.txtPassword.Text = "nasim";
			// 
			// txtUsername
			// 
			this.txtUsername.Location = new System.Drawing.Point(102, 24);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(154, 24);
			this.txtUsername.TabIndex = 1;
			this.txtUsername.Text = "faisal";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(32, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(67, 17);
			this.label2.TabIndex = 4;
			this.label2.Text = "Password:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(29, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 17);
			this.label1.TabIndex = 3;
			this.label1.Text = "Username:";
			// 
			// btnLogin
			// 
			this.btnLogin.Location = new System.Drawing.Point(118, 153);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(138, 27);
			this.btnLogin.TabIndex = 0;
			this.btnLogin.Text = "Login && Host";
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.lstUsers);
			this.tabPage4.Location = new System.Drawing.Point(4, 26);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(595, 267);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Viewers";
			// 
			// lstUsers
			// 
			this.lstUsers.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.lstUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader9});
			this.lstUsers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstUsers.GridLines = true;
			this.lstUsers.HotTracking = true;
			this.lstUsers.HoverSelection = true;
			this.lstUsers.Location = new System.Drawing.Point(0, 0);
			this.lstUsers.Name = "lstUsers";
			this.lstUsers.Size = new System.Drawing.Size(595, 267);
			this.lstUsers.TabIndex = 2;
			this.lstUsers.View = System.Windows.Forms.View.Details;
			this.lstUsers.SelectedIndexChanged += new System.EventHandler(this.lstUsers_SelectedIndexChanged);
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Username";
			this.columnHeader5.Width = 81;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "IP Address";
			this.columnHeader9.Width = 82;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.textBox1);
			this.tabPage3.Location = new System.Drawing.Point(4, 26);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(595, 267);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Codecs";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(3, 3);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(413, 164);
			this.textBox1.TabIndex = 4;
			// 
			// StreamingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(603, 325);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.statusStrip1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "StreamingForm";
			this.Text = "Video Streaming";
			this.statusStrip1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage4.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel sbGeneralStatus;
		private System.Windows.Forms.ToolStripStatusLabel sbPortText;
		private System.Windows.Forms.ToolStripStatusLabel sbStreamStatus;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.TextBox txtUsername;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnLogin;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox txtLog;
		private System.Windows.Forms.TextBox txtChannelTitle;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ListView lstUsers;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox txtServer;
	}
}