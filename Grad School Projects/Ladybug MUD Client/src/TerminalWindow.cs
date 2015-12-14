using System;
using System.Collections;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace MUD
{ 
	public enum RtfColor

	{
		Black, Maroon, Green, Olive, Navy, Purple, Teal, Gray, Silver,
		Red, Lime, Yellow, Blue, Fuchsia, Aqua, White, Cyan
	}

	public class TerminalWindow : RichTextBox

	{
		private struct RtfFontFamilyDef

		{
			public const string Unknown   = @"\fnil";
			public const string Roman     = @"\froman";
			public const string Swiss     = @"\fswiss";
			public const string Modern    = @"\fmodern";
			public const string Script    = @"\fscript";
			public const string Decor     = @"\fdecor";
			public const string Technical = @"\ftech";
			public const string BiDirect  = @"\fbidi";
		}

		private const string FF_UNKNOWN        = "UNKNOWN";
		private const string RTF_HEADER        = @"{\rtf1\ansi\ansicpg1252\deff0\deflang1033";
		private const string RTF_DOCUMENT_PRE  = @"\viewkind4\uc1\pard\cf1\f0\fs20";
		private const string RTF_DOCUMENT_POST = @"\cf0\fs17}";

		private HybridDictionary rtfFontFamily;
		private char lastChar;
		private bool inEscMode;
		private string EscCodeBuff;
		private string lineBuff;
		private ArrayList rtfBuffer;
		private int maxLines;
		private StreamWriter logFile;
		private string command;
		private bool ANSI_MODE;
		private bool LOGGING;
		
		public RGB_Color [] Colors;
		public RGB_Color currentForeColor;
		public RGB_Color currentBackColor;
		public RGB_Color EchoColor;
		
		private action_list AC_ptr;
		private alias_list AL_ptr;
		private MudConnection mudConnection;
		private string[] macro_ptr;
    
		public TerminalWindow(RGB_Color[] colors, alias_list al, action_list ac, bool ansi, string[] macros) : base()

		{
			AC_ptr = ac;
			AL_ptr = al;
			ANSI_MODE = ansi;
			LOGGING = false;
			Colors = colors;
			macro_ptr = macros;
		  
			lastChar    = ' ';
			inEscMode   = false;
			EscCodeBuff = "";
			lineBuff    = "";
			rtfBuffer   = new ArrayList();
			maxLines    = 100;
			command		= "";
			
			EchoColor = new RGB_Color();
			EchoColor.R = 255;
			EchoColor.G = 255;
			EchoColor.B = 255;
      
			currentForeColor = new RGB_Color();
			currentBackColor = new RGB_Color();
      
			currentForeColor = Colors[1]; // White.
			currentBackColor = Colors[0]; // Black.
      
			this.BackColor = Color.Black;
			this.ForeColor = Color.White;
			this.Location  = new Point(0, 0);
			this.Name      = "terminalWindow";
			this.Size      = new Size(700, 500);
			this.TabIndex  = 0;
			this.Text      = "";
			this.Multiline = true;
			this.ReadOnly  = true;
			this.Font      = new Font("Courier New", 10);
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.KeyDown += new KeyEventHandler(TerminalWindow_KeyDown);
			this.UpdateStyles();

			rtfFontFamily = new HybridDictionary();
			rtfFontFamily.Add(FontFamily.GenericMonospace.Name, RtfFontFamilyDef.Modern);
			rtfFontFamily.Add(FontFamily.GenericSansSerif, RtfFontFamilyDef.Swiss);
			rtfFontFamily.Add(FontFamily.GenericSerif, RtfFontFamilyDef.Roman);
			rtfFontFamily.Add(FF_UNKNOWN, RtfFontFamilyDef.Unknown);
		}

		// Add text to the window with parsing
		public void addText(string s)

		{ 
			string formatted_text = "";
		  
			if (!ANSI_MODE) formatted_text = s;
		  
			lock(this)

			{
				string returnValue;
				string output = "";
				int size = s.Length;

				for (int i=0; i<size; i++)

				{
					if (ANSI_MODE) returnValue = parseChar(s[i]);
					else returnValue = Char.ToString(s[i]);

					if (returnValue == "COMPLETE ESC CODE")

					{
					  print_to_screen(output);
						formatted_text = formatted_text + output;
						scrollBottom();
						parseEscCode();
						EscCodeBuff = "";
						output = "";
					}

					else output += returnValue;
				}
				
				formatted_text = formatted_text + output;
				command = "";
				command = AC_ptr.apply_actions(formatted_text);
        
				if (formatted_text.Length > 0)
				
				{
					if (LOGGING)
				  if (logFile != null)
					
					{
					  //logFile.Write(logFile.NewLine);
						while (formatted_text.IndexOf("\r") != -1)
            
						{
							int pos = formatted_text.IndexOf("\r");
							formatted_text = formatted_text.Remove(pos, 1);
						}
            
						while (formatted_text.IndexOf("\n") != -1)
            
						{
							int pos = formatted_text.IndexOf("\n");
							string line = formatted_text.Substring(0, pos);
							formatted_text = formatted_text.Remove(0, pos+1);
              
							logFile.Write(line);
							logFile.Write(logFile.NewLine);
							logFile.Flush();
						}
            
						logFile.Write(formatted_text);
					}
          
					print_to_screen(output);
				}

				syncBuffer();
				scrollBottom();
			}
		}

		void parseEscCode()

		{
			switch(EscCodeBuff)

			{
				case "0m":	currentForeColor = Colors[1]; break;	// Default/White/Clear
				case "0;30m":  currentForeColor = Colors[0];   break;  // Black.
				case "1;37m":  currentForeColor = Colors[1];   break;  // White.
				case "1;31m":  currentForeColor = Colors[2];   break;  // Red.
				case "1;34m":  currentForeColor = Colors[3];   break;  // Green.
				case "1;32m":  currentForeColor = Colors[4];   break;  // Blue.
				case "1;33m":  currentForeColor = Colors[5];   break;  // Yellow.
				case "0;36m":  currentForeColor = Colors[6];   break;  // Cyan.
				case "1;35m":  currentForeColor = Colors[7];   break;  // Magenta.
				case "0;31m":  currentForeColor = Colors[8];   break;  // Dark Red.
				case "0;32m":  currentForeColor = Colors[9];   break;  // Dark Green.
				case "0;34m":  currentForeColor = Colors[10];  break;  // Dark Blue.
				case "0;33m":  currentForeColor = Colors[11];  break;  // Brown.
				case "1;36m":  currentForeColor = Colors[12];  break;  // Dark Cyan.
				case "0;35m":  currentForeColor = Colors[13];  break;  // Purple.
				case "1;30m":  currentForeColor = Colors[14];  break;  // Gray.
				case "0;37m":  currentForeColor = Colors[15];  break;  // Dark Gray.
			}
		}

		// Add text to the window with no parsing
		public void addTextDirectly(string s)

		{
			lock(this)

			{
				appendTextAsRtf(s + '\n', this.Font, EchoColor, currentBackColor);
				syncBuffer();
				scrollBottom();
			}
		}

		// Parse character c to check whether it's a esc code, if so build
		// escape code string
		private string parseChar(char c)

		{
			if (inEscMode)
				return addEscapeModeChar(c);

			else if (lastChar == '\x1B' && c == '[')

			{
				inEscMode = true;
				return "";
			}

			else if (c == '\n')

			{
				// Check for triggers I guess
				lineBuff = "";
			}

			lastChar = c;

			if (c != '\x1B')
				return Char.ToString(c);

			return "";
		}

		// Add c to the escape code buffer and check if the string is complete
		private string addEscapeModeChar(char c)

		{
			EscCodeBuff += c;

			if (Char.IsLetter(c))

			{
				inEscMode = false;
				lastChar = ' ';
				return "COMPLETE ESC CODE";
			}

			return "";
		}

		// Append RTF text to the end of the window
		private void appendTextAsRtf(string str, Font f, RGB_Color foreColor, RGB_Color backColor)

		{
			this.Select(this.TextLength, 0);
			insertTextAsRtf(str, f, foreColor, backColor);
		}
		
		private void print_to_screen(string output)
		
		{
		  string total_output = output;
		  
		  while (output.IndexOf("\n") != -1)
		  
		  {
		    int pos = output.IndexOf("\n");
		    string s1 = output.Substring(0, pos);
		    output = output.Remove(0, pos+1);
		    try_apply_actions(s1);
		  }
		  
		  try_apply_actions(output);
		  
		  appendTextAsRtf(total_output, this.Font, currentForeColor, currentBackColor);
		}

    private void try_apply_actions(string str)
    
    {
      string command = AC_ptr.apply_actions(str);
		    
      if (command != "")		    
      
      {
        command = AL_ptr.apply_aliasing(command);
        addTextDirectly(command);
        mudConnection.sendText(command);
      }
    }
  
		// Insert RTF text into the window at the current cursor position and store it in the rtfBuffer
		private void insertTextAsRtf(string str, Font f, RGB_Color foreColor, RGB_Color backColor)

		{
			StringBuilder s = new StringBuilder();

			s.Append(RTF_HEADER);
			s.Append(getFontTable(f));
			s.Append(getColorTable(foreColor, backColor));
			s.Append(getDocumentArea(str, f));

			rtfBuffer.Add(s.ToString());
		}

		// Update this RichTextBox from the rtfBuffer
		private void syncBuffer()

		{
			// Do RTF text processing in memory
			RichTextBox temp = new RichTextBox();

			for (int i=0; i<rtfBuffer.Count; i++)
				temp.SelectedRtf = (string)rtfBuffer[i];
			
			// Update the text in the window
			this.Select(this.TextLength, 0);
			this.SelectedRtf = temp.Rtf.Substring(0, temp.Rtf.Length-6);
			rtfBuffer.Clear();
		}

		// Create a RTF document from the string str
		private string getDocumentArea(string str, Font f)

		{
			StringBuilder doc = new StringBuilder();

			doc.Append(RTF_DOCUMENT_PRE);
			doc.Append(@"\highlight2");

			if (f.Bold)      doc.Append(@"\b");
			if (f.Italic)    doc.Append(@"\i");
			if (f.Strikeout) doc.Append(@"\strike");
			if (f.Underline) doc.Append(@"\ul");

			doc.Append(@"\f0");
			doc.Append(@"\fs");
			doc.Append((int)Math.Round((2 * f.SizeInPoints)));
			doc.Append(@" ");
			doc.Append(str.Replace("\n", @"\par "));
			doc.Append(@"\highlight0");

			if (f.Bold)      doc.Append(@"\b0");
			if (f.Italic)    doc.Append(@"\i0");
			if (f.Strikeout) doc.Append(@"\strike0");
			if (f.Underline) doc.Append(@"\ulnone");

			doc.Append(@"\f0");
			doc.Append(@"\fs20");
			doc.Append(RTF_DOCUMENT_POST);

			return doc.ToString();
		}

		// Create a RTF font table
		private string getFontTable(Font f)

		{
			StringBuilder fontTable = new StringBuilder();

			fontTable.Append(@"{\fonttbl{\f0");

			if (rtfFontFamily.Contains(f.FontFamily.Name))
				fontTable.Append(rtfFontFamily[f.FontFamily.Name]);
			else
				fontTable.Append(rtfFontFamily[FF_UNKNOWN]);

			fontTable.Append(@"\fcharset0 ");
			fontTable.Append(f.Name);
			fontTable.Append(@";}}");

			return fontTable.ToString();
		}

		// Create a RTF color table
		private string getColorTable(RGB_Color f, RGB_Color b)

		{
			StringBuilder colorTable = new StringBuilder();

			string Foreground = "\\red" + f.R + "\\green" + f.G + "\\blue" + f.B;
			string Background = "\\red" + b.R + "\\green" + b.G + "\\blue" + b.B;
      
			colorTable.Append(@"{\colortbl ;");
			colorTable.Append(Foreground);
			colorTable.Append(@";");
			colorTable.Append(Background);
			colorTable.Append(@";}\n");

			return colorTable.ToString();
		}

		// Send this RichTextBox the message to scroll to the bottom
		private void scrollBottom()

		{
			Message msg = Message.Create(Handle, 0x0115, (IntPtr)7, IntPtr.Zero );
			WndProc(ref msg);
		}
		
		public void setConnection(MudConnection mc)
    
		{
			mudConnection = mc;    
		}
		
		public void set_AC(action_list ac)
		
		{
			AC_ptr = ac;
		}
    
		public void set_AL(alias_list al)
		{
			AL_ptr = al;
		}

		public void set_ANSI(bool ansi)
    
		{
			ANSI_MODE = ansi;
		}
    
		public void set_log(bool logging, StreamWriter file)
    
		{
			LOGGING = logging;
			this.logFile = file;
		}
		
		public void set_colors(RGB_Color[] colors)
		
		{
			Colors = colors;
		}

		public void set_macros(string[] macros)
		{
			this.macro_ptr = macros;
		}

		private void TerminalWindow_KeyDown(object sender, KeyEventArgs e)
		{
			if (mudConnection != null)
			{
				switch(e.KeyCode)
				{
					case Keys.F1:
						if (macro_ptr[0] != "")
						{
							string str = this.AL_ptr.apply_aliasing(macro_ptr[0]);
						
							while (str.IndexOf(";;") != -1)

							{
								int pos = str.IndexOf(";;");
								string first_command = str.Substring(0, pos);
								str = str.Substring(pos+2, str.Length-pos-2);
								this.addTextDirectly(first_command);
								mudConnection.sendText(first_command);
							}
						
							this.addTextDirectly(str);
							mudConnection.sendText(str);
						}
						break;
					case Keys.F2:
						if (macro_ptr[1] != "")
						{
							string str = this.AL_ptr.apply_aliasing(macro_ptr[1]);
						
							while (str.IndexOf(";;") != -1)

							{
								int pos = str.IndexOf(";;");
								string first_command = str.Substring(0, pos);
								str = str.Substring(pos+2, str.Length-pos-2);
								this.addTextDirectly(first_command);
								mudConnection.sendText(first_command);
							}

							this.addTextDirectly(str);
							mudConnection.sendText(str);
						}
						break;
					case Keys.F3:
						if (macro_ptr[2] != "")
						{
							string str = this.AL_ptr.apply_aliasing(macro_ptr[2]);
						
							while (str.IndexOf(";;") != -1)

							{
								int pos = str.IndexOf(";;");
								string first_command = str.Substring(0, pos);
								str = str.Substring(pos+2, str.Length-pos-2);
								this.addTextDirectly(first_command);
								mudConnection.sendText(first_command);
							}

							this.addTextDirectly(str);
							mudConnection.sendText(str);
						}
						break;
					case Keys.F4:
						if (macro_ptr[3] != "")
						{
							string str = this.AL_ptr.apply_aliasing(macro_ptr[3]);
						
							while (str.IndexOf(";;") != -1)

							{
								int pos = str.IndexOf(";;");
								string first_command = str.Substring(0, pos);
								str = str.Substring(pos+2, str.Length-pos-2);
								this.addTextDirectly(first_command);
								mudConnection.sendText(first_command);
							}

							this.addTextDirectly(str);
							mudConnection.sendText(str);
						}
						break;
					case Keys.F5:
						if (macro_ptr[4] != "")
						{
							string str = this.AL_ptr.apply_aliasing(macro_ptr[4]);
						
							while (str.IndexOf(";;") != -1)

							{
								int pos = str.IndexOf(";;");
								string first_command = str.Substring(0, pos);
								str = str.Substring(pos+2, str.Length-pos-2);
								this.addTextDirectly(first_command);
								mudConnection.sendText(first_command);
							}

							this.addTextDirectly(str);
							mudConnection.sendText(str);
						}
						break;
					case Keys.F6:
						if (macro_ptr[5] != "")
						{
							string str = this.AL_ptr.apply_aliasing(macro_ptr[5]);
						
							while (str.IndexOf(";;") != -1)

							{
								int pos = str.IndexOf(";;");
								string first_command = str.Substring(0, pos);
								str = str.Substring(pos+2, str.Length-pos-2);
								this.addTextDirectly(first_command);
								mudConnection.sendText(first_command);
							}

							this.addTextDirectly(str);
							mudConnection.sendText(str);
						}
						break;
					case Keys.F7:
						if (macro_ptr[6] != "")
						{
							string str = this.AL_ptr.apply_aliasing(macro_ptr[6]);
						
							while (str.IndexOf(";;") != -1)

							{
								int pos = str.IndexOf(";;");
								string first_command = str.Substring(0, pos);
								str = str.Substring(pos+2, str.Length-pos-2);
								this.addTextDirectly(first_command);
								mudConnection.sendText(first_command);
							}

							this.addTextDirectly(str);
							mudConnection.sendText(str);
						}
						break;
					case Keys.F8:
						if (macro_ptr[7] != "")
						{
							string str = this.AL_ptr.apply_aliasing(macro_ptr[7]);
						
							while (str.IndexOf(";;") != -1)

							{
								int pos = str.IndexOf(";;");
								string first_command = str.Substring(0, pos);
								str = str.Substring(pos+2, str.Length-pos-2);
								this.addTextDirectly(first_command);
								mudConnection.sendText(first_command);
							}

							this.addTextDirectly(str);
							mudConnection.sendText(str);
						}
						break;
					case Keys.F9:
						if (macro_ptr[8] != "")
						{
							string str = this.AL_ptr.apply_aliasing(macro_ptr[8]);
						
							while (str.IndexOf(";;") != -1)

							{
								int pos = str.IndexOf(";;");
								string first_command = str.Substring(0, pos);
								str = str.Substring(pos+2, str.Length-pos-2);
								this.addTextDirectly(first_command);
								mudConnection.sendText(first_command);
							}

							this.addTextDirectly(str);
							mudConnection.sendText(str);
						}
						break;
					case Keys.F10:
						if (macro_ptr[9] != "")
						{
							string str = this.AL_ptr.apply_aliasing(macro_ptr[9]);
						
							while (str.IndexOf(";;") != -1)

							{
								int pos = str.IndexOf(";;");
								string first_command = str.Substring(0, pos);
								str = str.Substring(pos+2, str.Length-pos-2);
								this.addTextDirectly(first_command);
								mudConnection.sendText(first_command);
							}

							this.addTextDirectly(str);
							mudConnection.sendText(str);
						}
						break;
				}
			}
		}
	}
}