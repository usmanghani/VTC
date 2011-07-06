using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using System.Collections;

namespace VTCServer
{
	public class User
	{
		public string ID = "";
	}

	/// <summary>
	/// Providers User authentication against database server etc.
	/// </summary>
	public class UserBase
	{
		private SqlConnection conn;
		private LoggerCallback updateFunction;
		private bool isConnected = false;

		public bool IsConnected() { return isConnected; }
		public SqlCommand GetCommand(string cmd)
		{
			return new SqlCommand(cmd, conn);
		}

		public void BindDebugObject(LoggerCallback l)
		{
			updateFunction = l;
		}

		public UserBase() { }

		~UserBase()
		{
			Disconnect();
		}

		public void Connect()
		{
			try
			{
                conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=VTC");
				conn.Open();
				isConnected = true;
				updateFunction("Database Connected");
			}
			catch (SqlException e)
			{
				isConnected = false;
				updateFunction("ERROR> " + e.Message);
			}
		}

		public void ResetStatus()
		{
			if (isConnected == true)
			{
				SqlCommand cmd = GetCommand("EXEC ResetStatus");
				cmd.ExecuteNonQuery();
			}
		}

		public string Authenticate(string username, string password)
		{
			string userid = null;
			try
			{
				SqlCommand cmd = new SqlCommand("EXEC SPAuthenticateUser @userid,@passwd", conn);
				cmd.Parameters.AddWithValue("@userid", username);
				cmd.Parameters.AddWithValue("@passwd", password);
                userid = cmd.ExecuteScalar().ToString();
                cmd.Dispose();
			}
			catch (SqlException e)
			{
				ReportError(e.Message);
			}
			if (userid == "") userid = null;
			return userid;
		}

		public long CreateChannel(User u, string cTitle, string cURL)
		{
			long channelid = -1;
            try
            {
                SqlCommand cmd = new SqlCommand("EXEC SPCreateChannel @userid,@channeltitle,@channelurl", conn);
                cmd.Parameters.AddWithValue("@userid", u.ID);
                cmd.Parameters.AddWithValue("@channeltitle", cTitle);
                cmd.Parameters.AddWithValue("@channelurl", cURL);
                channelid = long.Parse(cmd.ExecuteScalar().ToString());
                cmd.Dispose();
            }
            catch (SqlException e)
            {
                channelid = -1;
                ReportError(e.Message);
            }
            catch (Exception e)
            {
                channelid = -1;
                ReportError(e.Message);
            }
			return channelid;
		}

		private void ReportError(string str)
		{
			System.Windows.Forms.MessageBox.Show(str);
		}


		public string JoinChannel(User u, long ChannelID)
		{
			string url = null;
			try
			{
				SqlCommand cmd = new SqlCommand("EXEC SPJoinChannel @userid,@channelid", conn);
				cmd.Parameters.AddWithValue("@userid", u.ID);
				cmd.Parameters.AddWithValue("@channelid", ChannelID);
				url = cmd.ExecuteScalar().ToString();
                cmd.Dispose();
			}
			catch (SqlException e)
			{
				ReportError(e.Message);
				return null;
			}
            catch (Exception e)
            {
                ReportError(e.Message);
                return null;
            }

			return url;
		}

		public long SetStatus(string uid, int status)
		{
			SqlCommand cmd;
			try
			{
				cmd = new SqlCommand("UpdateStatus");
				cmd.Connection = this.conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@userid", uid);
				cmd.Parameters.AddWithValue("@status", status);
				int res = cmd.ExecuteNonQuery();
				cmd.Dispose();
				return res;
			}
			catch (SqlException e)
			{
				System.Windows.Forms.MessageBox.Show("Couldn't update Status: " + e.Message);
			}
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Couldn't update Status: " + e.Message);
            }

			return 0;
		}

		public string GetUserID(string username)
		{
			try
			{
				SqlCommand cmd = GetCommand("EXEC GetUserID @username");
				cmd.Parameters.AddWithValue("@username", username);
				return cmd.ExecuteScalar().ToString();
			}
			catch
			{
				return null;
			}
		}

		/*
		 * public ArrayList GetFriends(string userid, int status)
		{
			SqlCommand cmd = new SqlCommand("", conn);
			ArrayList friends = new ArrayList();
			SqlDataReader reader = null;

			//if ( status != -1 ) cmd.CommandText += " AND status=" + status;
			try
			{
				cmd.CommandText = "EXEC GetFriends @userid";
				cmd.Parameters.AddWithValue("@userid", userid);
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					friends.Add(new Friend(reader[0].ToString()));
				}
			}
			catch
			{
				System.Windows.Forms.MessageBox.Show("ERR!");
			}
			finally
			{
				if (reader != null) reader.Close();
			}

			return friends;
		}
		 * */

		public string UpdateChannelTitle (User u, long ChannelID, string ChannelTitle)
		{
			SqlCommand cmd;
			try
			{
				cmd = new SqlCommand("SPUpdateChannelTitle", this.conn);
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("@userid", u.ID);
				cmd.Parameters.AddWithValue("@channelid", ChannelID);
				cmd.Parameters.AddWithValue("@channeltitle", ChannelTitle);
//				SqlParameter myParm = cmd.Parameters.Add("@channeltitle", SqlDbType.NVarChar, 120, ChannelTitle);
//				myParm.Value = ChannelTitle;
				cmd.ExecuteNonQuery();

				return "";
				//return cmd.ExecuteScalar ().ToString ();
			}
			catch
			{
				return null;
			}
		}

		public void Disconnect()
		{
			updateFunction("Database Disconnected!");
			isConnected = false;
			if (conn != null)
			{
				try
				{
					conn.Close();
					conn.Dispose();
				}
				catch { }
			}
			conn = null;
		}
	}
}
