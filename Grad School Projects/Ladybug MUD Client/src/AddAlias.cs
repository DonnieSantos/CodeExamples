using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MUD
{
	/// <summary>
	/// Summary description for AddAlias.
	/// </summary>
	public class AddAlias : System.Windows.Forms.Form
	{
		public System.Windows.Forms.TextBox aliasText;
		public System.Windows.Forms.TextBox aliasOutput;
		private System.Windows.Forms.Label aliasLabel;
		private System.Windows.Forms.Label outputLabel;
		private System.Windows.Forms.Button aliasAddButton;
		private System.Windows.Forms.Button aliasCancelButton;
		private bool add;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AddAlias()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			add = false;

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
			this.aliasText = new System.Windows.Forms.TextBox();
			this.aliasOutput = new System.Windows.Forms.TextBox();
			this.aliasLabel = new System.Windows.Forms.Label();
			this.outputLabel = new System.Windows.Forms.Label();
			this.aliasAddButton = new System.Windows.Forms.Button();
			this.aliasCancelButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// aliasText
			// 
			this.aliasText.Location = new System.Drawing.Point(56, 32);
			this.aliasText.Name = "aliasText";
			this.aliasText.Size = new System.Drawing.Size(272, 20);
			this.aliasText.TabIndex = 0;
			this.aliasText.Text = "";
			// 
			// aliasOutput
			// 
			this.aliasOutput.Location = new System.Drawing.Point(56, 64);
			this.aliasOutput.Name = "aliasOutput";
			this.aliasOutput.Size = new System.Drawing.Size(272, 20);
			this.aliasOutput.TabIndex = 1;
			this.aliasOutput.Text = "";
			// 
			// aliasLabel
			// 
			this.aliasLabel.Location = new System.Drawing.Point(8, 32);
			this.aliasLabel.Name = "aliasLabel";
			this.aliasLabel.Size = new System.Drawing.Size(32, 23);
			this.aliasLabel.TabIndex = 2;
			this.aliasLabel.Text = "Alias:";
			// 
			// outputLabel
			// 
			this.outputLabel.Location = new System.Drawing.Point(8, 64);
			this.outputLabel.Name = "outputLabel";
			this.outputLabel.Size = new System.Drawing.Size(48, 23);
			this.outputLabel.TabIndex = 3;
			this.outputLabel.Text = "Output:";
			// 
			// aliasAddButton
			// 
			this.aliasAddButton.Location = new System.Drawing.Point(96, 104);
			this.aliasAddButton.Name = "aliasAddButton";
			this.aliasAddButton.TabIndex = 4;
			this.aliasAddButton.Text = "Add";
			this.aliasAddButton.Click += new System.EventHandler(this.aliasAddButton_Click);
			// 
			// aliasCancelButton
			// 
			this.aliasCancelButton.Location = new System.Drawing.Point(208, 104);
			this.aliasCancelButton.Name = "aliasCancelButton";
			this.aliasCancelButton.TabIndex = 5;
			this.aliasCancelButton.Text = "Cancel";
			this.aliasCancelButton.Click += new System.EventHandler(this.aliasCancelButton_Click);
			// 
			// AddAlias
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(360, 134);
			this.Controls.Add(this.aliasCancelButton);
			this.Controls.Add(this.aliasAddButton);
			this.Controls.Add(this.outputLabel);
			this.Controls.Add(this.aliasLabel);
			this.Controls.Add(this.aliasOutput);
			this.Controls.Add(this.aliasText);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "AddAlias";
			this.Text = "Add Alias";
			this.ResumeLayout(false);

		}
		#endregion

		private void aliasAddButton_Click(object sender, System.EventArgs e)
		{
			if (this.aliasText.Text != "" && this.aliasOutput.Text != "")
			{
				add = true;
				this.Close();
			}
			else if (this.aliasText.Text == "")
				MessageBox.Show("Missing alias");
			else
				MessageBox.Show("Missing alias output");
		}

		private void aliasCancelButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		public bool get_add()
		{
			return this.add;
		}
	}
}
