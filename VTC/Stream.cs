using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using WMEncoderLib;

namespace VTC
{
	enum EStreamStates { Running, Stopped, Starting, Pausing, Stopping, Paused, Ending };
	delegate void DelegateStatusUpdate();

	class Stream
	{	
		WMEncoderApp EncoderApp = null;
		IWMEncoder Encoder = null;
		IWMEncBroadcast BrdCst;
		IWMEncSourceGroupCollection SrcGrpColl;
		IWMEncSourceGroup SrcGrp;
		IWMEncSource SrcAud;
		IWMEncVideoSource2 SrcVid;
		IWMEncProfile Pro;
		IWMEncProfileCollection ProColl;

		public ArrayList data = new ArrayList();

		private EStreamStates streamStatus;
		private DelegateStatusUpdate eventFire;
		private int port;
		private string codec;

		public int Port
		{
			get { return port; }
			set { if (value > 1024) port = value; }
		}

		public string Codec
		{
			get { return codec; }
			set { codec = value; }
		}

		public DelegateStatusUpdate RegisterUpdate
		{
			get { return eventFire; }
			set { eventFire = value; }
		}

		public Stream(int p, string c)
		{
			this.Port = p;
			this.Codec = c;
		}

		public void SendUpdate()
		{
			if (RegisterUpdate != null)
			{
				RegisterUpdate();
			}
		}

		public void InitializeBasic ()
		{
			if (EncoderApp == null)
			{
				EncoderApp = new WMEncoderApp();
				Encoder = EncoderApp.Encoder;
				// IMPORTANT: set to false on product release
				EncoderApp.Visible = false; //true; 
				//Encoder.OnStateChange += new _IWMEncoderEvents_OnStateChangeEventHandler(OnStateChange);
				InitializeEncoder();
			}
		}

		private void InitializeEncoder ()
		{
			SrcGrpColl = Encoder.SourceGroupCollection;
			SrcGrp = SrcGrpColl.Add("SG_1");
			SrcAud = SrcGrp.AddSource(WMENC_SOURCE_TYPE.WMENC_AUDIO);
			SrcVid = (IWMEncVideoSource2)SrcGrp.AddSource(WMENC_SOURCE_TYPE.WMENC_VIDEO);
			SrcAud.SetInput("Default_Audio_Device", "Device", "");
			SrcVid.SetInput("Default_Video_Device", "Device", "");

			ProColl = Encoder.ProfileCollection;

			for (int i = 0; i < ProColl.Count; i++)
			{
				Pro = ProColl.Item(i);
				data.Add(Pro.Name);

				if (Pro.Name == Codec)
				{
					SrcGrp.set_Profile(Pro);
					break;
				}
			}
			BrdCst = Encoder.Broadcast;
			BrdCst.set_PortNumber(WMENC_BROADCAST_PROTOCOL.WMENC_PROTOCOL_HTTP, Port);
		}

		public void startStreaming ()
		{
			try 
			{
				Encoder.PrepareToEncode(true);
				Encoder.Start();
			} 

			catch (Exception e) 
			{
			}
		}
		public void stopStreaming()
		{
			try
			{
				Encoder.Stop();
			}
			catch (Exception e)
			{
			}
		}
		public string GetStreamStatus()
		{
			return getStatus().ToString();
		}

		private EStreamStates getStatus()
		{
			try
			{
				switch (Encoder.RunState)
				{
					case WMENC_ENCODER_STATE.WMENC_ENCODER_RUNNING:
						streamStatus = EStreamStates.Running;
						break;

					case WMENC_ENCODER_STATE.WMENC_ENCODER_STOPPED:
						streamStatus = EStreamStates.Stopped;
						break;

					case WMENC_ENCODER_STATE.WMENC_ENCODER_STARTING:
						streamStatus = EStreamStates.Starting;
						break;

					case WMENC_ENCODER_STATE.WMENC_ENCODER_PAUSING:
						streamStatus = EStreamStates.Pausing;
						break;

					case WMENC_ENCODER_STATE.WMENC_ENCODER_STOPPING:
						streamStatus = EStreamStates.Stopping;
						break;

					case WMENC_ENCODER_STATE.WMENC_ENCODER_PAUSED:
						streamStatus = EStreamStates.Paused;
						break;

					case WMENC_ENCODER_STATE.WMENC_ENCODER_END_PREPROCESS:
						streamStatus = EStreamStates.Ending;
						break;
				}
			}
			catch (Exception e)
			{
			}
			return streamStatus;
		}


		static public void OnStateChange(WMENC_ENCODER_STATE enumState)
		{
			switch (enumState)
			{
				case WMENC_ENCODER_STATE.WMENC_ENCODER_RUNNING:
					// TODO: Handle running state.
					break;

				case WMENC_ENCODER_STATE.WMENC_ENCODER_STOPPED:
					// TODO: Handle stopped state.
					//bDone = true;
					break;

				case WMENC_ENCODER_STATE.WMENC_ENCODER_STARTING:
					// TODO: Handle starting state.
					break;

				case WMENC_ENCODER_STATE.WMENC_ENCODER_PAUSING:
					// TODO: Handle pausing state.
					break;

				case WMENC_ENCODER_STATE.WMENC_ENCODER_STOPPING:
					// TODO: Handle stopping state.
					break;

				case WMENC_ENCODER_STATE.WMENC_ENCODER_PAUSED:
					// TODO: Handle paused state.
					break;

				case WMENC_ENCODER_STATE.WMENC_ENCODER_END_PREPROCESS:
					// TODO: Handle end preprocess state.
					break;
			}
		}

		public string GetStreamURL()
		{
			string ipaddr = (System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName())[0].ToString());
			return "http://" + ipaddr + ":" + Port.ToString();
		}
	}
}
