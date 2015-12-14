using System;

namespace MUD

{
	[Serializable]
	public class World
	
	{
		public string name;
		public string host;
		public int port;
	  
		public World()
		
		{
			name = "Generic World.";
			host = "www.hostname.com";
			port = 23;
		}
		
		public World(string Name, string Host, int Port)
		
		{
			name = Name;
			host = Host;
			port = Port;
		}
	}
}
