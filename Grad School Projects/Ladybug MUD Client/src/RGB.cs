using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MUD
{
	/// <summary>
	/// Summary description for RGB.
	/// </summary>
	public class RGB : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		public System.Windows.Forms.TextBox red;
		public System.Windows.Forms.TextBox green;
		public System.Windows.Forms.TextBox blue;
		private System.Windows.Forms.Button ok;
		private System.Windows.Forms.Button cancel;
		private TerminalWindow theTerminalWindow;
		private Profile current_profile;
		private int color;
		private bool changed;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RGB(object sender, TerminalWindow tw, Profile pf)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			theTerminalWindow = tw;
			current_profile = pf;
			changed = false;
			
			color = int.Parse(((LinkLabel)sender).TabIndex.ToString());
			this.Red = theTerminalWindow.Colors[color].R.ToString();
			this.Green = theTerminalWindow.Colors[color].G.ToString();
			this.Blue = theTerminalWindow.Colors[color].B.ToString();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.red = new System.Windows.Forms.TextBox();
			this.green = new System.Windows.Forms.TextBox();
			this.blue = new System.Windows.Forms.TextBox();
			this.ok = new System.Windows.Forms.Button();
			this.cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(16, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "R:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(96, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(16, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "G:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(168, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(16, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "B:";
			// 
			// red
			// 
			this.red.Location = new System.Drawing.Point(40, 24);
			this.red.Name = "red";
			this.red.Size = new System.Drawing.Size(40, 20);
			this.red.TabIndex = 3;
			this.red.Text = "";
			// 
			// green
			// 
			this.green.Location = new System.Drawing.Point(112, 24);
			this.green.Name = "green";
			this.green.Size = new System.Drawing.Size(40, 20);
			this.green.TabIndex = 4;
			this.green.Text = "";
			// 
			// blue
			// 
			this.blue.Location = new System.Drawing.Point(184, 24);
			this.blue.Name = "blue";
			this.blue.Size = new System.Drawing.Size(40, 20);
			this.blue.TabIndex = 5;
			this.blue.Text = "";
			// 
			// ok
			// 
			this.ok.Location = new System.Drawing.Point(48, 56);
			this.ok.Name = "ok";
			this.ok.TabIndex = 6;
			this.ok.Text = "OK";
			this.ok.Click += new System.EventHandler(this.ok_Click);
			// 
			// cancel
			// 
			this.cancel.Location = new System.Drawing.Point(144, 56);
			this.cancel.Name = "cancel";
			this.cancel.TabIndex = 7;
			this.cancel.Text = "Cancel";
			this.cancel.Click += new System.EventHandler(this.cancel_Click);
			// 
			// RGB
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(264, 94);
			this.Controls.Add(this.cancel);
			this.Controls.Add(this.ok);
			this.Controls.Add(this.blue);
			this.Controls.Add(this.green);
			this.Controls.Add(this.red);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "RGB";
			this.Text = "RGB";
			this.ResumeLayout(false);

		}
		#endregion

		private void cancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void ok_Click(object sender, System.EventArgs e)
		{
			if (this.red.Text != "" && this.blue.Text != "" && this.green.Text != "")
			{
				theTerminalWindow.Colors[color].R = int.Parse(this.Red);
				theTerminalWindow.Colors[color].G = int.Parse(this.Green);
				theTerminalWindow.Colors[color].B = int.Parse(this.Blue);
				current_profile.Colors[color].R = int.Parse(this.Red);
				current_profile.Colors[color].G = int.Parse(this.Green);
				current_profile.Colors[color].B = int.Parse(this.Blue);
				changed = true;
				this.Close();
			}
			else
				MessageBox.Show("Missing an RGB value");
		}

		public string Red
		{
			get { return this.red.Text; }
			set
			{
				this.red.Text = value;
			}
		}

		public string Green
		{
			get { return this.green.Text; }
			set
			{
				this.green.Text = value;
			}
		}

		public string Blue
		{
			get { return this.blue.Text; }
			set
			{
				this.blue.Text = value;
			}
		}

		public bool get_changed()
		{
			return this.changed;
		}
	}
}
