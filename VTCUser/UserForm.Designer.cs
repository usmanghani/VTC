namespace VTC
{
	partial class frmUserLogin
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
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label3 = new System.Windows.Forms.Label();
			this.txtServer = new System.Windows.Forms.TextBox();
			this.txtLog = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.listView2 = new System.Windows.Forms.ListView();
			this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnLogin = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.sbGeneralStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.sbPortText = new System.Windows.Forms.ToolStripStatusLabel();
			this.sbStreamStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.lstChannels = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.tabPage1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.txtServer);
			this.tabPage1.Controls.Add(this.txtLog);
			this.tabPage1.Controls.Add(this.panel1);
			this.tabPage1.Controls.Add(this.txtPassword);
			this.tabPage1.Controls.Add(this.txtUsername);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.btnLogin);
			this.tabPage1.Location = new System.Drawing.Point(4, 26);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(749, 371);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Login";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(47, 83);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(49, 17);
			this.label3.TabIndex = 8;
			this.label3.Text = "Server:";
			// 
			// txtServer
			// 
			this.txtServer.Location = new System.Drawing.Point(102, 80);
			this.txtServer.Name = "txtServer";
			this.txtServer.Size = new System.Drawing.Size(154, 24);
			this.txtServer.TabIndex = 7;
			this.txtServer.Text = "doomsday";
			// 
			// txtLog
			// 
			this.txtLog.Location = new System.Drawing.Point(10, 157);
			this.txtLog.Multiline = true;
			this.txtLog.Name = "txtLog";
			this.txtLog.Size = new System.Drawing.Size(246, 183);
			this.txtLog.TabIndex = 6;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.listView2);
			this.panel1.Location = new System.Drawing.Point(276, 24);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(473, 341);
			this.panel1.TabIndex = 5;
			// 
			// listView2
			// 
			this.listView2.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14});
			this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView2.FullRowSelect = true;
			this.listView2.GridLines = true;
			this.listView2.HotTracking = true;
			this.listView2.HoverSelection = true;
			this.listView2.Location = new System.Drawing.Point(0, 0);
			this.listView2.Name = "listView2";
			this.listView2.Size = new System.Drawing.Size(473, 341);
			this.listView2.TabIndex = 1;
			this.listView2.View = System.Windows.Forms.View.Details;
			this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
			this.listView2.DoubleClick += new System.EventHandler(this.listView2_DoubleClick);
			// 
			// columnHeader11
			// 
			this.columnHeader11.Text = "ChannelID";
			this.columnHeader11.Width = 109;
			// 
			// columnHeader12
			// 
			this.columnHeader12.Text = "Channel Title";
			this.columnHeader12.Width = 139;
			// 
			// columnHeader13
			// 
			this.columnHeader13.Text = "Channel URL";
			this.columnHeader13.Width = 129;
			// 
			// columnHeader14
			// 
			this.columnHeader14.Text = "Owner";
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(102, 51);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(154, 24);
			this.txtPassword.TabIndex = 2;
			this.txtPassword.Text = "kid";
			// 
			// txtUsername
			// 
			this.txtUsername.Location = new System.Drawing.Point(102, 24);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(154, 24);
			this.txtUsername.TabIndex = 1;
			this.txtUsername.Text = "whiz";
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
			this.btnLogin.Location = new System.Drawing.Point(10, 117);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(246, 32);
			this.btnLogin.TabIndex = 0;
			this.btnLogin.Text = "Login and View Channels";
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(757, 401);
			this.tabControl1.TabIndex = 5;
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
			// 
			// sbStreamStatus
			// 
			this.sbStreamStatus.AutoSize = false;
			this.sbStreamStatus.Name = "sbStreamStatus";
			this.sbStreamStatus.Size = new System.Drawing.Size(50, 23);
			this.sbStreamStatus.Text = "Status";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbGeneralStatus,
            this.sbPortText,
            this.sbStreamStatus});
			this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
			this.statusStrip1.Location = new System.Drawing.Point(0, 401);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(757, 28);
			this.statusStrip1.TabIndex = 4;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// lstChannels
			// 
			this.lstChannels.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.lstChannels.GridLines = true;
			this.lstChannels.HotTracking = true;
			this.lstChannels.HoverSelection = true;
			this.lstChannels.Location = new System.Drawing.Point(0, 0);
			this.lstChannels.Name = "lstChannels";
			this.lstChannels.Size = new System.Drawing.Size(121, 97);
			this.lstChannels.TabIndex = 0;
			this.lstChannels.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.DisplayIndex = 0;
			this.columnHeader1.Text = "ChannelID";
			this.columnHeader1.Width = 109;
			// 
			// columnHeader4
			// 
			this.columnHeader4.DisplayIndex = 1;
			this.columnHeader4.Text = "Channel Title";
			this.columnHeader4.Width = 139;
			// 
			// columnHeader2
			// 
			this.columnHeader2.DisplayIndex = 2;
			this.columnHeader2.Text = "Channel URL";
			this.columnHeader2.Width = 129;
			// 
			// columnHeader3
			// 
			this.columnHeader3.DisplayIndex = 3;
			this.columnHeader3.Text = "Owner";
			// 
			// columnHeader10
			// 
			this.columnHeader10.DisplayIndex = 4;
			this.columnHeader10.Text = "Date/Time";
			// 
			// listView1
			// 
			this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.listView1.GridLines = true;
			this.listView1.HotTracking = true;
			this.listView1.HoverSelection = true;
			this.listView1.Location = new System.Drawing.Point(8, 8);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(121, 97);
			this.listView1.TabIndex = 0;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader5
			// 
			this.columnHeader5.DisplayIndex = 0;
			this.columnHeader5.Text = "ChannelID";
			this.columnHeader5.Width = 109;
			// 
			// columnHeader6
			// 
			this.columnHeader6.DisplayIndex = 1;
			this.columnHeader6.Text = "Channel Title";
			this.columnHeader6.Width = 139;
			// 
			// columnHeader7
			// 
			this.columnHeader7.DisplayIndex = 2;
			this.columnHeader7.Text = "Channel URL";
			this.columnHeader7.Width = 129;
			// 
			// columnHeader8
			// 
			this.columnHeader8.DisplayIndex = 3;
			this.columnHeader8.Text = "Owner";
			// 
			// columnHeader9
			// 
			this.columnHeader9.DisplayIndex = 4;
			this.columnHeader9.Text = "Date/Time";
			// 
			// frmUserLogin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(757, 429);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.statusStrip1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "frmUserLogin";
			this.Text = "VTC - View Channel";
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel sbGeneralStatus;
        private System.Windows.Forms.ToolStripStatusLabel sbPortText;
        private System.Windows.Forms.ToolStripStatusLabel sbStreamStatus;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ListView lstChannels;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.TextBox txtLog;
		private System.Windows.Forms.TextBox txtServer;
		private System.Windows.Forms.Label label3;

    }
}

