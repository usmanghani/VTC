using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Collections;
using System.Text;
using System.Threading;

namespace VTCServer
{
	public delegate void VoidCallback();
	public delegate void GenericCallback(string id);
	public delegate void LoggerCallback(string s);

	public enum UserMode { Presenter, Viewer, Admin };

		public class Server
		{
			private int port;
			private bool isRunning = false;
			private TcpListener server;
			private Thread runner;
			private UserBase user;
			public Hashtable clientPool;
			public Hashtable channelPool;

			// delegated functions
			private LoggerCallback logNotify;
			private GenericCallback signinNotify;
			private GenericCallback signoutNotify;
			private VoidCallback statusChangeNotify;

			public Server(int port)
			{
				isRunning = false;
				this.port = port;
				INIT();
			}

			private void INIT()
			{
				clientPool = new Hashtable(50);
				channelPool = new Hashtable(50);
			}

			~Server()
			{
				this.StopServer();
			}

			public void debugAlert(string msg)
			{
				if (logNotify != null)
					logNotify(msg);
			}

			public bool IsRunning() { return isRunning; }

			public void BindDebugObject(LoggerCallback l) { logNotify = l; }
			public void BindSigninNotify(GenericCallback l) { signinNotify = l; }
			public void BindSignoutNotify(GenericCallback l) { signoutNotify = l; }
			public void BindUserBase(UserBase u) { user = u; }

			public void SendMessage(string source, string target, string msg)
			{
				Client c = (Client)clientPool[target];
				//c.StartWrite ( "From Client " + source.ToString () + "> " + msg );
				if (c != null)
				{
					c.SendMessage(msg);
					debugAlert("Message from " + source.ToString() + " to " + target.ToString() + ": " + msg);
				}
			}

			public void SendCommand(string src, string target, string cmd, string s)
			{
				SendMessage(src, target, "\x7F" + cmd + " " + s + "\x7F");
			}

			public void StartServer()
			{
				debugAlert("Server Started {port: " + port.ToString() + "}");
				isRunning = true;
				server = new TcpListener(port);
				server.Start();
				runner = new Thread(new ThreadStart(this.startMonitoring));
				runner.IsBackground = true;
				runner.Start();
			}

			public void StopServer()
			{
				isRunning = false;

				if (runner != null)
				{
					runner.Abort();
					runner = null;
				}
				server.Stop();

				// Cleanup connections
				try
				{
					foreach (object o in this.clientPool)
						if (o != null) ((Client)o).Disconnect();
				}
				catch { }
				finally
				{
					clientPool.Clear();
				}

				debugAlert("Server Shutdown");
			}

			public void SuspendServer()
			{
				if (runner.ThreadState == ThreadState.Running)
					runner.Suspend();
			}

			public void ResumeServer()
			{
				if (runner.ThreadState == ThreadState.Suspended)
					runner.Resume();
			}

			private void startMonitoring()
			{
				try
				{
					while (isRunning == true)
					{
						Socket clientSocket = server.AcceptSocket();
						if (clientSocket.Connected)
						{
							debugAlert("New Client Connected!");
							Client client = new Client(clientSocket, this);
							client.StartRead();
						}
					}
				}
				catch (ThreadInterruptedException)
				{
					debugAlert("Server Interrupted");
				}
				finally
				{
					server.Stop();
				}
			}


			public bool IsUserConnected(string uid)
			{
				return clientPool.ContainsKey(uid);
			}

			public Client GetClient(string uid)
			{
				if (clientPool.ContainsKey(uid))
					return (Client)clientPool[uid];
				return null;
			}

			public long SetStatus(string uid, int status)
			{
				return this.user.SetStatus(uid, status);
			}


			public void CreateChannel (Client cl, string channelTitle, string channelURL)
			{
				// record the log and we'll know if we have the authentication to
				// start a channel
				long channelID = user.CreateChannel(cl.user, channelTitle, channelURL);
				if (channelID > 0)
				{
					Channel c = new Channel(channelID, cl);
                    c.ChannelTitle = channelTitle;
                    c.ChannelURL = channelURL;
					channelPool[channelID] = c;
					cl.channel = c;
					debugAlert("Channel Created <" + channelID + "> " + channelTitle);
				}
				else
				{
					debugAlert("Channel Creation Failed: " + channelTitle);
				}
			}



