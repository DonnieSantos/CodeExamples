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
	public class Triggers : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox triggerList;
		private System.Windows.Forms.TextBox triggerText;
		private System.Windows.Forms.Button newTriggerButton;
		private System.Windows.Forms.Button triggerEditButton;
		private System.Windows.Forms.Button triggerDeleteButton;
		private System.Windows.Forms.Button triggerOKButton;
		private System.Windows.Forms.Label triggerLabel;
		private System.Windows.Forms.Label triggerOutLabel;
		private action_list AC;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Triggers(action_list act)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			AC = act;
			for (int i = 0; i < AC.size(); i++)
			{
				action a = (action)AC.list[i];
				triggerList.Items.Add(a.get_trigger());
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
			this.triggerList = new System.Windows.Forms.ListBox();
			this.triggerText = new System.Windows.Forms.TextBox();
			this.newTriggerButton = new System.Windows.Forms.Button();
			this.triggerEditButton = new System.Windows.Forms.Button();
			this.triggerDeleteButton = new System.Windows.Forms.Button();
			this.triggerOKButton = new System.Windows.Forms.Button();
			this.triggerLabel = new System.Windows.Forms.Label();
			this.triggerOutLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// triggerList
			// 
			this.triggerList.Location = new System.Drawing.Point(8, 24);
			this.triggerList.Name = "triggerList";
			this.triggerList.Size = new System.Drawing.Size(120, 225);
			this.triggerList.TabIndex = 0;
			this.triggerList.SelectedIndexChanged += new System.EventHandler(this.triggerList_SelectedIndexChanged);
			// 
			// triggerText
			// 
			this.triggerText.Location = new System.Drawing.Point(136, 24);
			this.triggerText.Multiline = true;
			this.triggerText.Name = "triggerText";
			this.triggerText.Size = new System.Drawing.Size(440, 208);
			this.triggerText.TabIndex = 1;
			this.triggerText.Text = "";
			// 
			// newTriggerButton
			// 
			this.newTriggerButton.Location = new System.Drawing.Point(136, 240);
			this.newTriggerButton.Name = "newTriggerButton";
			this.newTriggerButton.TabIndex = 2;
			this.newTriggerButton.Text = "New";
			this.newTriggerButton.Click += new System.EventHandler(this.newTriggerButton_Click);
			// 
			// triggerEditButton
			// 
			this.triggerEditButton.Location = new System.Drawing.Point(224, 240);
			this.triggerEditButton.Name = "triggerEditButton";
			this.triggerEditButton.TabIndex = 3;
			this.triggerEditButton.Text = "Edit";
			this.triggerEditButton.Click += new System.EventHandler(this.triggerEditButton_Click);
			// 
			// triggerDeleteButton
			// 
			this.triggerDeleteButton.Location = new System.Drawing.Point(312, 240);
			this.triggerDeleteButton.Name = "triggerDeleteButton";
			this.triggerDeleteButton.TabIndex = 4;
			this.triggerDeleteButton.Text = "Delete";
			this.triggerDeleteButton.Click += new System.EventHandler(this.triggerDeleteButton_Click);
			// 
			// triggerOKButton
			// 
			this.triggerOKButton.Location = new System.Drawing.Point(480, 240);
			this.triggerOKButton.Name = "triggerOKButton";
			this.triggerOKButton.TabIndex = 6;
			this.triggerOKButton.Text = "OK";
			this.triggerOKButton.Click += new System.EventHandler(this.triggerOKButton_Click);
			// 
			// triggerLabel
			// 
			this.triggerLabel.Location = new System.Drawing.Point(8, 8);
			this.triggerLabel.Name = "triggerLabel";
			this.triggerLabel.Size = new System.Drawing.Size(100, 16);
			this.triggerLabel.TabIndex = 7;
			this.triggerLabel.Text = "Trigger:";
			this.triggerLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// triggerOutLabel
			// 
			this.triggerOutLabel.Location = new System.Drawing.Point(136, 8);
			this.triggerOutLabel.Name = "triggerOutLabel";
			this.triggerOutLabel.Size = new System.Drawing.Size(100, 16);
			this.triggerOutLabel.TabIndex = 8;
			this.triggerOutLabel.Text = "Output:";
			this.triggerOutLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// Triggers
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(584, 266);
			this.Controls.Add(this.triggerOutLabel);
			this.Controls.Add(this.triggerLabel);
			this.Controls.Add(this.triggerOKButton);
			this.Controls.Add(this.triggerDeleteButton);
			this.Controls.Add(this.triggerEditButton);
			this.Controls.Add(this.newTriggerButton);
			this.Controls.Add(this.triggerText);
			this.Controls.Add(this.triggerList);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "Triggers";
			this.Text = "Triggers";
			this.ResumeLayout(false);

		}
		#endregion

		private void triggerOKButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void newTriggerButton_Click(object sender, System.EventArgs e)
		{
			AddTrigger AT = new AddTrigger();
			AT.ShowDialog();
			
			if (AT.get_add())
			{
				AC.add_action(AT.triggerText.Text, AT.triggerOutput.Text);
				triggerList.Items.Clear();
				for (int i = 0; i < AC.size(); i++)
				{
					action a = (action)AC.list[i];
					triggerList.Items.Add(a.get_trigger());
				}
			}
		}

		private void triggerEditButton_Click(object sender, System.EventArgs e)
		{
			AddTrigger ET = new AddTrigger();
			
			action a = (action)AC.list[triggerList.SelectedIndex];
			ET.triggerText.Text = a.get_trigger();
			ET.triggerOutput.Text = a.get_outcome();
			ET.ShowDialog();
			

			if (ET.get_add())
			{
				AC.remove_action(a.get_trigger());
				AC.add_action(ET.triggerText.Text, ET.triggerOutput.Text);
				triggerList.Items.Clear();
				for (int i = 0; i < AC.size(); i++)
				{
					a = (action)AC.list[i];
					triggerList.Items.Add(a.get_trigger());
				}
			}
		}

		private void triggerDeleteButton_Click(object sender, System.EventArgs e)
		{
			DialogResult result;
			action a = (action)AC.list[triggerList.SelectedIndex];
			result = MessageBox.Show("Delete this action?", "Delete?", MessageBoxButtons.YesNo);
			if (result == DialogResult.Yes)
			{
				AC.remove_action(a.get_trigger());
				triggerList.Items.Clear();
				for (int i = 0; i < AC.size(); i++)
				{
					a = (action)AC.list[i];
					triggerList.Items.Add(a.get_trigger());
				}
			}
		}

		private void triggerList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			for (int i = 0; i < AC.size(); i++)
			{
				action a = (action)AC.list[i];
				if (i == triggerList.SelectedIndex)
					triggerText.Text = a.get_outcome();
			}
		}
	}
}
