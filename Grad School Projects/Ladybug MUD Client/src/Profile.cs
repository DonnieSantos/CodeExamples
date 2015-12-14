using System;
using System.IO;
using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MUD
{
	/// <summary>
	/// Summary description for Profile.
	/// </summary>

	[Serializable]
	public class Profile

	{
		public alias_list AL;
		public action_list AC;
		public string[] macros;
		public RGB_Color[] Colors;
		public ArrayList Worlds;
	  
		public Profile()
		
		{
			AL = new alias_list();
			AC = new action_list();
			
			initialize_macros();
			initialize_colors();
			
			Worlds = new ArrayList();
		}
		
		public void save_profile(string filename)
	
		{
			FileStream outfile = new FileStream(filename, FileMode.Create);
			BinaryFormatter formatter = new BinaryFormatter();
			formatter.Serialize(outfile, this);
			outfile.Close();
		}
    
		public void load_profile(string filename)
    
		{
			Profile P = new Profile();
      
			FileStream infile = new FileStream(filename, FileMode.Open);
			BinaryFormatter formatter = new BinaryFormatter();
			P = (Profile)formatter.Deserialize(infile);
			infile.Close();
			
			AL = P.AL;
			AC = P.AC;
			macros = P.macros;
			Colors = P.Colors;
			Worlds = P.Worlds;
		}
		
		private void initialize_macros()
		
		{
			macros = new string [10];
      
			for (int i=0; i<10; i++)
				macros[i] = "";
		}
		
		public void initialize_colors()
		
		{
			Colors = new RGB_Color [18];
      
			for (int i=0; i<18; i++) Colors[i] = new RGB_Color();
      
			Colors[0].R = 0;     Colors[0].G = 0;     Colors[0].B = 0;     // Black.
			Colors[1].R = 255;   Colors[1].G = 255;   Colors[1].B = 255;   // White.
			Colors[2].R = 255;   Colors[2].G = 0;     Colors[2].B = 0;     // Red.
			Colors[3].R = 0;     Colors[3].G = 0;     Colors[3].B = 255;   // Blue.
			Colors[4].R = 0;     Colors[4].G = 255;   Colors[4].B = 0;     // Green.
			Colors[5].R = 255;   Colors[5].G = 255;   Colors[5].B = 0;     // Yellow.
			Colors[6].R = 0;     Colors[6].G = 192;   Colors[6].B = 192;   // Dark Cyan.
			Colors[7].R = 255;   Colors[7].G = 0;     Colors[7].B = 255;   // Magenta.
			Colors[8].R = 192;   Colors[8].G = 0;     Colors[8].B = 0;     // Dark Red.
			Colors[9].R = 0;     Colors[9].G = 192;   Colors[9].B = 0;     // Dark Green.
			Colors[10].R = 0;    Colors[10].G = 0;    Colors[10].B = 192;  // Dark Blue.
			Colors[11].R = 192;  Colors[11].G = 192;  Colors[11].B = 0;    // Brown.
			Colors[12].R = 0;    Colors[12].G = 220;  Colors[12].B = 220;  // Cyan.
			Colors[13].R = 192;  Colors[13].G = 0;    Colors[13].B = 192;  // Purple.
			Colors[14].R = 150;  Colors[14].G = 150;  Colors[14].B = 150;  // Dark Gray.
			Colors[15].R = 200;  Colors[15].G = 200;  Colors[15].B = 200;  // Gray.
		}
		
		public void add_world(string name, string host, int port)
		
		{
			World w = new World(name, host, port);
			Worlds.Add(w);
		}

		public void remove_world(string name)
		
		{
			for (int i=0; i<Worlds.Count; i++)
		  
			{
				World w = (World) Worlds[i];
				if (w.name == name) Worlds.RemoveAt(i);
			}
		}
		
		public int get_num_worlds()
		
		{
			int n = Worlds.Count;
			return n;
		}
		
		public World get_world(int n)
		
		{
			World w = (World) Worlds[n];
			return w;
		}
	}
}
