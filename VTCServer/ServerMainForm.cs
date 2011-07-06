using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VTCServer
{
	public partial class ServerMainForm : Form
	{
		private Server server;
		private UserBase user;

		public ServerMainForm()
		{
			InitializeComponent();
		}

		private void CleanUp()
		{
			if (server != null)
				server.StopServer();
			if (user != null)
				user.Disconnect();
			server = null;
			user = null;
		}

		private void ServerMainForm_Load(object sender, EventArgs e)
		{
			txtServerPort.Text = "4096";
			UpdateButtons();
			notifyIcon1.Visible = true;
		}

		private void UpdateLog (string str)
		{
			string s = DateTime.Now.ToShortTimeString();
			txtLog.Text += "[" + s + "] " + str + "\r\n";
		}

		private void UpdateLogThreaded(string str)
		{
			try
			{
				txtLog.Invoke(new LoggerCallback(UpdateLog), new object[] { str });
			}
			catch { }
		}

		private void StartServer()
		{
			LoggerCallback logger = new LoggerCallback (this.UpdateLogThreaded);
			try
			{
				server = new Server(int.Parse(txtServerPort.Text));
				user = new UserBase();
				//server.BindSigninNotify(new GenericCallback(this.UpdateSignin));
				//server.BindSignoutNotify(new GenericCallback(this.UpdateSignout));

				server.BindUserBase(user);
				server.BindDebugObject(logger);
				user.BindDebugObject(logger);

				server.StartServer();
				user.Connect();
			}
			catch (Exception ex)
			{
				UpdateLog("Port address is incorrect or already in use. " + ex.Message);
			}
		}

		private void StopServer()
		{
			server.StopServer();
		}

		private void UpdateButtons()
		{
			bool isRunning = false;
			try
			{
				isRunning = server.IsRunning();
			}
			catch (NullReferenceException n)
			{
				isRunning = false; // server object doesn't exist
			}
			btnStartServer.Enabled = ! isRunning;
			btnStopServer.Enabled = isRunning;
			sbServerStatus.Text = "Status: " + (isRunning == true ? "Running" : "Stopped");
		}

		private void btnStopServer_Click(object sender, EventArgs e)
		{
		}

		private void btnStartServer_Click_1(object sender, EventArgs e)
		{
			StartServer();
			UpdateButtons();
		}

		private void btnStopServer_Click_1(object sender, EventArgs e)
		{
			StopServer();
			UpdateButtons();
		}

		private void tabPage3_Click(object sender, EventArgs e)
		{

		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void btnUsersRefresh_Click(object sender, EventArgs e)
		{
			PopulateUserList();
		}

		private void PopulateUserList()
		{
			lstUsers.Items.Clear();
			foreach (Server.Client c in this.server.clientPool.Values)
			{
				string userid = c.user.ID;
				string accesslevel = "User";
				string logintime = "Today";
				string channel = c.channel.ChannelID == -1 ? "None!" : c.channel.ChannelID + ": " + c.channel.ChannelTitle;
				string ipaddress = "127.0.0.1";

				lstUsers.Items.Add( new ListViewItem (new string[] { userid, accesslevel, logintime, channel, ipaddress }) );
			}
		}

        private void PopulateChannelList()
        {
            lstChannels.Items.Clear();
            foreach (Channel chan in this.server.channelPool.Values)
            {
                lstChannels.Items.Add(new ListViewItem(new string[] { chan.ChannelID.ToString() , chan.ChannelTitle, chan.ChannelURL, chan.ChannelOwner.ID }));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PopulateChannelList();
        }
	}
}