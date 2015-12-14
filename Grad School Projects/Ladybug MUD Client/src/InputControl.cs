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
	public class InputControl : RichTextBox

	{
		private MudConnection mudConnection;
		private TerminalWindow terminalWindow;
		private bool is_command;
		private string command;
		private string[] history;
		private int placeholder;
		private bool firstInput;
		private alias_list AL_ptr;
		private action_list AC_ptr;
		private string[] macro_ptr;

		public void setConnection(MudConnection mc)
    
		{
			mudConnection = mc;    
		}
    
		public void set_AL(alias_list al)
		
		{
			AL_ptr = al;
		}
    
		public void set_AC(action_list ac)
		
		{
			AC_ptr = ac;
		}

		public void set_Macro(string[] macro)
		{
			this.macro_ptr = macro;
		}
    
		public InputControl(TerminalWindow tw, alias_list alias, action_list action, string[] macros) : base()

		{
			terminalWindow = tw;
			AL_ptr = alias;
			AC_ptr = action;
			history = new string[100];
			placeholder = 0;
			firstInput = true;
			macro_ptr = macros;
      
			this.BackColor = Color.Black;
			this.ForeColor = Color.White;
			this.Location  = new Point(0, 0);
			this.Name      = "inputControl";
			this.Size      = new Size(700, 22);
			this.TabIndex  = 0;
			this.Text      = "";
			this.Font      = new Font("Courier New", 10);
			this.KeyDown   += new KeyEventHandler(keyDown);
			this.Multiline = false;
		}
    
		// Event that checks for a return key push
		public void keyDown(object sender, KeyEventArgs e)

		{
			if (mudConnection != null)
			{
				switch(e.KeyCode)
				{
					case Keys.Enter:
						String s = "";
						if (firstInput)
						{
							s = this.Text;
							firstInput = false;
						}
						else
						{
							if (this.Text.Length > 0)
								s = this.Text.Remove(0,1);
						}
					
						s = parser(s);
					
						addToHistory(s);
						placeholder = 0;

						if (is_command)
							switch(command)

							{
								case "alias":     terminalWindow.addTextDirectly("\n" + AL_ptr.try_add_alias(s));      break;
								case "unalias":   terminalWindow.addTextDirectly("\n" + AL_ptr.try_remove_alias(s));   break;
								case "action":    terminalWindow.addTextDirectly("\n" + AC_ptr.try_add_action(s));     break;
								case "unaction":  terminalWindow.addTextDirectly("\n" + AC_ptr.try_remove_action(s));  break;
								default:          terminalWindow.addTextDirectly("\nInvalid Command.");                break;
							}

						else if (!is_command)
          
						{
							s = AL_ptr.apply_aliasing(s);
					  
							if (s == "") s = "\n";

							while (s.IndexOf(";;") != -1)

							{
								int pos = s.IndexOf(";;");
								string first_command = s.Substring(0, pos);
								s = s.Substring(pos+2, s.Length-pos-2);
								terminalWindow.addTextDirectly(first_command);
								mudConnection.sendText(first_command);
							}
            
							terminalWindow.addTextDirectly(s);
							mudConnection.sendText(s);
						}
					
						this.Text = "";
						break;
					case Keys.Up:
						if (placeholder < 100)
						{
							firstInput = true;
							if (history[placeholder] != null)
							{
								this.Text = history[placeholder];
								placeholder++;
							}
						}
						break;
					case Keys.Down:
						if (placeholder > 0)
						{
							firstInput = true;
							if (history[--placeholder] != null)
							{
								this.Text = history[placeholder];
							}
						}
						break;
					case Keys.F1:
						if (macro_ptr[0] != "")
						{
							string str = this.AL_ptr.apply_aliasing(macro_ptr[0]);
						
							while (str.IndexOf(";;") != -1)

							{
								int pos = str.IndexOf(";;");
								string first_command = str.Substring(0, pos);
								str = str.Substring(pos+2, str.Length-pos-2);
								terminalWindow.addTextDirectly(first_command);
								mudConnection.sendText(first_command);
							}
						
							terminalWindow.addTextDirectly(str);
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
								terminalWindow.addTextDirectly(first_command);
								mudConnection.sendText(first_command);
							}

							terminalWindow.addTextDirectly(str);
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
								terminalWindow.addTextDirectly(first_command);
								mudConnection.sendText(first_command);
							}

							terminalWindow.addTextDirectly(str);
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
								terminalWindow.addTextDirectly(first_command);
								mudConnection.sendText(first_command);
							}

							terminalWindow.addTextDirectly(str);
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
								terminalWindow.addTextDirectly(first_command);
								mudConnection.sendText(first_command);
							}

							terminalWindow.addTextDirectly(str);
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
								terminalWindow.addTextDirectly(first_command);
								mudConnection.sendText(first_command);
							}

							terminalWindow.addTextDirectly(str);
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
								terminalWindow.addTextDirectly(first_command);
								mudConnection.sendText(first_command);
							}

							terminalWindow.addTextDirectly(str);
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
								terminalWindow.addTextDirectly(first_command);
								mudConnection.sendText(first_command);
							}

							terminalWindow.addTextDirectly(str);
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
								terminalWindow.addTextDirectly(first_command);
								mudConnection.sendText(first_command);
							}

							terminalWindow.addTextDirectly(str);
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
								terminalWindow.addTextDirectly(first_command);
								mudConnection.sendText(first_command);
							}

							terminalWindow.addTextDirectly(str);
							mudConnection.sendText(str);
						}
						break;
				}
			}
		}

		private string parser(string s)

		{
			command = "";
			is_command = false;

			s = s.TrimStart(' ');

			if (s.Length > 0)
				if (s[0] == '#')

				{
					is_command = true;

					s = s.Remove(0,1);
					int pos = s.IndexOf(" ");

					if (pos == -1) 
					{
						command = s;
						s = ""; 
					}

					else 
					{
						command = s.Substring(0,pos);
						s = s.Substring(pos+1, s.Length-pos-1); 
					}

					s = s.TrimStart(' ');
				}

			return s;
		}

		private void addToHistory(string s)
		{
			for (int i = 99; i > 0; i--)
			{
				if (history[i-1] != null)
					history[i] = history[i-1];
			}
			history[0] = s;
		}
	}
}