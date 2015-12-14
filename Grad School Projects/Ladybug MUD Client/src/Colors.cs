using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace MUD
{
	/// <summary>
	/// Summary description for Colors.
	/// </summary>
	public class Colors : System.Windows.Forms.Form
	{
		private TerminalWindow theTerminalWindow;
		private Profile current_profile;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label blackR;
		private System.Windows.Forms.Label blackG;
		private System.Windows.Forms.Label blackB;
		private System.Windows.Forms.Label maroonB;
		private System.Windows.Forms.Label maroonG;
		private System.Windows.Forms.Label maroonR;
		private System.Windows.Forms.Label greenB;
		private System.Windows.Forms.Label greenG;
		private System.Windows.Forms.Label greenR;
		private System.Windows.Forms.Label navyB;
		private System.Windows.Forms.Label navyG;
		private System.Windows.Forms.Label navyR;
		private System.Windows.Forms.Label purpleB;
		private System.Windows.Forms.Label purpleG;
		private System.Windows.Forms.Label purpleR;
		private System.Windows.Forms.Label tealB;
		private System.Windows.Forms.Label tealG;
		private System.Windows.Forms.Label tealR;
		private System.Windows.Forms.Label grayB;
		private System.Windows.Forms.Label grayG;
		private System.Windows.Forms.Label grayR;
		private System.Windows.Forms.Label silverB;
		private System.Windows.Forms.Label silverG;
		private System.Windows.Forms.Label silverR;
		private System.Windows.Forms.Label redR;
		private System.Windows.Forms.LinkLabel blackEdit;
		private System.Windows.Forms.LinkLabel maroonEdit;
		private System.Windows.Forms.LinkLabel greenEdit;
		private System.Windows.Forms.LinkLabel navyEdit;
		private System.Windows.Forms.LinkLabel purpleEdit;
		private System.Windows.Forms.LinkLabel tealEdit;
		private System.Windows.Forms.LinkLabel grayEdit;
		private System.Windows.Forms.LinkLabel silverEdit;
		private System.Windows.Forms.Label redB;
		private System.Windows.Forms.Label redG;
		private System.Windows.Forms.Label yellowB;
		private System.Windows.Forms.Label yellowG;
		private System.Windows.Forms.Label yellowR;
		private System.Windows.Forms.Label blueB;
		private System.Windows.Forms.Label blueG;
		private System.Windows.Forms.Label blueR;
		private System.Windows.Forms.Label whiteB;
		private System.Windows.Forms.Label whiteG;
		private System.Windows.Forms.Label whiteR;
		private System.Windows.Forms.LinkLabel redEdit;
		private System.Windows.Forms.LinkLabel yellowEdit;
		private System.Windows.Forms.LinkLabel blueEdit;
		private System.Windows.Forms.LinkLabel whiteEdit;
		private System.Windows.Forms.Label magentaB;
		private System.Windows.Forms.Label magentaG;
		private System.Windows.Forms.Label magentaR;
		private System.Windows.Forms.LinkLabel magentaEdit;
		private System.Windows.Forms.Label brownB;
		private System.Windows.Forms.Label brownG;
		private System.Windows.Forms.Label brownR;
		private System.Windows.Forms.LinkLabel brownEdit;
		private System.Windows.Forms.Label dgreenB;
		private System.Windows.Forms.Label dgreenG;
		private System.Windows.Forms.Label dgreenR;
		private System.Windows.Forms.LinkLabel dgreenEdit;
		private System.Windows.Forms.Label cyanB;
		private System.Windows.Forms.Label cyanG;
		private System.Windows.Forms.Label cyanR;
		private System.Windows.Forms.LinkLabel cyanEdit;
		private System.Windows.Forms.Label blackLabel;
		private System.Windows.Forms.Label maroonLabel;
		private System.Windows.Forms.Label greenLabel;
		private System.Windows.Forms.Label brownLabel;
		private System.Windows.Forms.Label navyLabel;
		private System.Windows.Forms.Label purpleLabel;
		private System.Windows.Forms.Label tealLabel;
		private System.Windows.Forms.Label grayLabel;
		private System.Windows.Forms.Label silverLabel;
		private System.Windows.Forms.Label redLabel;
		private System.Windows.Forms.Label dgreenLabel;
		private System.Windows.Forms.Label yellowLabel;
		private System.Windows.Forms.Label blueLabel;
		private System.Windows.Forms.Label magentaLabel;
		private System.Windows.Forms.Label cyanLabel;
		private System.Windows.Forms.Label whiteLabel;
		private System.Windows.Forms.Button restoreButton;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Colors(TerminalWindow tw, Profile pf)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			theTerminalWindow = tw;
			current_profile = pf;
			
			setLabels();
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
			this.blackLabel = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.blackEdit = new System.Windows.Forms.LinkLabel();
			this.blackR = new System.Windows.Forms.Label();
			this.blackG = new System.Windows.Forms.Label();
			this.blackB = new System.Windows.Forms.Label();
			this.maroonB = new System.Windows.Forms.Label();
			this.maroonG = new System.Windows.Forms.Label();
			this.maroonR = new System.Windows.Forms.Label();
			this.maroonEdit = new System.Windows.Forms.LinkLabel();
			this.maroonLabel = new System.Windows.Forms.Label();
			this.greenB = new System.Windows.Forms.Label();
			this.greenG = new System.Windows.Forms.Label();
			this.greenR = new System.Windows.Forms.Label();
			this.greenEdit = new System.Windows.Forms.LinkLabel();
			this.greenLabel = new System.Windows.Forms.Label();
			this.brownB = new System.Windows.Forms.Label();
			this.brownG = new System.Windows.Forms.Label();
			this.brownR = new System.Windows.Forms.Label();
			this.brownEdit = new System.Windows.Forms.LinkLabel();
			this.brownLabel = new System.Windows.Forms.Label();
			this.navyB = new System.Windows.Forms.Label();
			this.navyG = new System.Windows.Forms.Label();
			this.navyR = new System.Windows.Forms.Label();
			this.navyEdit = new System.Windows.Forms.LinkLabel();
			this.navyLabel = new System.Windows.Forms.Label();
			this.purpleB = new System.Windows.Forms.Label();
			this.purpleG = new System.Windows.Forms.Label();
			this.purpleR = new System.Windows.Forms.Label();
			this.purpleEdit = new System.Windows.Forms.LinkLabel();
			this.purpleLabel = new System.Windows.Forms.Label();
			this.tealB = new System.Windows.Forms.Label();
			this.tealG = new System.Windows.Forms.Label();
			this.tealR = new System.Windows.Forms.Label();
			this.tealEdit = new System.Windows.Forms.LinkLabel();
			this.tealLabel = new System.Windows.Forms.Label();
			this.grayB = new System.Windows.Forms.Label();
			this.grayG = new System.Windows.Forms.Label();
			this.grayR = new System.Windows.Forms.Label();
			this.grayEdit = new System.Windows.Forms.LinkLabel();
			this.grayLabel = new System.Windows.Forms.Label();
			this.silverB = new System.Windows.Forms.Label();
			this.silverG = new System.Windows.Forms.Label();
			this.silverR = new System.Windows.Forms.Label();
			this.silverEdit = new System.Windows.Forms.LinkLabel();
			this.silverLabel = new System.Windows.Forms.Label();
			this.redB = new System.Windows.Forms.Label();
			this.redG = new System.Windows.Forms.Label();
			this.redR = new System.Windows.Forms.Label();
			this.redEdit = new System.Windows.Forms.LinkLabel();
			this.redLabel = new System.Windows.Forms.Label();
			this.dgreenB = new System.Windows.Forms.Label();
			this.dgreenG = new System.Windows.Forms.Label();
			this.dgreenR = new System.Windows.Forms.Label();
			this.dgreenEdit = new System.Windows.Forms.LinkLabel();
			this.dgreenLabel = new System.Windows.Forms.Label();
			this.yellowB = new System.Windows.Forms.Label();
			this.yellowG = new System.Windows.Forms.Label();
			this.yellowR = new System.Windows.Forms.Label();
			this.yellowEdit = new System.Windows.Forms.LinkLabel();
			this.yellowLabel = new System.Windows.Forms.Label();
			this.blueB = new System.Windows.Forms.Label();
			this.blueG = new System.Windows.Forms.Label();
			this.blueR = new System.Windows.Forms.Label();
			this.blueEdit = new System.Windows.Forms.LinkLabel();
			this.blueLabel = new System.Windows.Forms.Label();
			this.magentaB = new System.Windows.Forms.Label();
			this.magentaG = new System.Windows.Forms.Label();
			this.magentaR = new System.Windows.Forms.Label();
			this.magentaEdit = new System.Windows.Forms.LinkLabel();
			this.magentaLabel = new System.Windows.Forms.Label();
			this.cyanB = new System.Windows.Forms.Label();
			this.cyanG = new System.Windows.Forms.Label();
			this.cyanR = new System.Windows.Forms.Label();
			this.cyanEdit = new System.Windows.Forms.LinkLabel();
			this.cyanLabel = new System.Windows.Forms.Label();
			this.whiteB = new System.Windows.Forms.Label();
			this.whiteG = new System.Windows.Forms.Label();
			this.whiteR = new System.Windows.Forms.Label();
			this.whiteEdit = new System.Windows.Forms.LinkLabel();
			this.whiteLabel = new System.Windows.Forms.Label();
			this.restoreButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// blackLabel
			// 
			this.blackLabel.ForeColor = System.Drawing.Color.Black;
			this.blackLabel.Location = new System.Drawing.Point(24, 72);
			this.blackLabel.Name = "blackLabel";
			this.blackLabel.Size = new System.Drawing.Size(40, 23);
			this.blackLabel.TabIndex = 0;
			this.blackLabel.Text = "Black:";
			this.blackLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(24, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Color";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(96, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 24);
			this.label3.TabIndex = 2;
			this.label3.Text = "Current Values";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(96, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(16, 23);
			this.label4.TabIndex = 3;
			this.label4.Text = "R";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(136, 48);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(16, 23);
			this.label5.TabIndex = 4;
			this.label5.Text = "G";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(176, 48);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(16, 23);
			this.label6.TabIndex = 5;
			this.label6.Text = "B";
			// 
			// blackEdit
			// 
			this.blackEdit.Location = new System.Drawing.Point(240, 72);
			this.blackEdit.Name = "blackEdit";
			this.blackEdit.Size = new System.Drawing.Size(24, 23);
			this.blackEdit.TabIndex = 0;
			this.blackEdit.TabStop = true;
			this.blackEdit.Text = "Edit";
			this.blackEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.blackEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Edit_LinkClicked);
			// 
			// blackR
			// 
			this.blackR.Location = new System.Drawing.Point(88, 72);
			this.blackR.Name = "blackR";
			this.blackR.Size = new System.Drawing.Size(32, 23);
			this.blackR.TabIndex = 7;
			this.blackR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// blackG
			// 
			this.blackG.Location = new System.Drawing.Point(128, 72);
			this.blackG.Name = "blackG";
			this.blackG.Size = new System.Drawing.Size(32, 23);
			this.blackG.TabIndex = 8;
			this.blackG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// blackB
			// 
			this.blackB.Location = new System.Drawing.Point(168, 72);
			this.blackB.Name = "blackB";
			this.blackB.Size = new System.Drawing.Size(32, 23);
			this.blackB.TabIndex = 9;
			this.blackB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// maroonB
			// 
			this.maroonB.Location = new System.Drawing.Point(168, 264);
			this.maroonB.Name = "maroonB";
			this.maroonB.Size = new System.Drawing.Size(32, 23);
			this.maroonB.TabIndex = 14;
			this.maroonB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// maroonG
			// 
			this.maroonG.Location = new System.Drawing.Point(128, 264);
			this.maroonG.Name = "maroonG";
			this.maroonG.Size = new System.Drawing.Size(32, 23);
			this.maroonG.TabIndex = 13;
			this.maroonG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// maroonR
			// 
			this.maroonR.Location = new System.Drawing.Point(88, 264);
			this.maroonR.Name = "maroonR";
			this.maroonR.Size = new System.Drawing.Size(32, 23);
			this.maroonR.TabIndex = 12;
			this.maroonR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// maroonEdit
			// 
			this.maroonEdit.Location = new System.Drawing.Point(240, 264);
			this.maroonEdit.Name = "maroonEdit";
			this.maroonEdit.Size = new System.Drawing.Size(24, 23);
			this.maroonEdit.TabIndex = 8;
			this.maroonEdit.TabStop = true;
			this.maroonEdit.Text = "Edit";
			this.maroonEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.maroonEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Edit_LinkClicked);
			// 
			// maroonLabel
			// 
			this.maroonLabel.ForeColor = System.Drawing.Color.Maroon;
			this.maroonLabel.Location = new System.Drawing.Point(24, 264);
			this.maroonLabel.Name = "maroonLabel";
			this.maroonLabel.Size = new System.Drawing.Size(48, 23);
			this.maroonLabel.TabIndex = 10;
			this.maroonLabel.Text = "Maroon:";
			this.maroonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// greenB
			// 
			this.greenB.Location = new System.Drawing.Point(168, 168);
			this.greenB.Name = "greenB";
			this.greenB.Size = new System.Drawing.Size(32, 23);
			this.greenB.TabIndex = 19;
			this.greenB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// greenG
			// 
			this.greenG.Location = new System.Drawing.Point(128, 168);
			this.greenG.Name = "greenG";
			this.greenG.Size = new System.Drawing.Size(32, 23);
			this.greenG.TabIndex = 18;
			this.greenG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// greenR
			// 
			this.greenR.Location = new System.Drawing.Point(88, 168);
			this.greenR.Name = "greenR";
			this.greenR.Size = new System.Drawing.Size(32, 23);
			this.greenR.TabIndex = 17;
			this.greenR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// greenEdit
			// 
			this.greenEdit.Location = new System.Drawing.Point(240, 168);
			this.greenEdit.Name = "greenEdit";
			this.greenEdit.Size = new System.Drawing.Size(24, 23);
			this.greenEdit.TabIndex = 4;
			this.greenEdit.TabStop = true;
			this.greenEdit.Text = "Edit";
			this.greenEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.greenEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Edit_LinkClicked);
			// 
			// greenLabel
			// 
			this.greenLabel.ForeColor = System.Drawing.Color.Green;
			this.greenLabel.Location = new System.Drawing.Point(24, 168);
			this.greenLabel.Name = "greenLabel";
			this.greenLabel.Size = new System.Drawing.Size(40, 23);
			this.greenLabel.TabIndex = 15;
			this.greenLabel.Text = "Green:";
			this.greenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// brownB
			// 
			this.brownB.Location = new System.Drawing.Point(168, 336);
			this.brownB.Name = "brownB";
			this.brownB.Size = new System.Drawing.Size(32, 23);
			this.brownB.TabIndex = 24;
			this.brownB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// brownG
			// 
			this.brownG.Location = new System.Drawing.Point(128, 336);
			this.brownG.Name = "brownG";
			this.brownG.Size = new System.Drawing.Size(32, 23);
			this.brownG.TabIndex = 23;
			this.brownG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// brownR
			// 
			this.brownR.Location = new System.Drawing.Point(88, 336);
			this.brownR.Name = "brownR";
			this.brownR.Size = new System.Drawing.Size(32, 23);
			this.brownR.TabIndex = 22;
			this.brownR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// brownEdit
			// 
			this.brownEdit.Location = new System.Drawing.Point(240, 336);
			this.brownEdit.Name = "brownEdit";
			this.brownEdit.Size = new System.Drawing.Size(24, 23);
			this.brownEdit.TabIndex = 11;
			this.brownEdit.TabStop = true;
			this.brownEdit.Text = "Edit";
			this.brownEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.brownEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Edit_LinkClicked);
			// 
			// brownLabel
			// 
			this.brownLabel.ForeColor = System.Drawing.Color.Olive;
			this.brownLabel.Location = new System.Drawing.Point(24, 336);
			this.brownLabel.Name = "brownLabel";
			this.brownLabel.Size = new System.Drawing.Size(40, 23);
			this.brownLabel.TabIndex = 20;
			this.brownLabel.Text = "Brown:";
			this.brownLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// navyB
			// 
			this.navyB.Location = new System.Drawing.Point(168, 312);
			this.navyB.Name = "navyB";
			this.navyB.Size = new System.Drawing.Size(32, 23);
			this.navyB.TabIndex = 29;
			this.navyB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// navyG
			// 
			this.navyG.Location = new System.Drawing.Point(128, 312);
			this.navyG.Name = "navyG";
			this.navyG.Size = new System.Drawing.Size(32, 23);
			this.navyG.TabIndex = 28;
			this.navyG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// navyR
			// 
			this.navyR.Location = new System.Drawing.Point(88, 312);
			this.navyR.Name = "navyR";
			this.navyR.Size = new System.Drawing.Size(32, 23);
			this.navyR.TabIndex = 27;
			this.navyR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// navyEdit
			// 
			this.navyEdit.Location = new System.Drawing.Point(240, 312);
			this.navyEdit.Name = "navyEdit";
			this.navyEdit.Size = new System.Drawing.Size(24, 23);
			this.navyEdit.TabIndex = 10;
			this.navyEdit.TabStop = true;
			this.navyEdit.Text = "Edit";
			this.navyEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.navyEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Edit_LinkClicked);
			// 
			// navyLabel
			// 
			this.navyLabel.ForeColor = System.Drawing.Color.Navy;
			this.navyLabel.Location = new System.Drawing.Point(24, 312);
			this.navyLabel.Name = "navyLabel";
			this.navyLabel.Size = new System.Drawing.Size(40, 23);
			this.navyLabel.TabIndex = 25;
			this.navyLabel.Text = "Navy:";
			this.navyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// purpleB
			// 
			this.purpleB.Location = new System.Drawing.Point(168, 384);
			this.purpleB.Name = "purpleB";
			this.purpleB.Size = new System.Drawing.Size(32, 23);
			this.purpleB.TabIndex = 34;
			this.purpleB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// purpleG
			// 
			this.purpleG.Location = new System.Drawing.Point(128, 384);
			this.purpleG.Name = "purpleG";
			this.purpleG.Size = new System.Drawing.Size(32, 23);
			this.purpleG.TabIndex = 33;
			this.purpleG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// purpleR
			// 
			this.purpleR.Location = new System.Drawing.Point(88, 384);
			this.purpleR.Name = "purpleR";
			this.purpleR.Size = new System.Drawing.Size(32, 23);
			this.purpleR.TabIndex = 32;
			this.purpleR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// purpleEdit
			// 
			this.purpleEdit.Location = new System.Drawing.Point(240, 384);
			this.purpleEdit.Name = "purpleEdit";
			this.purpleEdit.Size = new System.Drawing.Size(24, 23);
			this.purpleEdit.TabIndex = 13;
			this.purpleEdit.TabStop = true;
			this.purpleEdit.Text = "Edit";
			this.purpleEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.purpleEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Edit_LinkClicked);
			// 
			// purpleLabel
			// 
			this.purpleLabel.ForeColor = System.Drawing.Color.Purple;
			this.purpleLabel.Location = new System.Drawing.Point(24, 384);
			this.purpleLabel.Name = "purpleLabel";
			this.purpleLabel.Size = new System.Drawing.Size(40, 23);
			this.purpleLabel.TabIndex = 30;
			this.purpleLabel.Text = "Purple:";
			this.purpleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tealB
			// 
			this.tealB.Location = new System.Drawing.Point(168, 360);
			this.tealB.Name = "tealB";
			this.tealB.Size = new System.Drawing.Size(32, 23);
			this.tealB.TabIndex = 39;
			this.tealB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tealG
			// 
			this.tealG.Location = new System.Drawing.Point(128, 360);
			this.tealG.Name = "tealG";
			this.tealG.Size = new System.Drawing.Size(32, 23);
			this.tealG.TabIndex = 38;
			this.tealG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tealR
			// 
			this.tealR.Location = new System.Drawing.Point(88, 360);
			this.tealR.Name = "tealR";
			this.tealR.Size = new System.Drawing.Size(32, 23);
			this.tealR.TabIndex = 37;
			this.tealR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tealEdit
			// 
			this.tealEdit.Location = new System.Drawing.Point(240, 360);
			this.tealEdit.Name = "tealEdit";
			this.tealEdit.Size = new System.Drawing.Size(24, 23);
			this.tealEdit.TabIndex = 12;
			this.tealEdit.TabStop = true;
			this.tealEdit.Text = "Edit";
			this.tealEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.tealEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Edit_LinkClicked);
			// 
			// tealLabel
			// 
			this.tealLabel.ForeColor = System.Drawing.Color.Teal;
			this.tealLabel.Location = new System.Drawing.Point(24, 360);
			this.tealLabel.Name = "tealLabel";
			this.tealLabel.Size = new System.Drawing.Size(40, 23);
			this.tealLabel.TabIndex = 35;
			this.tealLabel.Text = "Teal:";
			this.tealLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// grayB
			// 
			this.grayB.Location = new System.Drawing.Point(168, 432);
			this.grayB.Name = "grayB";
			this.grayB.Size = new System.Drawing.Size(32, 23);
			this.grayB.TabIndex = 44;
			this.grayB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// grayG
			// 
			this.grayG.Location = new System.Drawing.Point(128, 432);
			this.grayG.Name = "grayG";
			this.grayG.Size = new System.Drawing.Size(32, 23);
			this.grayG.TabIndex = 43;
			this.grayG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// grayR
			// 
			this.grayR.Location = new System.Drawing.Point(88, 432);
			this.grayR.Name = "grayR";
			this.grayR.Size = new System.Drawing.Size(32, 23);
			this.grayR.TabIndex = 42;
			this.grayR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// grayEdit
			// 
			this.grayEdit.Location = new System.Drawing.Point(240, 432);
			this.grayEdit.Name = "grayEdit";
			this.grayEdit.Size = new System.Drawing.Size(24, 23);
			this.grayEdit.TabIndex = 15;
			this.grayEdit.TabStop = true;
			this.grayEdit.Text = "Edit";
			this.grayEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.grayEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Edit_LinkClicked);
			// 
			// grayLabel
			// 
			this.grayLabel.ForeColor = System.Drawing.Color.Gray;
			this.grayLabel.Location = new System.Drawing.Point(24, 432);
			this.grayLabel.Name = "grayLabel";
			this.grayLabel.Size = new System.Drawing.Size(40, 23);
			this.grayLabel.TabIndex = 40;
			this.grayLabel.Text = "Gray:";
			this.grayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// silverB
			// 
			this.silverB.Location = new System.Drawing.Point(168, 408);
			this.silverB.Name = "silverB";
			this.silverB.Size = new System.Drawing.Size(32, 23);
			this.silverB.TabIndex = 49;
			this.silverB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// silverG
			// 
			this.silverG.Location = new System.Drawing.Point(128, 408);
			this.silverG.Name = "silverG";
			this.silverG.Size = new System.Drawing.Size(32, 23);
			this.silverG.TabIndex = 48;
			this.silverG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// silverR
			// 
			this.silverR.Location = new System.Drawing.Point(88, 408);
			this.silverR.Name = "silverR";
			this.silverR.Size = new System.Drawing.Size(32, 23);
			this.silverR.TabIndex = 47;
			this.silverR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// silverEdit
			// 
			this.silverEdit.Location = new System.Drawing.Point(240, 408);
			this.silverEdit.Name = "silverEdit";
			this.silverEdit.Size = new System.Drawing.Size(24, 23);
			this.silverEdit.TabIndex = 14;
			this.silverEdit.TabStop = true;
			this.silverEdit.Text = "Edit";
			this.silverEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.silverEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Edit_LinkClicked);
			// 
			// silverLabel
			// 
			this.silverLabel.ForeColor = System.Drawing.Color.Silver;
			this.silverLabel.Location = new System.Drawing.Point(24, 408);
			this.silverLabel.Name = "silverLabel";
			this.silverLabel.Size = new System.Drawing.Size(40, 23);
			this.silverLabel.TabIndex = 45;
			this.silverLabel.Text = "Silver:";
			this.silverLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// redB
			// 
			this.redB.Location = new System.Drawing.Point(168, 120);
			this.redB.Name = "redB";
			this.redB.Size = new System.Drawing.Size(32, 23);
			this.redB.TabIndex = 54;
			this.redB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// redG
			// 
			this.redG.Location = new System.Drawing.Point(128, 120);
			this.redG.Name = "redG";
			this.redG.Size = new System.Drawing.Size(32, 23);
			this.redG.TabIndex = 53;
			this.redG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// redR
			// 
			this.redR.Location = new System.Drawing.Point(88, 120);
			this.redR.Name = "redR";
			this.redR.Size = new System.Drawing.Size(32, 23);
			this.redR.TabIndex = 52;
			this.redR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// redEdit
			// 
			this.redEdit.Location = new System.Drawing.Point(240, 120);
			this.redEdit.Name = "redEdit";
			this.redEdit.Size = new System.Drawing.Size(24, 23);
			this.redEdit.TabIndex = 2;
			this.redEdit.TabStop = true;
			this.redEdit.Text = "Edit";
			this.redEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.redEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Edit_LinkClicked);
			// 
			// redLabel
			// 
			this.redLabel.ForeColor = System.Drawing.Color.Red;
			this.redLabel.Location = new System.Drawing.Point(24, 120);
			this.redLabel.Name = "redLabel";
			this.redLabel.Size = new System.Drawing.Size(40, 23);
			this.redLabel.TabIndex = 50;
			this.redLabel.Text = "Red:";
			this.redLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dgreenB
			// 
			this.dgreenB.Location = new System.Drawing.Point(168, 288);
			this.dgreenB.Name = "dgreenB";
			this.dgreenB.Size = new System.Drawing.Size(32, 23);
			this.dgreenB.TabIndex = 59;
			this.dgreenB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dgreenG
			// 
			this.dgreenG.Location = new System.Drawing.Point(128, 288);
			this.dgreenG.Name = "dgreenG";
			this.dgreenG.Size = new System.Drawing.Size(32, 23);
			this.dgreenG.TabIndex = 58;
			this.dgreenG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dgreenR
			// 
			this.dgreenR.Location = new System.Drawing.Point(88, 288);
			this.dgreenR.Name = "dgreenR";
			this.dgreenR.Size = new System.Drawing.Size(32, 23);
			this.dgreenR.TabIndex = 57;
			this.dgreenR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dgreenEdit
			// 
			this.dgreenEdit.Location = new System.Drawing.Point(240, 288);
			this.dgreenEdit.Name = "dgreenEdit";
			this.dgreenEdit.Size = new System.Drawing.Size(24, 23);
			this.dgreenEdit.TabIndex = 9;
			this.dgreenEdit.TabStop = true;
			this.dgreenEdit.Text = "Edit";
			this.dgreenEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.dgreenEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Edit_LinkClicked);
			// 
			// dgreenLabel
			// 
			this.dgreenLabel.ForeColor = System.Drawing.Color.Lime;
			this.dgreenLabel.Location = new System.Drawing.Point(24, 288);
			this.dgreenLabel.Name = "dgreenLabel";
			this.dgreenLabel.Size = new System.Drawing.Size(48, 23);
			this.dgreenLabel.TabIndex = 55;
			this.dgreenLabel.Text = "Lime:";
			this.dgreenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// yellowB
			// 
			this.yellowB.Location = new System.Drawing.Point(168, 192);
			this.yellowB.Name = "yellowB";
			this.yellowB.Size = new System.Drawing.Size(32, 23);
			this.yellowB.TabIndex = 64;
			this.yellowB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// yellowG
			// 
			this.yellowG.Location = new System.Drawing.Point(128, 192);
			this.yellowG.Name = "yellowG";
			this.yellowG.Size = new System.Drawing.Size(32, 23);
			this.yellowG.TabIndex = 63;
			this.yellowG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// yellowR
			// 
			this.yellowR.Location = new System.Drawing.Point(88, 192);
			this.yellowR.Name = "yellowR";
			this.yellowR.Size = new System.Drawing.Size(32, 23);
			this.yellowR.TabIndex = 62;
			this.yellowR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// yellowEdit
			// 
			this.yellowEdit.Location = new System.Drawing.Point(240, 192);
			this.yellowEdit.Name = "yellowEdit";
			this.yellowEdit.Size = new System.Drawing.Size(24, 23);
			this.yellowEdit.TabIndex = 5;
			this.yellowEdit.TabStop = true;
			this.yellowEdit.Text = "Edit";
			this.yellowEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.yellowEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Edit_LinkClicked);
			// 
			// yellowLabel
			// 
			this.yellowLabel.ForeColor = System.Drawing.Color.Yellow;
			this.yellowLabel.Location = new System.Drawing.Point(24, 192);
			this.yellowLabel.Name = "yellowLabel";
			this.yellowLabel.Size = new System.Drawing.Size(48, 23);
			this.yellowLabel.TabIndex = 60;
			this.yellowLabel.Text = "Yellow:";
			this.yellowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// blueB
			// 
			this.blueB.Location = new System.Drawing.Point(168, 144);
			this.blueB.Name = "blueB";
			this.blueB.Size = new System.Drawing.Size(32, 23);
			this.blueB.TabIndex = 69;
			this.blueB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// blueG
			// 
			this.blueG.Location = new System.Drawing.Point(128, 144);
			this.blueG.Name = "blueG";
			this.blueG.Size = new System.Drawing.Size(32, 23);
			this.blueG.TabIndex = 68;
			this.blueG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// blueR
			// 
			this.blueR.Location = new System.Drawing.Point(88, 144);
			this.blueR.Name = "blueR";
			this.blueR.Size = new System.Drawing.Size(32, 23);
			this.blueR.TabIndex = 67;
			this.blueR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// blueEdit
			// 
			this.blueEdit.Location = new System.Drawing.Point(240, 144);
			this.blueEdit.Name = "blueEdit";
			this.blueEdit.Size = new System.Drawing.Size(24, 23);
			this.blueEdit.TabIndex = 3;
			this.blueEdit.TabStop = true;
			this.blueEdit.Text = "Edit";
			this.blueEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.blueEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Edit_LinkClicked);
			// 
			// blueLabel
			// 
			this.blueLabel.ForeColor = System.Drawing.Color.Blue;
			this.blueLabel.Location = new System.Drawing.Point(24, 144);
			this.blueLabel.Name = "blueLabel";
			this.blueLabel.Size = new System.Drawing.Size(40, 23);
			this.blueLabel.TabIndex = 65;
			this.blueLabel.Text = "Blue:";
			this.blueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// magentaB
			// 
			this.magentaB.Location = new System.Drawing.Point(168, 240);
			this.magentaB.Name = "magentaB";
			this.magentaB.Size = new System.Drawing.Size(32, 23);
			this.magentaB.TabIndex = 74;
			this.magentaB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// magentaG
			// 
			this.magentaG.Location = new System.Drawing.Point(128, 240);
			this.magentaG.Name = "magentaG";
			this.magentaG.Size = new System.Drawing.Size(32, 23);
			this.magentaG.TabIndex = 73;
			this.magentaG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// magentaR
			// 
			this.magentaR.Location = new System.Drawing.Point(88, 240);
			this.magentaR.Name = "magentaR";
			this.magentaR.Size = new System.Drawing.Size(32, 23);
			this.magentaR.TabIndex = 72;
			this.magentaR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// magentaEdit
			// 
			this.magentaEdit.Location = new System.Drawing.Point(240, 240);
			this.magentaEdit.Name = "magentaEdit";
			this.magentaEdit.Size = new System.Drawing.Size(24, 23);
			this.magentaEdit.TabIndex = 7;
			this.magentaEdit.TabStop = true;
			this.magentaEdit.Text = "Edit";
			this.magentaEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.magentaEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Edit_LinkClicked);
			// 
			// magentaLabel
			// 
			this.magentaLabel.ForeColor = System.Drawing.Color.Magenta;
			this.magentaLabel.Location = new System.Drawing.Point(24, 240);
			this.magentaLabel.Name = "magentaLabel";
			this.magentaLabel.Size = new System.Drawing.Size(56, 23);
			this.magentaLabel.TabIndex = 70;
			this.magentaLabel.Text = "Magenta:";
			this.magentaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cyanB
			// 
			this.cyanB.Location = new System.Drawing.Point(168, 216);
			this.cyanB.Name = "cyanB";
			this.cyanB.Size = new System.Drawing.Size(32, 23);
			this.cyanB.TabIndex = 79;
			this.cyanB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cyanG
			// 
			this.cyanG.Location = new System.Drawing.Point(128, 216);
			this.cyanG.Name = "cyanG";
			this.cyanG.Size = new System.Drawing.Size(32, 23);
			this.cyanG.TabIndex = 78;
			this.cyanG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cyanR
			// 
			this.cyanR.Location = new System.Drawing.Point(88, 216);
			this.cyanR.Name = "cyanR";
			this.cyanR.Size = new System.Drawing.Size(32, 23);
			this.cyanR.TabIndex = 77;
			this.cyanR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cyanEdit
			// 
			this.cyanEdit.Location = new System.Drawing.Point(240, 216);
			this.cyanEdit.Name = "cyanEdit";
			this.cyanEdit.Size = new System.Drawing.Size(24, 23);
			this.cyanEdit.TabIndex = 6;
			this.cyanEdit.TabStop = true;
			this.cyanEdit.Text = "Edit";
			this.cyanEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cyanEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Edit_LinkClicked);
			// 
			// cyanLabel
			// 
			this.cyanLabel.ForeColor = System.Drawing.Color.Cyan;
			this.cyanLabel.Location = new System.Drawing.Point(24, 216);
			this.cyanLabel.Name = "cyanLabel";
			this.cyanLabel.Size = new System.Drawing.Size(40, 23);
			this.cyanLabel.TabIndex = 75;
			this.cyanLabel.Text = "Cyan:";
			this.cyanLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// whiteB
			// 
			this.whiteB.Location = new System.Drawing.Point(168, 96);
			this.whiteB.Name = "whiteB";
			this.whiteB.Size = new System.Drawing.Size(32, 23);
			this.whiteB.TabIndex = 84;
			this.whiteB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// whiteG
			// 
			this.whiteG.Location = new System.Drawing.Point(128, 96);
			this.whiteG.Name = "whiteG";
			this.whiteG.Size = new System.Drawing.Size(32, 23);
			this.whiteG.TabIndex = 83;
			this.whiteG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// whiteR
			// 
			this.whiteR.Location = new System.Drawing.Point(88, 96);
			this.whiteR.Name = "whiteR";
			this.whiteR.Size = new System.Drawing.Size(32, 23);
			this.whiteR.TabIndex = 82;
			this.whiteR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// whiteEdit
			// 
			this.whiteEdit.Location = new System.Drawing.Point(240, 96);
			this.whiteEdit.Name = "whiteEdit";
			this.whiteEdit.Size = new System.Drawing.Size(24, 23);
			this.whiteEdit.TabIndex = 1;
			this.whiteEdit.TabStop = true;
			this.whiteEdit.Text = "Edit";
			this.whiteEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.whiteEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Edit_LinkClicked);
			// 
			// whiteLabel
			// 
			this.whiteLabel.BackColor = System.Drawing.SystemColors.Control;
			this.whiteLabel.ForeColor = System.Drawing.Color.White;
			this.whiteLabel.Location = new System.Drawing.Point(24, 96);
			this.whiteLabel.Name = "whiteLabel";
			this.whiteLabel.Size = new System.Drawing.Size(40, 23);
			this.whiteLabel.TabIndex = 80;
			this.whiteLabel.Text = "White:";
			this.whiteLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// restoreButton
			// 
			this.restoreButton.Location = new System.Drawing.Point(80, 472);
			this.restoreButton.Name = "restoreButton";
			this.restoreButton.Size = new System.Drawing.Size(120, 23);
			this.restoreButton.TabIndex = 85;
			this.restoreButton.Text = "Restore Defaults";
			this.restoreButton.Click += new System.EventHandler(this.restoreButton_Click);
			// 
			// Colors
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(296, 502);
			this.Controls.Add(this.restoreButton);
			this.Controls.Add(this.whiteB);
			this.Controls.Add(this.whiteG);
			this.Controls.Add(this.whiteR);
			this.Controls.Add(this.whiteEdit);
			this.Controls.Add(this.whiteLabel);
			this.Controls.Add(this.cyanB);
			this.Controls.Add(this.cyanG);
			this.Controls.Add(this.cyanR);
			this.Controls.Add(this.cyanEdit);
			this.Controls.Add(this.cyanLabel);
			this.Controls.Add(this.magentaB);
			this.Controls.Add(this.magentaG);
			this.Controls.Add(this.magentaR);
			this.Controls.Add(this.magentaEdit);
			this.Controls.Add(this.magentaLabel);
			this.Controls.Add(this.blueB);
			this.Controls.Add(this.blueG);
			this.Controls.Add(this.blueR);
			this.Controls.Add(this.blueEdit);
			this.Controls.Add(this.blueLabel);
			this.Controls.Add(this.yellowB);
			this.Controls.Add(this.yellowG);
			this.Controls.Add(this.yellowR);
			this.Controls.Add(this.yellowEdit);
			this.Controls.Add(this.yellowLabel);
			this.Controls.Add(this.dgreenB);
			this.Controls.Add(this.dgreenG);
			this.Controls.Add(this.dgreenR);
			this.Controls.Add(this.dgreenEdit);
			this.Controls.Add(this.dgreenLabel);
			this.Controls.Add(this.redB);
			this.Controls.Add(this.redG);
			this.Controls.Add(this.redR);
			this.Controls.Add(this.redEdit);
			this.Controls.Add(this.redLabel);
			this.Controls.Add(this.silverB);
			this.Controls.Add(this.silverG);
			this.Controls.Add(this.silverR);
			this.Controls.Add(this.silverEdit);
			this.Controls.Add(this.silverLabel);
			this.Controls.Add(this.grayB);
			this.Controls.Add(this.grayG);
			this.Controls.Add(this.grayR);
			this.Controls.Add(this.grayEdit);
			this.Controls.Add(this.grayLabel);
			this.Controls.Add(this.tealB);
			this.Controls.Add(this.tealG);
			this.Controls.Add(this.tealR);
			this.Controls.Add(this.tealEdit);
			this.Controls.Add(this.tealLabel);
			this.Controls.Add(this.purpleB);
			this.Controls.Add(this.purpleG);
			this.Controls.Add(this.purpleR);
			this.Controls.Add(this.purpleEdit);
			this.Controls.Add(this.purpleLabel);
			this.Controls.Add(this.navyB);
			this.Controls.Add(this.navyG);
			this.Controls.Add(this.navyR);
			this.Controls.Add(this.navyEdit);
			this.Controls.Add(this.navyLabel);
			this.Controls.Add(this.brownB);
			this.Controls.Add(this.brownG);
			this.Controls.Add(this.brownR);
			this.Controls.Add(this.brownEdit);
			this.Controls.Add(this.brownLabel);
			this.Controls.Add(this.greenB);
			this.Controls.Add(this.greenG);
			this.Controls.Add(this.greenR);
			this.Controls.Add(this.greenEdit);
			this.Controls.Add(this.greenLabel);
			this.Controls.Add(this.maroonB);
			this.Controls.Add(this.maroonG);
			this.Controls.Add(this.maroonR);
			this.Controls.Add(this.maroonEdit);
			this.Controls.Add(this.maroonLabel);
			this.Controls.Add(this.blackB);
			this.Controls.Add(this.blackG);
			this.Controls.Add(this.blackR);
			this.Controls.Add(this.blackEdit);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.blackLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "Colors";
			this.Text = "Colors";
			this.ResumeLayout(false);

		}
		#endregion

		private void Edit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			RGB edit = new RGB(sender, theTerminalWindow, current_profile);
			edit.ShowDialog();
			if (edit.get_changed())
				setLabels();
		}

		private void setLabels()
		{
			blackR.Text = theTerminalWindow.Colors[0].R.ToString();
			blackG.Text = theTerminalWindow.Colors[0].G.ToString();
			blackB.Text = theTerminalWindow.Colors[0].B.ToString();
			blackLabel.ForeColor = Color.FromArgb(Int32.Parse(blackR.Text), Int32.Parse(blackG.Text), Int32.Parse(blackB.Text));
			whiteR.Text = theTerminalWindow.Colors[1].R.ToString();
			whiteG.Text = theTerminalWindow.Colors[1].G.ToString();
			whiteB.Text = theTerminalWindow.Colors[1].B.ToString();
			whiteLabel.ForeColor = Color.FromArgb(Int32.Parse(whiteR.Text), Int32.Parse(whiteG.Text), Int32.Parse(whiteB.Text));
			redR.Text = theTerminalWindow.Colors[2].R.ToString();
			redG.Text = theTerminalWindow.Colors[2].G.ToString();
			redB.Text = theTerminalWindow.Colors[2].B.ToString();
			redLabel.ForeColor = Color.FromArgb(Int32.Parse(redR.Text), Int32.Parse(redG.Text), Int32.Parse(redB.Text));
			blueR.Text = theTerminalWindow.Colors[3].R.ToString();
			blueG.Text = theTerminalWindow.Colors[3].G.ToString();
			blueB.Text = theTerminalWindow.Colors[3].B.ToString();
			blueLabel.ForeColor = Color.FromArgb(Int32.Parse(blueR.Text), Int32.Parse(blueG.Text), Int32.Parse(blueB.Text));
			greenR.Text = theTerminalWindow.Colors[4].R.ToString();
			greenG.Text = theTerminalWindow.Colors[4].G.ToString();
			greenB.Text = theTerminalWindow.Colors[4].B.ToString();
			greenLabel.ForeColor = Color.FromArgb(Int32.Parse(greenR.Text), Int32.Parse(greenG.Text), Int32.Parse(greenB.Text));
			yellowR.Text = theTerminalWindow.Colors[5].R.ToString();
			yellowG.Text = theTerminalWindow.Colors[5].G.ToString();
			yellowB.Text = theTerminalWindow.Colors[5].B.ToString();
			yellowLabel.ForeColor = Color.FromArgb(Int32.Parse(yellowR.Text), Int32.Parse(yellowG.Text), Int32.Parse(yellowB.Text));
			cyanR.Text = theTerminalWindow.Colors[6].R.ToString();
			cyanG.Text = theTerminalWindow.Colors[6].G.ToString();
			cyanB.Text = theTerminalWindow.Colors[6].B.ToString();
			cyanLabel.ForeColor = Color.FromArgb(Int32.Parse(cyanR.Text), Int32.Parse(cyanG.Text), Int32.Parse(cyanB.Text));
			magentaR.Text = theTerminalWindow.Colors[7].R.ToString();
			magentaG.Text = theTerminalWindow.Colors[7].G.ToString();
			magentaB.Text = theTerminalWindow.Colors[7].B.ToString();
			magentaLabel.ForeColor = Color.FromArgb(Int32.Parse(magentaR.Text), Int32.Parse(magentaG.Text), Int32.Parse(magentaB.Text));
			maroonR.Text = theTerminalWindow.Colors[8].R.ToString();
			maroonG.Text = theTerminalWindow.Colors[8].G.ToString();
			maroonB.Text = theTerminalWindow.Colors[8].B.ToString();
			maroonLabel.ForeColor = Color.FromArgb(Int32.Parse(maroonR.Text), Int32.Parse(maroonG.Text), Int32.Parse(maroonB.Text));
			dgreenR.Text = theTerminalWindow.Colors[9].R.ToString();
			dgreenG.Text = theTerminalWindow.Colors[9].G.ToString();
			dgreenB.Text = theTerminalWindow.Colors[9].B.ToString();
			dgreenLabel.ForeColor = Color.FromArgb(Int32.Parse(dgreenR.Text), Int32.Parse(dgreenG.Text), Int32.Parse(dgreenB.Text));
			navyR.Text = theTerminalWindow.Colors[10].R.ToString();
			navyG.Text = theTerminalWindow.Colors[10].G.ToString();
			navyB.Text = theTerminalWindow.Colors[10].B.ToString();
			navyLabel.ForeColor = Color.FromArgb(Int32.Parse(navyR.Text), Int32.Parse(navyG.Text), Int32.Parse(navyB.Text));
			brownR.Text = theTerminalWindow.Colors[11].R.ToString();
			brownG.Text = theTerminalWindow.Colors[11].G.ToString();
			brownB.Text = theTerminalWindow.Colors[11].B.ToString();
			brownLabel.ForeColor = Color.FromArgb(Int32.Parse(brownR.Text), Int32.Parse(brownG.Text), Int32.Parse(brownB.Text));
			tealR.Text = theTerminalWindow.Colors[12].R.ToString();
			tealG.Text = theTerminalWindow.Colors[12].G.ToString();
			tealB.Text = theTerminalWindow.Colors[12].B.ToString();
			tealLabel.ForeColor = Color.FromArgb(Int32.Parse(tealR.Text), Int32.Parse(tealG.Text), Int32.Parse(tealB.Text));
			purpleR.Text = theTerminalWindow.Colors[13].R.ToString();
			purpleG.Text = theTerminalWindow.Colors[13].G.ToString();
			purpleB.Text = theTerminalWindow.Colors[13].B.ToString();
			purpleLabel.ForeColor = Color.FromArgb(Int32.Parse(purpleR.Text), Int32.Parse(purpleG.Text), Int32.Parse(purpleB.Text));
			silverR.Text = theTerminalWindow.Colors[14].R.ToString();
			silverG.Text = theTerminalWindow.Colors[14].G.ToString();
			silverB.Text = theTerminalWindow.Colors[14].B.ToString();
			silverLabel.ForeColor = Color.FromArgb(Int32.Parse(silverR.Text), Int32.Parse(silverG.Text), Int32.Parse(silverB.Text));
			grayR.Text = theTerminalWindow.Colors[15].R.ToString();
			grayG.Text = theTerminalWindow.Colors[15].G.ToString();
			grayB.Text = theTerminalWindow.Colors[15].B.ToString();
			grayLabel.ForeColor = Color.FromArgb(Int32.Parse(grayR.Text), Int32.Parse(grayG.Text), Int32.Parse(grayB.Text));
		}

		private void restoreButton_Click(object sender, System.EventArgs e)
    
		{
			current_profile.initialize_colors();
			theTerminalWindow.Colors = current_profile.Colors;
			setLabels();
		}
	}
}