			//////////////////////////////////////
			//////////////////////////////////////
			//////////////////////////////////////
			// Client
			//////////////////////////////////////
			//////////////////////////////////////
			//////////////////////////////////////

			/// <summary>
			/// Client Class
			/// </summary>
			public class Client
			{
				private bool isDestroying = false;
				public static long connectionID;

				public User user;
				public Channel channel;
				public UserMode mode;

				private Socket sock;
				private byte[] buffer;
				private byte[] writebuffer;
				private NetworkStream stream;
				private AsyncCallback callbackRead;
				private AsyncCallback callbackWrite;
				private Server server;
				private string cmdline;

				private IAsyncResult res;

				public Client(Socket c, Server s)
				{
					connectionID++;
					this.sock = c;
					this.server = s;
					stream = new NetworkStream(sock);
					callbackRead = new AsyncCallback(this.OnReadComplete);
					callbackWrite = new AsyncCallback(this.OnWriteComplete);
					buffer = new byte[256];
					writebuffer = new byte[256];
					user = new User();
					channel = new Channel();
				}

				public int ProcessCommand(string cmd)
				{
					cmd.Trim();
					string[] c = cmd.Split(" ".ToCharArray(), 2);
					string[] val;
					long ChannelID;
					string tag = c[0].ToUpper();
					string dat = c.Length > 1 ? c[1].Trim() : "";

					server.debugAlert("Client <" + user.ID + ">" + connectionID.ToString() + " CMD> " + cmd);

					switch (tag)
					{
						case "AUTHVIEWER":
							val = dat.Split("/".ToCharArray(), 2);
							Authenticate(val[0], val[1]);
							break;

						case "AUTHPRESENTER":
							val = dat.Split("/".ToCharArray(), 2);
							Authenticate(val[0], val[1]);
							break;

						case "AUTHADMIN":
							val = dat.Split("/".ToCharArray(), 2);
							Authenticate(val[0], val[1]);
							break;

						case "CHANNELCREATE":
							val = dat.Split("/".ToCharArray(), 2);
							server.CreateChannel(this,val[0].Trim(), val[1].Trim());
							break;

						case "CHANNELJOIN":
							ChannelID = long.Parse(dat);
							ChannelID = JoinChannel(ChannelID);
							if (ChannelID >0) SendChannelInfo(ChannelID);
							break;

						case "GETCHANNELS":
							SendChannelsList();
							break;

						case "CHANNELUPDATE": // TODO
							val = dat.Split("/".ToCharArray(), 2);
							ChannelID = long.Parse(val[0]);
							server.user.UpdateChannelTitle(user,ChannelID, val[1]);
							SendChannelInfo(ChannelID);
							break;

						case "SEND":
							val = dat.Split("/".ToCharArray(), 2);
							server.SendCommand(user.ID, val[0], "UMESSAGE", user.ID.ToString() + "," + val[1]);
							break;

						case "LOGOUT":
							Disconnect();
							break;
					}
					return 0;
				}

				public void WriteStream(string s)
				{
					byte[] b = System.Text.Encoding.UTF8.GetBytes(s.ToCharArray(), 0, s.Length);
					try
					{
						stream.Write(b, 0, b.Length);
					}
					catch (System.IO.IOException e)
					{
						server.debugAlert("IO Exception: " + e.Message);
						this.Disconnect();
					}
				}

				public void SendMessage(string s)
				{
					WriteStream(s);
				}

				public void SendCommand(string cmd, string s)
				{
					SendMessage("\x7F" + cmd + " " + s + "\x7F");
				}

				public void StartRead()
				{
					stream.BeginRead(buffer, 0, buffer.Length, callbackRead, null);
				}

				public void StartWrite(string buff)
				{
					byte[] b = System.Text.Encoding.UTF8.GetBytes(buff.ToCharArray(), 0, buff.Length);
					stream.BeginWrite(b, 0, b.Length, callbackWrite, null);
					buffer = new byte[256];
				}

