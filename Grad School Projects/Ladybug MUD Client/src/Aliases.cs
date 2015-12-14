using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MUD
{
	/// <summary>
	/// Summary description for Aliases.
	/// </summary>
	public class Aliases : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox aliasList;
		private System.Windows.Forms.TextBox aliasText;
		private System.Windows.Forms.Button newAliasButton;
		private System.Windows.Forms.Button aliasEditButton;
		private System.Windows.Forms.Button aliasDeleteButton;
		private System.Windows.Forms.Button aliasOKButton;
		private System.Windows.Forms.Label aliasLabel;
		private System.Windows.Forms.Label aliasTransLabel;
		private alias_list AL;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Aliases(alias_list ali)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			AL = ali;
			for (int i = 0; i < AL.size(); i++)
			{
				alias a = (alias)AL.list[i];
				aliasList.Items.Add(a.name);
			}
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
			this.aliasList = new System.Windows.Forms.ListBox();
			this.aliasText = new System.Windows.Forms.TextBox();
			this.newAliasButton = new System.Windows.Forms.Button();
			this.aliasEditButton = new System.Windows.Forms.Button();
			this.aliasDeleteButton = new System.Windows.Forms.Button();
			this.aliasOKButton = new System.Windows.Forms.Button();
			this.aliasLabel = new System.Windows.Forms.Label();
			this.aliasTransLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// aliasList
			// 
			this.aliasList.Location = new System.Drawing.Point(8, 24);
			this.aliasList.Name = "aliasList";
			this.aliasList.Size = new System.Drawing.Size(120, 225);
			this.aliasList.TabIndex = 0;
			this.aliasList.SelectedIndexChanged += new System.EventHandler(this.aliasList_SelectedIndexChanged);
			// 
			// aliasText
			// 
			this.aliasText.Location = new System.Drawing.Point(136, 24);
			this.aliasText.Multiline = true;
			this.aliasText.Name = "aliasText";
			this.aliasText.Size = new System.Drawing.Size(440, 208);
			this.aliasText.TabIndex = 1;
			this.aliasText.Text = "";
			// 
			// newAliasButton
			// 
			this.newAliasButton.Location = new System.Drawing.Point(136, 240);
			this.newAliasButton.Name = "newAliasButton";
			this.newAliasButton.TabIndex = 2;
			this.newAliasButton.Text = "New";
			this.newAliasButton.Click += new System.EventHandler(this.newAliasButton_Click);
			// 
			// aliasEditButton
			// 
			this.aliasEditButton.Location = new System.Drawing.Point(224, 240);
			this.aliasEditButton.Name = "aliasEditButton";
			this.aliasEditButton.TabIndex = 3;
			this.aliasEditButton.Text = "Edit";
			this.aliasEditButton.Click += new System.EventHandler(this.aliasEditButton_Click);
			// 
			// aliasDeleteButton
			// 
			this.aliasDeleteButton.Location = new System.Drawing.Point(312, 240);
			this.aliasDeleteButton.Name = "aliasDeleteButton";
			this.aliasDeleteButton.TabIndex = 4;
			this.aliasDeleteButton.Text = "Delete";
			this.aliasDeleteButton.Click += new System.EventHandler(this.aliasDeleteButton_Click);
			// 
			// aliasOKButton
			// 
			this.aliasOKButton.Location = new System.Drawing.Point(480, 240);
			this.aliasOKButton.Name = "aliasOKButton";
			this.aliasOKButton.TabIndex = 6;
			this.aliasOKButton.Text = "OK";
			this.aliasOKButton.Click += new System.EventHandler(this.aliasOKButton_Click);
			// 
			// aliasLabel
			// 
			this.aliasLabel.Location = new System.Drawing.Point(8, 8);
			this.aliasLabel.Name = "aliasLabel";
			this.aliasLabel.Size = new System.Drawing.Size(100, 16);
			this.aliasLabel.TabIndex = 7;
			this.aliasLabel.Text = "Alias:";
			this.aliasLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// aliasTransLabel
			// 
			this.aliasTransLabel.Location = new System.Drawing.Point(136, 8);
			this.aliasTransLabel.Name = "aliasTransLabel";
			this.aliasTransLabel.Size = new System.Drawing.Size(100, 16);
			this.aliasTransLabel.TabIndex = 8;
			this.aliasTransLabel.Text = "Translation:";
			this.aliasTransLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// Aliases
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(584, 266);
			this.Controls.Add(this.aliasTransLabel);
			this.Controls.Add(this.aliasLabel);
			this.Controls.Add(this.aliasOKButton);
			this.Controls.Add(this.aliasDeleteButton);
			this.Controls.Add(this.aliasEditButton);
			this.Controls.Add(this.newAliasButton);
			this.Controls.Add(this.aliasText);
			this.Controls.Add(this.aliasList);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "Aliases";
			this.Text = "Aliases";
			this.ResumeLayout(false);

		}
		#endregion

		private void aliasOKButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void newAliasButton_Click(object sender, System.EventArgs e)
		{
			AddAlias AA = new AddAlias();
			AA.ShowDialog();
			
			if (AA.get_add())
			{
				AL.add_alias(AA.aliasText.Text, AA.aliasOutput.Text);
				aliasList.Items.Clear();
				for (int i = 0; i < AL.size(); i++)
				{
					alias a = (alias)AL.list[i];
					aliasList.Items.Add(a.name);
				}
			}
		}

		private void aliasEditButton_Click(object sender, System.EventArgs e)
		{
			AddAlias EA = new AddAlias();
			
			alias a = (alias)AL.list[aliasList.SelectedIndex];
			EA.aliasText.Text = a.name;
			EA.aliasOutput.Text = a.output;
			EA.ShowDialog();
			

			if (EA.get_add())
			{
				a.name = EA.aliasText.Text;
				a.output = EA.aliasOutput.Text;
				aliasList.Items.Clear();
				for (int i = 0; i < AL.size(); i++)
				{
					a = (alias)AL.list[i];
					aliasList.Items.Add(a.name);
				}
			}
		}

		private void aliasDeleteButton_Click(object sender, System.EventArgs e)
		{
			DialogResult result;
			alias a = (alias)AL.list[aliasList.SelectedIndex];
			result = MessageBox.Show("Delete this alias?", "Delete?", MessageBoxButtons.YesNo);
			if (result == DialogResult.Yes)
			{
				AL.remove_alias(a.name);
				aliasList.Items.Clear();
				for (int i = 0; i < AL.size(); i++)
				{
					a = (alias)AL.list[i];
					aliasList.Items.Add(a.name);
				}
			}
		}

		private void aliasList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			for (int i = 0; i < AL.size(); i++)
			{
				alias a = (alias)AL.list[i];
				if (i == aliasList.SelectedIndex)
					aliasText.Text = a.output;
			}
		}
	}
}
