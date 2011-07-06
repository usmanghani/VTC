using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace VTC
{
	public partial class frmUserLogin : Form
	{
		Client c = new Client();

		public frmUserLogin()
		{
			InitializeComponent();
            c.myForm = this;
			timer1.Enabled = false;
		}

        public void UpdateGeneralStatus(string str)
		{
			sbGeneralStatus.Text = str;
		}

		public void UpdateStatus()
		{
			try
			{
			}
			catch (NullReferenceException e)
			{
				sbStreamStatus.Text = "Closed";
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			this.UpdateStatus();
		}

        public void Execute(string path, string param)
        {
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo(path, param);
            p.Start();
        }


		private void btnLogin_Click(object sender, EventArgs e)
		{
			UpdateGeneralStatus("Logging in...");
			c.disconnect();
			c.LogHandler = new GenericCallback(AppendLog);

			if (!c.connect(txtServer.Text, 4096))
			{
				AppendLog("Connection failed!");
				UpdateGeneralStatus("Connection failed.");
				return;
			}

			AppendLog("Connected!");
			UpdateGeneralStatus("Connected. Logging in. Getting Channels List.");
            listView2.Items.Clear();
            c.Login(txtUsername.Text,txtPassword.Text);
            c.GetChannels();
        }

		public void AppendLogNative (string str)
		{
			txtLog.AppendText ( str + "\r\n" );
		}

		public void AppendLog (string str)
		{
			txtLog.Invoke(new GenericCallback(AppendLogNative), new object[] { str });
		}

        private void button3_Click(object sender, EventArgs e)
        {
            if (c!=null)
                c.disconnect();
        }

        public void AddChannelLV(string ID, string Name, string URL, string Owner)
        {
            ListViewItem li = new ListViewItem(new string[] { ID , Name, URL, Owner });
            listView2.Items.Add(li);
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView2_DoubleClick(object sender, EventArgs e)
        {
            string id = listView2.SelectedItems[0].SubItems[0].Text;
            //Send ID to server!
            string url = listView2.SelectedItems[0].SubItems[1].Text;
            Execute("wmplayer", url);
        }
	}
}
