using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace MUD
{
	public class MudConnection

	{
		private TcpClient theConnection;
		private Thread theThread;
		private NetworkStream theStream;
		private string host;
		private int port;
		private TerminalWindow terminalWindow;

		public MudConnection(TerminalWindow tw, string host_name, int port_num)

		{
			terminalWindow = tw;
			theConnection = new TcpClient();
			host = host_name;
			port = port_num;
		}

		public void setHost(string s) { host = s; }
		public void setPort(int p)    { port = p; }
		public string getHost()       { return host; }
		public int getPort()          { return port; }

		// Wrapper function to thread a connection
		public void connect()

		{
			theThread = new Thread(new ThreadStart(attemptConnect));
			theThread.Start();
		}

		// Attempt to connect to host
		public void attemptConnect()

		{
			try

			{
				theConnection.Connect(host, port);
				theStream = theConnection.GetStream();
			}

			catch(Exception exc)

			{
				MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			beginReceive();
		}

		// Receiving loop
		public void beginReceive()

		{
			string inputstring = "";
			byte[] buf = new byte[1000];
			int size = 0;
			ASCIIEncoding ascii = new ASCIIEncoding();

			while (true)

			{
				if (theStream.DataAvailable) 
				
				{
					size = theStream.Read(buf, 0, 1000);
					inputstring = ascii.GetString(buf, 0, size); 
				}

				if (inputstring.Length > 0)
				
				{
					terminalWindow.addText(inputstring);
					inputstring = ""; 
				}

				Thread.Sleep(10);
			}
		}

		// Send string s to host
		public void sendText(string s)

		{
			if (s[s.Length-1] != '\n')
				s = s + "\n";

			try

			{
				byte[] theMessage = Encoding.UTF8.GetBytes(s);
				theStream.Write(theMessage, 0, theMessage.Length);
			}

			catch (Exception exc) { MessageBox.Show(exc.Message); }
		}

		public void disconnect()
		{
			if (theStream != null)
				theStream.Close();
			if (theConnection != null)
				theConnection.Close();
			terminalWindow.Text = "";
		}
	}
}
