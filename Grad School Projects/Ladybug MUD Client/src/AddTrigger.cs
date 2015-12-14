using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MUD
{
	/// <summary>
	/// Summary description for Addtrigger.
	/// </summary>
	public class AddTrigger : System.Windows.Forms.Form
	{
		public System.Windows.Forms.TextBox triggerText;
		public System.Windows.Forms.TextBox triggerOutput;
		private System.Windows.Forms.Label triggerLabel;
		private System.Windows.Forms.Label outputLabel;
		private System.Windows.Forms.Button triggerAddButton;
		private System.Windows.Forms.Button triggerCancelButton;
		private bool add;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AddTrigger()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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
			this.triggerText = new System.Windows.Forms.TextBox();
			this.triggerOutput = new System.Windows.Forms.TextBox();
			this.triggerLabel = new System.Windows.Forms.Label();
			this.outputLabel = new System.Windows.Forms.Label();
			this.triggerAddButton = new System.Windows.Forms.Button();
			this.triggerCancelButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// triggerText
			// 
			this.triggerText.Location = new System.Drawing.Point(56, 32);
			this.triggerText.Name = "triggerText";
			this.triggerText.Size = new System.Drawing.Size(272, 20);
			this.triggerText.TabIndex = 0;
			this.triggerText.Text = "";
			// 
			// triggerOutput
			// 
			this.triggerOutput.Location = new System.Drawing.Point(56, 64);
			this.triggerOutput.Name = "triggerOutput";
			this.triggerOutput.Size = new System.Drawing.Size(272, 20);
			this.triggerOutput.TabIndex = 1;
			this.triggerOutput.Text = "";
			// 
			// triggerLabel
			// 
			this.triggerLabel.Location = new System.Drawing.Point(8, 32);
			this.triggerLabel.Name = "triggerLabel";
			this.triggerLabel.Size = new System.Drawing.Size(48, 23);
			this.triggerLabel.TabIndex = 2;
			this.triggerLabel.Text = "Trigger:";
			// 
			// outputLabel
			// 
			this.outputLabel.Location = new System.Drawing.Point(8, 64);
			this.outputLabel.Name = "outputLabel";
			this.outputLabel.Size = new System.Drawing.Size(48, 23);
			this.outputLabel.TabIndex = 3;
			this.outputLabel.Text = "Output:";
			// 
			// triggerAddButton
			// 
			this.triggerAddButton.Location = new System.Drawing.Point(96, 104);
			this.triggerAddButton.Name = "triggerAddButton";
			this.triggerAddButton.TabIndex = 4;
			this.triggerAddButton.Text = "Add";
			this.triggerAddButton.Click += new System.EventHandler(this.triggerAddButton_Click);
			// 
			// triggerCancelButton
			// 
			this.triggerCancelButton.Location = new System.Drawing.Point(208, 104);
			this.triggerCancelButton.Name = "triggerCancelButton";
			this.triggerCancelButton.TabIndex = 5;
			this.triggerCancelButton.Text = "Cancel";
			this.triggerCancelButton.Click += new System.EventHandler(this.triggerCancelButton_Click);
			// 
			// AddTrigger
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(360, 134);
			this.Controls.Add(this.triggerCancelButton);
			this.Controls.Add(this.triggerAddButton);
			this.Controls.Add(this.outputLabel);
			this.Controls.Add(this.triggerLabel);
			this.Controls.Add(this.triggerOutput);
			this.Controls.Add(this.triggerText);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "AddTrigger";
			this.Text = "Add Trigger";
			this.ResumeLayout(false);

		}
		#endregion

		private void triggerAddButton_Click(object sender, System.EventArgs e)
		{
			if (this.triggerText.Text != "" && this.triggerOutput.Text != "") 
			{
				this.add = true;
				this.Close();
			}
			else if (this.triggerText.Text == "")
				MessageBox.Show("Missing trigger");
			else
				MessageBox.Show("Missing trigger output");
		}

		private void triggerCancelButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		public bool get_add()
		{
			return this.add;
		}
	}
}
