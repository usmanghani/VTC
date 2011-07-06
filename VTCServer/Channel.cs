using System;
using System.Collections.Generic;
using System.Text;

namespace VTCServer
{
	public class Channel
	{
		public long ChannelID = -1;
		public Server.Client ChannelClient = null;
		public User ChannelOwner = null;

		public string ChannelTitle = "";
		public string ChannelURL = "";
        public string ChannelCreated;

		public Channel()
		{
		}

		public Channel(long id, Server.Client client)
		{
			ChannelID = id;
			ChannelClient = client;
			ChannelOwner = ChannelClient.user;
		}
	}
}