				private void OnReadComplete(IAsyncResult ar)
				{
					int bytes = 0;
					try
					{
						bytes = stream.EndRead(ar);
					}
					catch { return; }
					res = ar;

					if (bytes > 0)
					{
						cmdline += System.Text.Encoding.UTF8.GetString(buffer, 0, bytes);
						int x = cmdline.IndexOf("\x7F");
						if (x > 0)
						{
							string dat = cmdline.Substring(x + 1);
							cmdline = cmdline.Substring(0, x);
							ProcessCommand(cmdline);
							cmdline = dat;
						}
						try
						{
							stream.BeginWrite(writebuffer, 0, bytes, callbackWrite, null);
						}
						catch (System.NullReferenceException e)
						{
							server.debugAlert("ONREADCOMPLETE Null exception: " + e.Message);
							Disconnect();
							return;
						}
						catch (System.IO.IOException e)
						{
							server.debugAlert("ONREADCOMPLETE IO exception: " + e.Message);
							Disconnect();
							return;
						}
					}
					else
					{
						server.debugAlert("Connection dropped!");
						Disconnect();
					}
				}

				private void OnWriteComplete(IAsyncResult ar)
				{
					res = ar;
					stream.EndWrite(ar);
					//server.debugAlert ( "Write Complete!" );
					try
					{
						stream.BeginRead(buffer, 0, buffer.Length, callbackRead, null);
					}
					catch { this.Disconnect(); }
				}

				public long JoinChannel (long channelid)
				{
					// extract channel information from hash
					Channel c = (Channel)server.channelPool[channelid];

					// channel does not exist (anymore!?)
					if (c == null)
						return -1;

					string url = server.user.JoinChannel(user, channelid);
					if ( url != null)
					{
						return c.ChannelID;
					}
					return -1;
				}


				public void Authenticate(string u, string p)
				{
					u.Trim();
					user.ID = server.user.Authenticate(u, p);
					if (user.ID != null) BeginLogin();
					else Disconnect();
				}

				private void BeginLogin()
				{
					if (server.IsUserConnected(user.ID))
					{
						Client c = (Client)(server.clientPool[user.ID]);
						c.SendMessage("WHOOPS ANOTHER SESSION REQUESTED. SHUTTING DOWN THIS ONE");
						c.Disconnect();
					}

					server.clientPool.Add(user.ID, this);
					server.debugAlert("New Connection <" + this.user.ID + ">");

					//server.signinNotify(user.ID);
					//SendMessageToFriends("ADDFRIND", user.ID.ToString() + ",0,1," + user.ID + "," + server.user.GetNickName(user.ID));

					//ArrayList friends = server.user.GetFriends(user.ID, -1);
					//foreach (Friend f in friends)
					//	server.SendCommand("0", user.ID, "ADDFRIND", f.GenerateClientString());
					//friends = null;
				}

				private void SendChannelsList ()
				{
					this.SendCommand("CHANNELCLEAR","");
                    if (server.channelPool.Count > 0)
                    {
                        foreach (Channel c in server.channelPool.Values)
                        {
                            this.SendCommand("CHANNELADD", c.ChannelID.ToString() + "!/!" + c.ChannelOwner.ID + "!/!" + c.ChannelURL + "!/!" + c.ChannelTitle);
                        }
                    }
				}

				private bool SendChannelInfo (long ChannelID)
				{
					Channel c = (Channel) server.channelPool[ChannelID];
					if (c == null) return false;
					
					this.SendCommand("CHANNELINFO", c.ChannelID.ToString() + "/" + c.ChannelURL );
					return true;
				}

				public void Disconnect()
				{
					if (isDestroying == false)
					{
						isDestroying = true;
						if (IsConnected())
						{
							if (user != null && user.ID != null)
							{
								server.clientPool.Remove(user.ID);
								//SendMessageToFriends("ADDFRIND", user.ID.ToString() + ",-1,0," + user.ID + ",OFFLINE");
								//server.signoutNotify(user.ID);
							}

                            if (channel != null && channel.ChannelID > 0)
                                server.channelPool.Remove(channel.ChannelID);
						}
						if (stream != null)
						{
							try
							{
								stream.Close();
								stream = null;
							}
							catch { }
						}
						if (sock != null)
						{
							try
							{
								sock.EndSend(res);
								sock.EndReceive(res);
								sock.Shutdown(SocketShutdown.Both);
								sock.Close();
							}
							catch { }
							sock = null;
						}
					}
				}

				public bool IsConnected()
				{
					return user != null ? true : false;
				}

				~Client()
				{
					Disconnect();
				}
			}
		}
}
