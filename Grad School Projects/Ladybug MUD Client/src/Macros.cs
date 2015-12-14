using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MUD
{
	/// <summary>
	/// Summary description for Macros.
	/// </summary>
	public class Macros : System.Windows.Forms.Form
	{
		public System.Windows.Forms.TextBox macroText1;
		private System.Windows.Forms.Label macroLabel2;
		private System.Windows.Forms.Label macroLabel4;
		private System.Windows.Forms.Label macroLabel6;
		private System.Windows.Forms.Label macroLabel8;
		private System.Windows.Forms.Label macroLabel10;
		private System.Windows.Forms.Label macroLabel1;
		private System.Windows.Forms.Label macroLabel3;
		public System.Windows.Forms.TextBox macroText3;
		public System.Windows.Forms.TextBox macroText5;
		public System.Windows.Forms.TextBox macroText7;
		public System.Windows.Forms.TextBox macroText9;
		public System.Windows.Forms.TextBox macroText10;
		public System.Windows.Forms.TextBox macroText8;
		public System.Windows.Forms.TextBox macroText6;
		public System.Windows.Forms.TextBox macroText4;
		public System.Windows.Forms.TextBox macroText2;
		private System.Windows.Forms.Label macroLabel5;
		private System.Windows.Forms.Label macroLabel7;
		private System.Windows.Forms.Label macroLabel9;
		private System.Windows.Forms.Button macroOKButton;
		private System.Windows.Forms.Label label1;
		private string[] macroList;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Macros(string[] list)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			macroList = list;
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
			this.macroText1 = new System.Windows.Forms.TextBox();
			this.macroText3 = new System.Windows.Forms.TextBox();
			this.macroText5 = new System.Windows.Forms.TextBox();
			this.macroText7 = new System.Windows.Forms.TextBox();
			this.macroText9 = new System.Windows.Forms.TextBox();
			this.macroText10 = new System.Windows.Forms.TextBox();
			this.macroText8 = new System.Windows.Forms.TextBox();
			this.macroText6 = new System.Windows.Forms.TextBox();
			this.macroText4 = new System.Windows.Forms.TextBox();
			this.macroText2 = new System.Windows.Forms.TextBox();
			this.macroLabel2 = new System.Windows.Forms.Label();
			this.macroLabel4 = new System.Windows.Forms.Label();
			this.macroLabel6 = new System.Windows.Forms.Label();
			this.macroLabel8 = new System.Windows.Forms.Label();
			this.macroLabel10 = new System.Windows.Forms.Label();
			this.macroLabel1 = new System.Windows.Forms.Label();
			this.macroLabel3 = new System.Windows.Forms.Label();
			this.macroLabel5 = new System.Windows.Forms.Label();
			this.macroLabel7 = new System.Windows.Forms.Label();
			this.macroLabel9 = new System.Windows.Forms.Label();
			this.macroOKButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// macroText1
			// 
			this.macroText1.Location = new System.Drawing.Point(40, 16);
			this.macroText1.Multiline = true;
			this.macroText1.Name = "macroText1";
			this.macroText1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.macroText1.Size = new System.Drawing.Size(184, 80);
			this.macroText1.TabIndex = 0;
			this.macroText1.Text = "";
			// 
			// macroText3
			// 
			this.macroText3.Location = new System.Drawing.Point(40, 104);
			this.macroText3.Multiline = true;
			this.macroText3.Name = "macroText3";
			this.macroText3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.macroText3.Size = new System.Drawing.Size(184, 80);
			this.macroText3.TabIndex = 1;
			this.macroText3.Text = "";
			// 
			// macroText5
			// 
			this.macroText5.Location = new System.Drawing.Point(40, 192);
			this.macroText5.Multiline = true;
			this.macroText5.Name = "macroText5";
			this.macroText5.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.macroText5.Size = new System.Drawing.Size(184, 80);
			this.macroText5.TabIndex = 2;
			this.macroText5.Text = "";
			// 
			// macroText7
			// 
			this.macroText7.Location = new System.Drawing.Point(40, 280);
			this.macroText7.Multiline = true;
			this.macroText7.Name = "macroText7";
			this.macroText7.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.macroText7.Size = new System.Drawing.Size(184, 80);
			this.macroText7.TabIndex = 3;
			this.macroText7.Text = "";
			// 
			// macroText9
			// 
			this.macroText9.Location = new System.Drawing.Point(40, 368);
			this.macroText9.Multiline = true;
			this.macroText9.Name = "macroText9";
			this.macroText9.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.macroText9.Size = new System.Drawing.Size(184, 80);
			this.macroText9.TabIndex = 4;
			this.macroText9.Text = "";
			// 
			// macroText10
			// 
			this.macroText10.Location = new System.Drawing.Point(296, 368);
			this.macroText10.Multiline = true;
			this.macroText10.Name = "macroText10";
			this.macroText10.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.macroText10.Size = new System.Drawing.Size(184, 80);
			this.macroText10.TabIndex = 9;
			this.macroText10.Text = "";
			// 
			// macroText8
			// 
			this.macroText8.Location = new System.Drawing.Point(296, 280);
			this.macroText8.Multiline = true;
			this.macroText8.Name = "macroText8";
			this.macroText8.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.macroText8.Size = new System.Drawing.Size(184, 80);
			this.macroText8.TabIndex = 8;
			this.macroText8.Text = "";
			// 
			// macroText6
			// 
			this.macroText6.Location = new System.Drawing.Point(296, 192);
			this.macroText6.Multiline = true;
			this.macroText6.Name = "macroText6";
			this.macroText6.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.macroText6.Size = new System.Drawing.Size(184, 80);
			this.macroText6.TabIndex = 7;
			this.macroText6.Text = "";
			// 
			// macroText4
			// 
			this.macroText4.Location = new System.Drawing.Point(296, 104);
			this.macroText4.Multiline = true;
			this.macroText4.Name = "macroText4";
			this.macroText4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.macroText4.Size = new System.Drawing.Size(184, 80);
			this.macroText4.TabIndex = 6;
			this.macroText4.Text = "";
			// 
			// macroText2
			// 
			this.macroText2.Location = new System.Drawing.Point(296, 16);
			this.macroText2.Multiline = true;
			this.macroText2.Name = "macroText2";
			this.macroText2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.macroText2.Size = new System.Drawing.Size(184, 80);
			this.macroText2.TabIndex = 5;
			this.macroText2.Text = "";
			// 
			// macroLabel2
			// 
			this.macroLabel2.Location = new System.Drawing.Point(264, 16);
			this.macroLabel2.Name = "macroLabel2";
			this.macroLabel2.Size = new System.Drawing.Size(24, 23);
			this.macroLabel2.TabIndex = 10;
			this.macroLabel2.Text = "F2:";
			// 
			// macroLabel4
			// 
			this.macroLabel4.Location = new System.Drawing.Point(264, 104);
			this.macroLabel4.Name = "macroLabel4";
			this.macroLabel4.Size = new System.Drawing.Size(24, 23);
			this.macroLabel4.TabIndex = 11;
			this.macroLabel4.Text = "F4:";
			// 
			// macroLabel6
			// 
			this.macroLabel6.Location = new System.Drawing.Point(264, 192);
			this.macroLabel6.Name = "macroLabel6";
			this.macroLabel6.Size = new System.Drawing.Size(24, 23);
			this.macroLabel6.TabIndex = 12;
			this.macroLabel6.Text = "F6:";
			// 
			// macroLabel8
			// 
			this.macroLabel8.Location = new System.Drawing.Point(264, 280);
			this.macroLabel8.Name = "macroLabel8";
			this.macroLabel8.Size = new System.Drawing.Size(24, 23);
			this.macroLabel8.TabIndex = 13;
			this.macroLabel8.Text = "F8:";
			// 
			// macroLabel10
			// 
			this.macroLabel10.Location = new System.Drawing.Point(264, 368);
			this.macroLabel10.Name = "macroLabel10";
			this.macroLabel10.Size = new System.Drawing.Size(24, 23);
			this.macroLabel10.TabIndex = 14;
			this.macroLabel10.Text = "F10:";
			// 
			// macroLabel1
			// 
			this.macroLabel1.Location = new System.Drawing.Point(8, 16);
			this.macroLabel1.Name = "macroLabel1";
			this.macroLabel1.Size = new System.Drawing.Size(24, 23);
			this.macroLabel1.TabIndex = 15;
			this.macroLabel1.Text = "F1:";
			// 
			// macroLabel3
			// 
			this.macroLabel3.Location = new System.Drawing.Point(8, 104);
			this.macroLabel3.Name = "macroLabel3";
			this.macroLabel3.Size = new System.Drawing.Size(24, 23);
			this.macroLabel3.TabIndex = 16;
			this.macroLabel3.Text = "F3:";
			// 
			// macroLabel5
			// 
			this.macroLabel5.Location = new System.Drawing.Point(8, 192);
			this.macroLabel5.Name = "macroLabel5";
			this.macroLabel5.Size = new System.Drawing.Size(24, 23);
			this.macroLabel5.TabIndex = 17;
			this.macroLabel5.Text = "F5:";
			// 
			// macroLabel7
			// 
			this.macroLabel7.Location = new System.Drawing.Point(8, 280);
			this.macroLabel7.Name = "macroLabel7";
			this.macroLabel7.Size = new System.Drawing.Size(24, 23);
			this.macroLabel7.TabIndex = 18;
			this.macroLabel7.Text = "F7:";
			// 
			// macroLabel9
			// 
			this.macroLabel9.Location = new System.Drawing.Point(8, 368);
			this.macroLabel9.Name = "macroLabel9";
			this.macroLabel9.Size = new System.Drawing.Size(24, 23);
			this.macroLabel9.TabIndex = 19;
			this.macroLabel9.Text = "F9:";
			// 
			// macroOKButton
			// 
			this.macroOKButton.Location = new System.Drawing.Point(224, 488);
			this.macroOKButton.Name = "macroOKButton";
			this.macroOKButton.Size = new System.Drawing.Size(72, 23);
			this.macroOKButton.TabIndex = 20;
			this.macroOKButton.Text = "OK";
			this.macroOKButton.Click += new System.EventHandler(this.macroOKButton_Click);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(184, 464);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(160, 23);
			this.label1.TabIndex = 21;
			this.label1.Text = "Separate lines with \";;\"";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Macros
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(504, 518);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.macroOKButton);
			this.Controls.Add(this.macroLabel9);
			this.Controls.Add(this.macroLabel7);
			this.Controls.Add(this.macroLabel5);
			this.Controls.Add(this.macroLabel3);
			this.Controls.Add(this.macroLabel1);
			this.Controls.Add(this.macroLabel10);
			this.Controls.Add(this.macroLabel8);
			this.Controls.Add(this.macroLabel6);
			this.Controls.Add(this.macroLabel4);
			this.Controls.Add(this.macroLabel2);
			this.Controls.Add(this.macroText10);
			this.Controls.Add(this.macroText8);
			this.Controls.Add(this.macroText6);
			this.Controls.Add(this.macroText4);
			this.Controls.Add(this.macroText2);
			this.Controls.Add(this.macroText9);
			this.Controls.Add(this.macroText7);
			this.Controls.Add(this.macroText5);
			this.Controls.Add(this.macroText3);
			this.Controls.Add(this.macroText1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "Macros";
			this.Text = "MUDClient Macros";
			this.ResumeLayout(false);

		}
		#endregion

		private void macroOKButton_Click(object sender, System.EventArgs e)
		{
			this.macroList[0] = this.macroText1.Text;
			this.macroList[1] = this.macroText2.Text;
			this.macroList[2] = this.macroText3.Text;
			this.macroList[3] = this.macroText4.Text;
			this.macroList[4] = this.macroText5.Text;
			this.macroList[5] = this.macroText6.Text;
			this.macroList[6] = this.macroText7.Text;
			this.macroList[7] = this.macroText8.Text;
			this.macroList[8] = this.macroText9.Text;
			this.macroList[9] = this.macroText10.Text;
			this.Close();
		}

	}
}
