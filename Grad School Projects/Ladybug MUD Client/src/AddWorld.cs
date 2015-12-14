using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MUD
{
	/// <summary>
	/// Summary description for AddWorld.
	/// </summary>
	public class AddWorld : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox worldName;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		private bool OK;
		private bool Cancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AddWorld()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			OK = false;
			Cancel = false;

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.worldName = new System.Windows.Forms.TextBox();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// worldName
			// 
			this.worldName.Location = new System.Drawing.Point(40, 32);
			this.worldName.Name = "worldName";
			this.worldName.Size = new System.Drawing.Size(216, 20);
			this.worldName.TabIndex = 0;
			this.worldName.Text = "";
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(56, 72);
			this.okButton.Name = "okButton";
			this.okButton.TabIndex = 1;
			this.okButton.Text = "OK";
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(168, 72);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.TabIndex = 2;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// AddWorld
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 110);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.worldName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "AddWorld";
			this.Text = "AddWorld";
			this.ResumeLayout(false);

		}
		#endregion

		public string getWorldName()
		{
			return this.worldName.Text;
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			if (this.worldName.Text == "")
				MessageBox.Show("Please name your world.");
			else
			{
				OK = true;
				this.Close();
			}
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			this.Cancel = true;
			this.Close();
		}

		public bool getOK()
		{
			return OK;
		}

		public bool getCancel()
		{
			return Cancel;
		}
	}
}
