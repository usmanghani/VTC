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
	public partial class StreamingForm : Form
	{
		Thread streamerThread;
		Stream stream = null;
		Client c = new Client();

		public StreamingForm()
		{
			InitializeComponent();
			stream = new Stream(8181, "Windows Media Video 8 for Local Area Network (768 Kbps)");
			stream.RegisterUpdate = new DelegateStatusUpdate(UpdateStatus);
			timer1.Enabled = false;
		}

		private void InitializeStream ()
		{
			stream.InitializeBasic();
			foreach (string data in stream.data)
			{
				textBox1.Text += data + "\r\n";
			}
			sbPortText.Text = "Port: " + stream.Port.ToString();
		}

		public void UpdateGeneralStatus(string str)
		{
			sbGeneralStatus.Text = str;
		}

		public void UpdateStatus()
		{
			try
			{
				sbStreamStatus.Text = stream.GetStreamStatus();
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

		private void sbPortText_Click(object sender, EventArgs e)
		{
			if (stream != null)
			{
				Process p = new Process();
				p.StartInfo = new ProcessStartInfo("wmplayer", stream.GetStreamURL());
				p.Start();
			}
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
			UpdateGeneralStatus("Connected. Logging in...");
			c.Login(txtUsername.Text,txtPassword.Text);
			c.HostChannel(txtChannelTitle.Text, stream.GetStreamURL() );
        }

		public void AppendLogNative (string str)
		{
			txtLog.AppendText ( str + "\r\n" );
		}

		public void AppendLog (string str)
		{
			txtLog.Invoke(new GenericCallback(AppendLogNative), new object[] { str });
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			timer1.Enabled = true;
			InitializeStream();
			stream.startStreaming();
			//streamerThread = new Thread(new ThreadStart());
		}

		private void button2_Click_1(object sender, EventArgs e)
		{
			stream.stopStreaming();
		}

        private void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            stream.stopStreaming();
            if (c!=null)
                c.disconnect();
        }
	}
}