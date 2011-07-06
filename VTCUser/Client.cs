using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Collections;
using System.IO;

namespace VTC
{
	public delegate void GenericCallback(string id);

	class Client
	{
		private Thread reader;
		private TcpClient client;
		private NetworkStream stream;
		private StreamWriter streamWriter;
		private StreamReader streamReader;
        public frmUserLogin myForm;

		public string UserID;
		public string address;
		public int port;
		public bool isConnected = false;
		public bool isquit = false;
		public GenericCallback LogHandler;

		public string errormessage;

		public bool connect(string address, int port)
		{
			this.address = address;
			this.port = port;
			return connect();
		}

		public bool connect()
		{
			try
			{
				client = new TcpClient(address, port);
				stream = client.GetStream();
				streamWriter = new StreamWriter(stream, System.Text.Encoding.UTF8);
				streamReader = new StreamReader(stream, System.Text.Encoding.UTF8);
				isConnected = true;
			}
			catch (SocketException se)
			{
				isConnected = false;
				errormessage = se.Message;
			}
			return isConnected;
		}

		public void SendCommand(string cmd, string param)
		{
			send(cmd + " " + param + "\x7F");
		}

		public int send(string str)
		{
			if (!isConnected) return -1;
			Byte[] c = System.Text.Encoding.UTF8.GetBytes(str.ToCharArray());
			try { stream.Write(c, 0, c.Length);	}
			catch { ShowError ("ERR SENDING!"); }
			return 0;
		}

		public void disconnect()
		{
			if (isConnected == true)
			{
				try
				{
					streamWriter.Close();
					streamReader.Close();
				}
				catch { }

				try
				{
					stream.Close();
					client.Close();
				}
				catch { }
			}
			try { reader.Abort(); }
			catch { }

			stream = null;
			client = null;
			isConnected = false;
		}

		private void ClientReader()
		{
			int ch;
			string cmd = "";
			bool iscommand = false;
			try
			{
				while (isquit == false && (ch = streamReader.Read()) >= 0)
				{
					if (ch == 127)
					{
						if (iscommand == false)
							iscommand = true;
						else
						{
							iscommand = false;
							ProcessCommand(cmd);
							cmd = "";
						}
						continue;
					}

					if (iscommand == false)
						LogHandler (((char)ch).ToString());
					else
						cmd += ((char)ch).ToString();
				}
			}
			catch (IOException)
			{
				disconnect();
			}
		}

		private void ProcessCommand(string cmd)
		{
			cmd.Trim();
			if (cmd.Length < 10) return;

			LogHandler ("<" + cmd + ">");
			int idx = cmd.IndexOf(' ');
            string code = cmd.Substring(0, idx);
			string str = cmd.Substring(idx+1);
			string[] val;

			switch (code)
			{
				case "USERDATA":
					val = str.Split(",".ToCharArray(), 3);
					this.UserID = val[0];
					break;

				case "CHANNELCLEAR":
                    break;

				case "CHANNELADD":
                    val = str.Split(new string[] { "!/!" }, 4, StringSplitOptions.None);
                    myForm.AddChannelLV( val[0], val[2], val[3], val[1]);
                    break;

					//friends.Remove(int.Parse(val[0]));
					//friends.Add(int.Parse(val[0]), f);
					//TreeNode t = new TreeNode(val[4]);
					//t.Tag = f;

/*					if (int.Parse(val[2]) == 0)
					{
						treeView1.Invoke(new TreeFunction(AddOfflineNode), new object[1] { t });
						t.ImageIndex = 3;
					}
					else
					{
						treeView1.Invoke(new TreeFunction(AddOnlineNode), new object[1] { t });
						t.ImageIndex = 2;
					}
					break;

				case "UMESSAGE":
					val = str.Split(",".ToCharArray(), 2);
					treeView1.Invoke(new TreeFunction2(this.MessageHandle), new object[2] { int.Parse(val[0]), val[1].ToString() });
					break;
*/
			}
		}

		public void Login(string user,string pass)
		{
			SendCommand("AUTHVIEWER", user + "/" + pass );
			reader = new Thread(new ThreadStart(ClientReader));
			reader.IsBackground = true;
			reader.Start();
		}

		public void HostChannel(string channelName, string channelURL)
		{
			SendCommand("CHANNELCREATE", channelName + "/" + channelURL);
		}

		private void ShowError(string msg)
		{
			System.Windows.Forms.MessageBox.Show(msg);
		}

        public void GetChannels()
        {
            SendCommand("GETCHANNELS", "");
        }
    }
}