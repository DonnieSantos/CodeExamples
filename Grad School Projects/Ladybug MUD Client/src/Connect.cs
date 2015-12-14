using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MUD
{
	/// <summary>
	/// Summary description for Connect.
	/// </summary>
	
	public class Connect : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label connectLabel;
		private System.Windows.Forms.ComboBox connectList;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button connectButton;
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.TextBox txtPort;
		private System.Windows.Forms.Label label2;
		private Profile current_profile;
    		
		private string host_address;
		private int host_port;
		private bool clicked_connect;
		private System.Windows.Forms.TextBox txtAddress;
		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.Button removeButton;
				
		private System.ComponentModel.Container components = null;

		public Connect(Profile current)		
		{
			InitializeComponent();
       
			host_address = "null";
			host_port = 23;
			clicked_connect = false;
			this.current_profile = current;
			this.updateList();
		}
		
		public string get_hostaddress() { return host_address;    }
		public int get_port()           { return host_port;       }
		public bool get_connect()       { return clicked_connect; }

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
			this.connectLabel = new System.Windows.Forms.Label();
			this.txtAddress = new System.Windows.Forms.TextBox();
			this.connectList = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.connectButton = new System.Windows.Forms.Button();
			this.closeButton = new System.Windows.Forms.Button();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.addButton = new System.Windows.Forms.Button();
			this.removeButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// connectLabel
			// 
			this.connectLabel.Location = new System.Drawing.Point(8, 8);
			this.connectLabel.Name = "connectLabel";
			this.connectLabel.Size = new System.Drawing.Size(72, 24);
			this.connectLabel.TabIndex = 0;
			this.connectLabel.Text = "Connect To:";
			this.connectLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtAddress
			// 
			this.txtAddress.Location = new System.Drawing.Point(80, 80);
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.Size = new System.Drawing.Size(120, 20);
			this.txtAddress.TabIndex = 2;
			this.txtAddress.Text = "";
			// 
			// connectList
			// 
			this.connectList.Location = new System.Drawing.Point(80, 8);
			this.connectList.Name = "connectList";
			this.connectList.Size = new System.Drawing.Size(121, 21);
			this.connectList.TabIndex = 1;
			this.connectList.Text = "Saved world...";
			this.connectList.SelectedIndexChanged += new System.EventHandler(this.connectList_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 80);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 24);
			this.label1.TabIndex = 4;
			this.label1.Text = "Address:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// connectButton
			// 
			this.connectButton.Location = new System.Drawing.Point(216, 72);
			this.connectButton.Name = "connectButton";
			this.connectButton.TabIndex = 4;
			this.connectButton.Text = "Connect";
			this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
			// 
			// closeButton
			// 
			this.closeButton.Location = new System.Drawing.Point(216, 104);
			this.closeButton.Name = "closeButton";
			this.closeButton.TabIndex = 5;
			this.closeButton.Text = "Close";
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// txtPort
			// 
			this.txtPort.Location = new System.Drawing.Point(80, 104);
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(72, 20);
			this.txtPort.TabIndex = 3;
			this.txtPort.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 104);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 24);
			this.label2.TabIndex = 8;
			this.label2.Text = "Port:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// addButton
			// 
			this.addButton.Location = new System.Drawing.Point(216, 8);
			this.addButton.Name = "addButton";
			this.addButton.TabIndex = 9;
			this.addButton.Text = "Add...";
			this.addButton.Click += new System.EventHandler(this.addButton_Click);
			// 
			// removeButton
			// 
			this.removeButton.Location = new System.Drawing.Point(216, 40);
			this.removeButton.Name = "removeButton";
			this.removeButton.TabIndex = 10;
			this.removeButton.Text = "Remove...";
			this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
			// 
			// Connect
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(304, 142);
			this.Controls.Add(this.removeButton);
			this.Controls.Add(this.addButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtPort);
			this.Controls.Add(this.txtAddress);
			this.Controls.Add(this.closeButton);
			this.Controls.Add(this.connectButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.connectList);
			this.Controls.Add(this.connectLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "Connect";
			this.Text = "Connect";
			this.ResumeLayout(false);

		}
		#endregion

		private void closeButton_Click(object sender, System.EventArgs e)
		{
			clicked_connect = false;
			this.Close();
		}

		private void connectButton_Click(object sender, System.EventArgs e)   
		{
			try      
			{ 
				txtPort.Text = txtPort.Text.Trim();
				host_port = Int32.Parse(txtPort.Text);
			}
      
			catch (FormatException)
			{
				MessageBox.Show("Invalid port number specified.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
      
			host_address = txtAddress.Text;
			clicked_connect = true;      
			this.Close();
		}

		public void updateList()
		{
			this.connectList.Items.Clear();
			if (this.current_profile != null)
			{
				for (int i = 0; i < current_profile.get_num_worlds(); i++)
					this.connectList.Items.Add(current_profile.get_world(i).name);
			}
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			if (this.txtAddress.Text == "" || this.txtPort.Text == "")
			{
				MessageBox.Show("Please fill out the address and port fields to add a world.");
				return;
			}
			AddWorld ad = new AddWorld();
			ad.ShowDialog();

			if (ad.getOK())
			{
				if (this.connectList.Items.Contains(ad.getWorldName()))
				{
					DialogResult result;
					result = MessageBox.Show("Would you like to update " + ad.getWorldName() + " ?", "Overwrite?", MessageBoxButtons.YesNo);
					if (result == DialogResult.Yes)
					{
						this.current_profile.remove_world(ad.getWorldName());
						this.current_profile.add_world(ad.getWorldName(), this.txtAddress.Text, Int32.Parse(this.txtPort.Text));
						ad.Close();
					}
					else
						ad.Text = "";
				}
				else
				{
					this.current_profile.add_world(ad.getWorldName(), this.txtAddress.Text, Int32.Parse(this.txtPort.Text));
					ad.Close();
				}
				this.updateList();
			}
			
			if (ad.getCancel())
				ad.Close();
		}

		private void removeButton_Click(object sender, EventArgs e)
		{
			string selected = this.connectList.Text;
			if (selected != "" && selected != "Saved world...")
			{
				DialogResult result;
				result = MessageBox.Show("Are you sure you want to delete " + selected, "Delete?", MessageBoxButtons.YesNo);
				if (result == DialogResult.Yes)
				{
					this.current_profile.remove_world(this.connectList.Text);
					this.updateList();
					this.connectList.Text = "";
					this.txtAddress.Text = "";
					this.txtPort.Text = "";
				}
			}
			else
				MessageBox.Show("Please select a world to delete.");
		}

		private void connectList_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.txtAddress.Text = this.current_profile.get_world(this.connectList.SelectedIndex).host;
			this.txtPort.Text = this.current_profile.get_world(this.connectList.SelectedIndex).port.ToString();
		}
	}
}
