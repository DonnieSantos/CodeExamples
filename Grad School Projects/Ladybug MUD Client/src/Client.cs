using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.IO;

namespace MUD
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Client : System.Windows.Forms.Form
	
	{
		#region GUI element declarations
		//private System.Windows.Forms.TextBox input;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.Button connectButton;
		private System.Windows.Forms.Button disconnectButton;
		private System.Windows.Forms.Button aliasButton;
		private System.Windows.Forms.Button macroButton;
		private System.Windows.Forms.Button triggerButton;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.MenuItem menuFile;
		private System.Windows.Forms.MenuItem menuLog;
		private System.Windows.Forms.MenuItem menuStopLog;
		private System.Windows.Forms.MenuItem menuConnect;
		private System.Windows.Forms.MenuItem menuDisconnect;
		private System.Windows.Forms.MenuItem menuSave;
		private System.Windows.Forms.MenuItem menuLoad;
		private System.Windows.Forms.MenuItem menuExit;
		private System.Windows.Forms.MenuItem menuEdit;
		private System.Windows.Forms.MenuItem menuAliases;
		private System.Windows.Forms.MenuItem menuMacros;
		private System.Windows.Forms.MenuItem menuTriggers;
		private System.Windows.Forms.MenuItem menuView;
		private System.Windows.Forms.MenuItem menuStatusbar;
		private System.Windows.Forms.MenuItem menuMacrobar;
		private System.Windows.Forms.MenuItem menuColor;
		private System.Windows.Forms.MenuItem menuHelp;
		private System.Windows.Forms.MenuItem menuAbout;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.ToolBar toolbar1;
		private System.Windows.Forms.Panel macroPanel;
		private System.Windows.Forms.Button macro3;
		private System.Windows.Forms.Button macro2;
		private System.Windows.Forms.Button macro7;
		private System.Windows.Forms.Button macro6;
		private System.Windows.Forms.Label macroLabel;
		private System.Windows.Forms.Button macro10;
		private System.Windows.Forms.Button macro5;
		private System.Windows.Forms.Button macro1;
		private System.Windows.Forms.Button macro9;
		private System.Windows.Forms.Button macro4;
		private System.Windows.Forms.Button macro8;
		private System.Windows.Forms.Button emulationButton;
		private System.ComponentModel.Container components = null;
		#endregion
	  
		private TcpClient theConnection;
		private MUD.TerminalWindow theTerminalWindow;
		private MUD.InputControl theInputControl;
		private MudConnection theMudConnection;
		private StreamWriter logFile;
		private Profile current_profile;
		private bool ANSI_MODE = true;
		
		public Client()
		
		{
			current_profile = new Profile();
			theConnection = new TcpClient();
		  
			theTerminalWindow = new MUD.TerminalWindow(current_profile.Colors, current_profile.AL, current_profile.AC, ANSI_MODE, current_profile.macros);
			theInputControl = new MUD.InputControl(theTerminalWindow, current_profile.AL, current_profile.AC, current_profile.macros);
        
			InitializeComponent();
		}

		protected override void Dispose(bool disposing)
		
		{
			if (disposing)
				if (components != null) 
					components.Dispose();
					
			base.Dispose(disposing);
		}


		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuFile = new System.Windows.Forms.MenuItem();
			this.menuLog = new System.Windows.Forms.MenuItem();
			this.menuStopLog = new System.Windows.Forms.MenuItem();
			this.menuConnect = new System.Windows.Forms.MenuItem();
			this.menuDisconnect = new System.Windows.Forms.MenuItem();
			this.menuSave = new System.Windows.Forms.MenuItem();
			this.menuLoad = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem16 = new System.Windows.Forms.MenuItem();
			this.menuExit = new System.Windows.Forms.MenuItem();
			this.menuEdit = new System.Windows.Forms.MenuItem();
			this.menuItem15 = new System.Windows.Forms.MenuItem();
			this.menuAliases = new System.Windows.Forms.MenuItem();
			this.menuMacros = new System.Windows.Forms.MenuItem();
			this.menuTriggers = new System.Windows.Forms.MenuItem();
			this.menuView = new System.Windows.Forms.MenuItem();
			this.menuStatusbar = new System.Windows.Forms.MenuItem();
			this.menuMacrobar = new System.Windows.Forms.MenuItem();
			this.menuColor = new System.Windows.Forms.MenuItem();
			this.menuHelp = new System.Windows.Forms.MenuItem();
			this.menuAbout = new System.Windows.Forms.MenuItem();
			this.connectButton = new System.Windows.Forms.Button();
			this.disconnectButton = new System.Windows.Forms.Button();
			this.aliasButton = new System.Windows.Forms.Button();
			this.triggerButton = new System.Windows.Forms.Button();
			this.macroButton = new System.Windows.Forms.Button();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.toolbar1 = new System.Windows.Forms.ToolBar();
			this.macroPanel = new System.Windows.Forms.Panel();
			this.macro3 = new System.Windows.Forms.Button();
			this.macro2 = new System.Windows.Forms.Button();
			this.macro7 = new System.Windows.Forms.Button();
			this.macro6 = new System.Windows.Forms.Button();
			this.macroLabel = new System.Windows.Forms.Label();
			this.macro10 = new System.Windows.Forms.Button();
			this.macro5 = new System.Windows.Forms.Button();
			this.macro1 = new System.Windows.Forms.Button();
			this.macro9 = new System.Windows.Forms.Button();
			this.macro4 = new System.Windows.Forms.Button();
			this.macro8 = new System.Windows.Forms.Button();
			this.emulationButton = new System.Windows.Forms.Button();
			this.macroPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuFile,
																					  this.menuEdit,
																					  this.menuView,
																					  this.menuHelp});
			// 
			// menuFile
			// 
			this.menuFile.Index = 0;
			this.menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuLog,
																					 this.menuStopLog,
																					 this.menuSave,
																					 this.menuLoad,
																					 this.menuItem16,
																					 this.menuConnect,
																					 this.menuDisconnect,
																					 this.menuItem11,
																					 this.menuExit});
			this.menuFile.Text = "File";
			// 
			// menuLog
			// 
			this.menuLog.Index = 0;
			this.menuLog.Text = "Logging...";
			this.menuLog.Click += new EventHandler(menuLog_Click);
			// 
			// menuStopLog
			// 
			this.menuStopLog.Index = 1;
			this.menuStopLog.Text = "Stop Logging";
			this.menuStopLog.Enabled = false;
			this.menuStopLog.Click += new EventHandler(menuStopLog_Click);
			// 
			// menuSave
			// 
			this.menuSave.Index = 2;
			this.menuSave.Text = "Save...";
			this.menuSave.Enabled = true;
			this.menuSave.Click += new EventHandler(menuSave_Click);
			// 
			// menuLoad
			// 
			this.menuLoad.Index = 3;
			this.menuLoad.Text = "Load...";
			this.menuLoad.Enabled = true;
			this.menuLoad.Click += new EventHandler(menuLoad_Click);
			// 
			// menuItem16
			// 
			this.menuItem16.Index = 4;
			this.menuItem16.Text = "-";// 
			// menuConnect
			// 
			this.menuConnect.Index = 5;
			this.menuConnect.Text = "Connect...";
			this.menuConnect.Click += new System.EventHandler(this.menuConnect_Click);
			// 
			// menuDisconnect
			// 
			this.menuDisconnect.Index = 6;
			this.menuDisconnect.Text = "Disconnect...";
			this.menuDisconnect.Enabled = false;
			this.menuDisconnect.Click += new EventHandler(menuDisconnect_Click);
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 7;
			this.menuItem11.Text = "-";
			// 
			// menuExit
			// 
			this.menuExit.Index = 8;
			this.menuExit.Text = "Exit";
			this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
			// 
			// menuEdit
			// 
			this.menuEdit.Index = 1;
			this.menuEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuAliases,
																					 this.menuMacros,
																					 this.menuTriggers,
																					 this.menuColor});
			this.menuEdit.Text = "Edit";
			// 
			// menuAliases
			// 
			this.menuAliases.Index = 0;
			this.menuAliases.Text = "Aliases...";
			this.menuAliases.Click += new System.EventHandler(this.aliasButton_Click);
			// 
			// menuMacros
			// 
			this.menuMacros.Index = 1;
			this.menuMacros.Text = "Macros...";
			this.menuMacros.Click += new System.EventHandler(this.macroButton_Click);
			// 
			// menuTriggers
			// 
			this.menuTriggers.Index = 2;
			this.menuTriggers.Text = "Triggers...";
			this.menuTriggers.Click += new System.EventHandler(this.triggerButton_Click);
			// 
			// menuView
			// 
			this.menuView.Index = 2;
			this.menuView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuStatusbar,
																					 this.menuMacrobar});
			this.menuView.Text = "View";
			// 
			// menuStatusbar
			// 
			this.menuStatusbar.Index = 0;
			this.menuStatusbar.Text = "Status Bar";
			this.menuStatusbar.Click += new System.EventHandler(this.menuStatusbar_Click);
			// 
			// menuMacrobar
			// 
			this.menuMacrobar.Index = 1;
			this.menuMacrobar.Text = "Macros";
			this.menuMacrobar.Click += new System.EventHandler(this.menuMacrobar_Click);
			// 
			// menuColor
			// 
			this.menuColor.Index = 3;
			this.menuColor.Text = "Color...";
			this.menuColor.Click += new EventHandler(this.menuColors_Click);
			// 
			// menuHelp
			// 
			this.menuHelp.Index = 3;
			this.menuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuAbout});
			this.menuHelp.Text = "Help";
			// 
			// menuAbout
			// 
			this.menuAbout.Index = 0;
			this.menuAbout.Text = "About...";
			this.menuAbout.Click += new EventHandler(this.menuAbout_Click);
			// 
			// connectButton
			// 
			this.connectButton.Location = new System.Drawing.Point(8, 8);
			this.connectButton.Name = "connectButton";
			this.connectButton.Size = new System.Drawing.Size(56, 23);
			this.connectButton.TabIndex = 1;
			this.connectButton.Text = "Connect";
			this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
			// 
			// disconnectButton
			// 
			this.disconnectButton.Location = new System.Drawing.Point(64, 8);
			this.disconnectButton.Name = "disconnectButton";
			this.disconnectButton.Size = new System.Drawing.Size(72, 23);
			this.disconnectButton.TabIndex = 2;
			this.disconnectButton.Text = "Disconnect";
			this.disconnectButton.Enabled = false;
			this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
			// 
			// aliasButton
			// 
			this.aliasButton.Location = new System.Drawing.Point(144, 8);
			this.aliasButton.Name = "aliasButton";
			this.aliasButton.Size = new System.Drawing.Size(56, 23);
			this.aliasButton.TabIndex = 3;
			this.aliasButton.Text = "Aliases";
			this.aliasButton.Click += new System.EventHandler(this.aliasButton_Click);
			// 
			// triggerButton
			// 
			this.triggerButton.Location = new System.Drawing.Point(256, 8);
			this.triggerButton.Name = "triggerButton";
			this.triggerButton.Size = new System.Drawing.Size(56, 23);
			this.triggerButton.TabIndex = 5;
			this.triggerButton.Text = "Triggers";
			this.triggerButton.Click += new System.EventHandler(this.triggerButton_Click);
			// 
			// macroButton
			// 
			this.macroButton.Location = new System.Drawing.Point(200, 8);
			this.macroButton.Name = "macroButton";
			this.macroButton.Size = new System.Drawing.Size(56, 23);
			this.macroButton.TabIndex = 4;
			this.macroButton.Text = "Macros";
			this.macroButton.Click += new System.EventHandler(this.macroButton_Click);
			// 
			// statusBar1
			// 
			this.statusBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.statusBar1.Dock = System.Windows.Forms.DockStyle.None;
			this.statusBar1.Location = new System.Drawing.Point(0, 703);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(872, 22);
			this.statusBar1.TabIndex = 19;
			this.statusBar1.Text = "Not connected.";
			// 
			// toolbar1
			// 
			this.toolbar1.DropDownArrows = true;
			this.toolbar1.Location = new System.Drawing.Point(0, 0);
			this.toolbar1.Name = "toolbar1";
			this.toolbar1.ShowToolTips = true;
			this.toolbar1.Size = new System.Drawing.Size(872, 42);
			this.toolbar1.TabIndex = 3;
			// 
			// macroPanel
			// 
			this.macroPanel.Controls.Add(this.macro3);
			this.macroPanel.Controls.Add(this.macro2);
			this.macroPanel.Controls.Add(this.macro7);
			this.macroPanel.Controls.Add(this.macro6);
			this.macroPanel.Controls.Add(this.macroLabel);
			this.macroPanel.Controls.Add(this.macro10);
			this.macroPanel.Controls.Add(this.macro5);
			this.macroPanel.Controls.Add(this.macro1);
			this.macroPanel.Controls.Add(this.macro9);
			this.macroPanel.Controls.Add(this.macro4);
			this.macroPanel.Controls.Add(this.macro8);
			this.macroPanel.Location = new System.Drawing.Point(0, 40);
			this.macroPanel.Name = "macroPanel";
			this.macroPanel.Size = new System.Drawing.Size(152, 184);
			this.macroPanel.TabIndex = 0;
			// 
			// macro3
			// 
			this.macro3.Location = new System.Drawing.Point(8, 56);
			this.macro3.Name = "macro3";
			this.macro3.Size = new System.Drawing.Size(64, 23);
			this.macro3.TabIndex = 8;
			this.macro3.Text = "F3";
			this.macro3.Click += new System.EventHandler(this.macro_Click);
			// 
			// macro2
			// 
			this.macro2.Location = new System.Drawing.Point(80, 24);
			this.macro2.Name = "macro2";
			this.macro2.Size = new System.Drawing.Size(64, 23);
			this.macro2.TabIndex = 7;
			this.macro2.Text = "F2";
			this.macro2.Click += new System.EventHandler(this.macro_Click);
			// 
			// macro7
			// 
			this.macro7.Location = new System.Drawing.Point(8, 120);
			this.macro7.Name = "macro7";
			this.macro7.Size = new System.Drawing.Size(64, 23);
			this.macro7.TabIndex = 12;
			this.macro7.Text = "F7";
			this.macro7.Click += new System.EventHandler(this.macro_Click);
			// 
			// macro6
			// 
			this.macro6.Location = new System.Drawing.Point(80, 88);
			this.macro6.Name = "macro6";
			this.macro6.Size = new System.Drawing.Size(64, 23);
			this.macro6.TabIndex = 11;
			this.macro6.Text = "F6";
			this.macro6.Click += new System.EventHandler(this.macro_Click);
			// 
			// macroLabel
			// 
			this.macroLabel.Location = new System.Drawing.Point(48, 8);
			this.macroLabel.Name = "macroLabel";
			this.macroLabel.Size = new System.Drawing.Size(56, 16);
			this.macroLabel.TabIndex = 0;
			this.macroLabel.Text = "Macros";
			this.macroLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// macro10
			// 
			this.macro10.Location = new System.Drawing.Point(80, 152);
			this.macro10.Name = "macro10";
			this.macro10.Size = new System.Drawing.Size(64, 23);
			this.macro10.TabIndex = 15;
			this.macro10.Text = "F10";
			this.macro10.Click += new System.EventHandler(this.macro_Click);
			// 
			// macro5
			// 
			this.macro5.Location = new System.Drawing.Point(8, 88);
			this.macro5.Name = "macro5";
			this.macro5.Size = new System.Drawing.Size(64, 23);
			this.macro5.TabIndex = 10;
			this.macro5.Text = "F5";
			this.macro5.Click += new System.EventHandler(this.macro_Click);
			// 
			// macro1
			// 
			this.macro1.Location = new System.Drawing.Point(8, 24);
			this.macro1.Name = "macro1";
			this.macro1.Size = new System.Drawing.Size(64, 23);
			this.macro1.TabIndex = 6;
			this.macro1.Text = "F1";
			this.macro1.Click += new System.EventHandler(this.macro_Click);
			// 
			// macro9
			// 
			this.macro9.Location = new System.Drawing.Point(8, 152);
			this.macro9.Name = "macro9";
			this.macro9.Size = new System.Drawing.Size(64, 23);
			this.macro9.TabIndex = 14;
			this.macro9.Text = "F9";
			this.macro9.Click += new System.EventHandler(this.macro_Click);
			// 
			// macro4
			// 
			this.macro4.Location = new System.Drawing.Point(80, 56);
			this.macro4.Name = "macro4";
			this.macro4.Size = new System.Drawing.Size(64, 23);
			this.macro4.TabIndex = 9;
			this.macro4.Text = "F4";
			this.macro4.Click += new System.EventHandler(this.macro_Click);
			// 
			// macro8
			// 
			this.macro8.Location = new System.Drawing.Point(80, 120);
			this.macro8.Name = "macro8";
			this.macro8.Size = new System.Drawing.Size(64, 23);
			this.macro8.TabIndex = 13;
			this.macro8.Text = "F8";
			this.macro8.Click += new System.EventHandler(this.macro_Click);
			// 
			// theTerminalWindow
			// 
			this.theTerminalWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.theTerminalWindow.BackColor = System.Drawing.Color.Black;
			this.theTerminalWindow.ForeColor = System.Drawing.Color.Green;
			this.theTerminalWindow.Location = new System.Drawing.Point(160, 48);
			this.theTerminalWindow.Name = "theTerminalWindow";
			this.theTerminalWindow.Size = new System.Drawing.Size(696, 432);
			this.theTerminalWindow.TabIndex = 16;
			// 
			// theInputControl
			// 
			this.theInputControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.theInputControl.Location = new System.Drawing.Point(160, 488);
			this.theInputControl.Multiline = true;
			this.theInputControl.Name = "input";
			this.theInputControl.Size = new System.Drawing.Size(696, 20);
			this.theInputControl.TabIndex = 17;
			this.theInputControl.Text = "";
			this.theInputControl.ScrollBars = RichTextBoxScrollBars.None;
			// 
			// emulationButton
			// 
			this.emulationButton.Location = new System.Drawing.Point(352, 8);
			this.emulationButton.Name = "emulationButton";
			this.emulationButton.Size = new System.Drawing.Size(136, 23);
			this.emulationButton.TabIndex = 20;
			this.emulationButton.Text = "Toggle ANSI Emulation";
			this.emulationButton.Click +=new EventHandler(emulationButton_Click);
			// 
			// Client
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(872, 537);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.emulationButton);
			this.Controls.Add(this.theInputControl);
			this.Controls.Add(this.theTerminalWindow);
			this.Controls.Add(this.triggerButton);
			this.Controls.Add(this.macroButton);
			this.Controls.Add(this.aliasButton);
			this.Controls.Add(this.disconnectButton);
			this.Controls.Add(this.connectButton);
			this.Controls.Add(this.toolbar1);
			this.Controls.Add(this.macroPanel);
			this.ForeColor = System.Drawing.Color.Black;
			this.Menu = this.mainMenu1;
			this.Name = "Client";
			this.Text = "Ladybug MUD Client";
			this.Closing +=new CancelEventHandler(Client_Closing);
			this.macroPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Splash newSplash = new Splash();
			newSplash.StartPosition = FormStartPosition.CenterScreen;
			newSplash.Show();
			Thread.Sleep(new TimeSpan(0, 0, 3));
			newSplash.Close();
			
			Application.Run(new Client());
		}

		private void macroButton_Click(object sender, System.EventArgs e)
		{
			Macros md = new Macros(current_profile.macros);
			md.macroText1.Text = current_profile.macros[0];
			md.macroText2.Text = current_profile.macros[1];
			md.macroText3.Text = current_profile.macros[2];
			md.macroText4.Text = current_profile.macros[3];
			md.macroText5.Text = current_profile.macros[4];
			md.macroText6.Text = current_profile.macros[5];
			md.macroText7.Text = current_profile.macros[6];
			md.macroText8.Text = current_profile.macros[7];
			md.macroText9.Text = current_profile.macros[8];
			md.macroText10.Text = current_profile.macros[9];
			md.ShowDialog();
			this.theInputControl.Focus();
		}

		private void aliasButton_Click(object sender, System.EventArgs e)
		{
			new Aliases(this.current_profile.AL).ShowDialog();
			this.theInputControl.Focus();
		}

		private void triggerButton_Click(object sender, System.EventArgs e)
		{
			new Triggers(this.current_profile.AC).ShowDialog();
			this.theInputControl.Focus();
		}

		private void connectButton_Click(object sender, System.EventArgs e)
		
		{
			Connect cd = new Connect(this.current_profile);
			cd.ShowDialog();

			if (cd.get_connect())
			
			{
				theMudConnection = new MudConnection(theTerminalWindow, cd.get_hostaddress(), cd.get_port());
				theMudConnection.connect();
				theInputControl.setConnection(theMudConnection);
				
				theTerminalWindow.setConnection(theMudConnection);
				theInputControl.setConnection(theMudConnection);

				this.menuDisconnect.Enabled = true;
				this.disconnectButton.Enabled = true;
				this.menuConnect.Enabled = false;
				this.connectButton.Enabled = false;
			}
			this.theInputControl.Focus();
		}

		private void menuExit_Click(object sender, System.EventArgs e)
		
		{
			if (theMudConnection != null)
				theMudConnection.disconnect();
			this.Close();
		}

		private void menuConnect_Click(object sender, System.EventArgs e)
		{
			this.connectButton_Click(sender, e);
		}

		private void menuStatusbar_Click(object sender, System.EventArgs e)
		{
			statusBar1.Visible = !statusBar1.Visible;
			this.theInputControl.Focus();
		}

		private void menuMacrobar_Click(object sender, System.EventArgs e)
		{
			if (macroPanel.Visible)
			{
				macroPanel.Visible = false;
				int width = theTerminalWindow.Size.Width + macroPanel.Size.Width;
				int x = theTerminalWindow.Location.X - macroPanel.Size.Width;
				theTerminalWindow.Size = new Size(width, theTerminalWindow.Size.Height);
				theTerminalWindow.Location = new Point(x, theTerminalWindow.Location.Y);
				width = theInputControl.Size.Width + macroPanel.Size.Width;
				x = theInputControl.Location.X - macroPanel.Size.Width;
				theInputControl.Size = new Size(width, theInputControl.Size.Height);
				theInputControl.Location = new Point(x, theInputControl.Location.Y);
			}
			else
			{
				macroPanel.Visible = true;
				int width = theTerminalWindow.Size.Width - macroPanel.Size.Width;
				int x = theTerminalWindow.Location.X + macroPanel.Size.Width;
				theTerminalWindow.Location = new Point(x, theTerminalWindow.Location.Y);
				theTerminalWindow.Size = new Size(width, theTerminalWindow.Size.Height);
				width = theInputControl.Size.Width - macroPanel.Size.Width;
				x = theInputControl.Location.X + macroPanel.Size.Width;
				theInputControl.Location = new Point(x, theInputControl.Location.Y);
				theInputControl.Size = new Size(width, theInputControl.Size.Height);
			}
			this.theInputControl.Focus();
		}

		private void disconnectButton_Click(object sender, System.EventArgs e)
		{
			if (theMudConnection != null)
				theMudConnection.disconnect();
			this.menuDisconnect.Enabled = false;
			this.disconnectButton.Enabled = false;
			this.menuConnect.Enabled = true;
			this.connectButton.Enabled = true;
			this.theInputControl.Focus();
		}

		private void menuColors_Click(object sender, System.EventArgs e)
		{
			Colors edit = new Colors(theTerminalWindow, current_profile);
			edit.ShowDialog();
			this.theInputControl.Focus();
		}

		/*private FileVersionInfo GetFileVersion()
		{
			FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo("MUD.exe");
			return myFileVersionInfo;
		}*/

		private void menuAbout_Click(object sender, System.EventArgs e)
		{
			AboutForm about = new AboutForm();
			about.Show();
			//string version = this.GetFileVersion().FileVersion;
			//string name = this.GetFileVersion().FileDescription;
			//MessageBox.Show(name + "\nVersion " + version + "\n", "About MUDClient", MessageBoxButtons.OK);
			this.theInputControl.Focus();
		}

		private void macro_Click(object sender, System.EventArgs e)
		{
			switch(((Button)sender).Name.ToString())
			{
				case "macro1":
					if (current_profile.macros[0] != "")
					{
						string str = current_profile.AL.apply_aliasing(current_profile.macros[0]);
						
						while (str.IndexOf(";;") != -1)

						{
							int pos = str.IndexOf(";;");
							string first_command = str.Substring(0, pos);
							str = str.Substring(pos+2, str.Length-pos-2);
							theTerminalWindow.addTextDirectly(first_command);
							theMudConnection.sendText(first_command);
						}
						
						theTerminalWindow.addTextDirectly(str);
						theMudConnection.sendText(str);
					}
					break;
				case "macro2":
					if (current_profile.macros[1] != "")
					{
						string str = current_profile.AL.apply_aliasing(current_profile.macros[1]);
						theTerminalWindow.addTextDirectly(str);
						theMudConnection.sendText(str);
					}
					break;
				case "macro3":
					if (current_profile.macros[2] != "")
					{
						string str = current_profile.AL.apply_aliasing(current_profile.macros[2]);
						
						while (str.IndexOf(";;") != -1)

						{
							int pos = str.IndexOf(";;");
							string first_command = str.Substring(0, pos);
							str = str.Substring(pos+2, str.Length-pos-2);
							theTerminalWindow.addTextDirectly(first_command);
							theMudConnection.sendText(first_command);
						}
						
						theTerminalWindow.addTextDirectly(str);
						theMudConnection.sendText(str);
					}
					break;
				case "macro4":
					if (current_profile.macros[3] != "")
					{
						string str = current_profile.AL.apply_aliasing(current_profile.macros[3]);
						
						while (str.IndexOf(";;") != -1)

						{
							int pos = str.IndexOf(";;");
							string first_command = str.Substring(0, pos);
							str = str.Substring(pos+2, str.Length-pos-2);
							theTerminalWindow.addTextDirectly(first_command);
							theMudConnection.sendText(first_command);
						}
						
						theTerminalWindow.addTextDirectly(str);
						theMudConnection.sendText(str);
					}
					break;
				case "macro5":
					if (current_profile.macros[4] != "")
					{
						string str = current_profile.AL.apply_aliasing(current_profile.macros[4]);
						
						while (str.IndexOf(";;") != -1)

						{
							int pos = str.IndexOf(";;");
							string first_command = str.Substring(0, pos);
							str = str.Substring(pos+2, str.Length-pos-2);
							theTerminalWindow.addTextDirectly(first_command);
							theMudConnection.sendText(first_command);
						}
						
						theTerminalWindow.addTextDirectly(str);
						theMudConnection.sendText(str);
					}
					break;
				case "macro6":
					if (current_profile.macros[5] != "")
					{
						string str = current_profile.AL.apply_aliasing(current_profile.macros[5]);
						
						while (str.IndexOf(";;") != -1)

						{
							int pos = str.IndexOf(";;");
							string first_command = str.Substring(0, pos);
							str = str.Substring(pos+2, str.Length-pos-2);
							theTerminalWindow.addTextDirectly(first_command);
							theMudConnection.sendText(first_command);
						}
						
						theTerminalWindow.addTextDirectly(str);
						theMudConnection.sendText(str);
					}
					break;
				case "macro7":
					if (current_profile.macros[6] != "")
					{
						string str = current_profile.AL.apply_aliasing(current_profile.macros[6]);
						
						while (str.IndexOf(";;") != -1)

						{
							int pos = str.IndexOf(";;");
							string first_command = str.Substring(0, pos);
							str = str.Substring(pos+2, str.Length-pos-2);
							theTerminalWindow.addTextDirectly(first_command);
							theMudConnection.sendText(first_command);
						}
						
						theTerminalWindow.addTextDirectly(str);
						theMudConnection.sendText(str);
					}
					break;
				case "macro8":
					if (current_profile.macros[7] != "")
					{
						string str = current_profile.AL.apply_aliasing(current_profile.macros[7]);
						
						while (str.IndexOf(";;") != -1)

						{
							int pos = str.IndexOf(";;");
							string first_command = str.Substring(0, pos);
							str = str.Substring(pos+2, str.Length-pos-2);
							theTerminalWindow.addTextDirectly(first_command);
							theMudConnection.sendText(first_command);
						}
						
						theTerminalWindow.addTextDirectly(str);
						theMudConnection.sendText(str);
					}
					break;
				case "macro9":
					if (current_profile.macros[8] != "")
					{
						string str = current_profile.AL.apply_aliasing(current_profile.macros[8]);
						
						while (str.IndexOf(";;") != -1)

						{
							int pos = str.IndexOf(";;");
							string first_command = str.Substring(0, pos);
							str = str.Substring(pos+2, str.Length-pos-2);
							theTerminalWindow.addTextDirectly(first_command);
							theMudConnection.sendText(first_command);
						}
						
						theTerminalWindow.addTextDirectly(str);
						theMudConnection.sendText(str);
					}
					break;
				case "macro10":
					if (current_profile.macros[9] != "")
					{
						string str = current_profile.AL.apply_aliasing(current_profile.macros[9]);
						
						while (str.IndexOf(";;") != -1)

						{
							int pos = str.IndexOf(";;");
							string first_command = str.Substring(0, pos);
							str = str.Substring(pos+2, str.Length-pos-2);
							theTerminalWindow.addTextDirectly(first_command);
							theMudConnection.sendText(first_command);
						}
						
						theTerminalWindow.addTextDirectly(str);
						theMudConnection.sendText(str);
					}
					break;
			}
			this.theInputControl.Focus();
		}

		private void menuLog_Click(object sender, EventArgs e)
		{
			OpenFileDialog nfd = new OpenFileDialog();
			nfd.CheckFileExists = false;
			if (nfd.ShowDialog() == DialogResult.OK)
			{
				logFile = new StreamWriter(nfd.FileName, true, Encoding.ASCII, 10000);
				this.menuLog.Enabled = false;
				this.menuStopLog.Enabled = true;
				theTerminalWindow.set_log(true, logFile);
			}
			this.theInputControl.Focus();
		}

		private void menuStopLog_Click(object sender, EventArgs e)
		{
			this.menuLog.Enabled = true;
			this.menuStopLog.Enabled = false;
			logFile.Close();
			theTerminalWindow.set_log(false, logFile);
			this.theInputControl.Focus();
		}

		private void Client_Closing(object sender, CancelEventArgs e)
		{
			if (theMudConnection != null)
				theMudConnection.disconnect();
			if (logFile != null)
				logFile.Close();
		}

		private void menuSave_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.CheckFileExists = false;

			if (sfd.ShowDialog() == DialogResult.OK)
				this.current_profile.save_profile(sfd.FileName);
			this.theInputControl.Focus();
		}

		private void menuLoad_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();

			if (ofd.ShowDialog() == DialogResult.OK)
				this.current_profile.load_profile(ofd.FileName);
                
			theTerminalWindow.set_AC(current_profile.AC);
			theTerminalWindow.set_AL(current_profile.AL);
			theTerminalWindow.set_colors(current_profile.Colors);
			theTerminalWindow.set_macros(current_profile.macros);
			theInputControl.set_AL(current_profile.AL);
			theInputControl.set_AC(current_profile.AC);
			theInputControl.set_Macro(current_profile.macros);
			this.theInputControl.Focus();
		}

		private void emulationButton_Click(object sender, EventArgs e)
		
		{
			ANSI_MODE = (!ANSI_MODE);
			theTerminalWindow.set_ANSI(ANSI_MODE);
			this.theInputControl.Focus();
		}

		private void menuDisconnect_Click(object sender, EventArgs e)
		{
			this.disconnectButton_Click(sender, e);
			this.theInputControl.Focus();
		}
	}
}