namespace Arebis.QuickQueryBuilder
{
	partial class DatabaseConnectionDialog
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.ConnectorTabs = new System.Windows.Forms.TabControl();
			this.MSSql = new System.Windows.Forms.TabPage();
			this.SqlConnectionPanel = new Microsoft.Data.ConnectionUI.SqlConnectionUIControl();
			this.Oracle = new System.Windows.Forms.TabPage();
			this.OracleConnectionPanel = new Microsoft.Data.ConnectionUI.OracleConnectionUIControl();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.TestBtn = new System.Windows.Forms.Button();
			this.OkBtn = new System.Windows.Forms.Button();
			this.advancedButton = new System.Windows.Forms.Button();
			this.ConnectorTabs.SuspendLayout();
			this.MSSql.SuspendLayout();
			this.Oracle.SuspendLayout();
			this.SuspendLayout();
			// 
			// ConnectorTabs
			// 
			this.ConnectorTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ConnectorTabs.Controls.Add(this.MSSql);
			this.ConnectorTabs.Controls.Add(this.Oracle);
			this.ConnectorTabs.Location = new System.Drawing.Point(12, 12);
			this.ConnectorTabs.Name = "ConnectorTabs";
			this.ConnectorTabs.SelectedIndex = 0;
			this.ConnectorTabs.Size = new System.Drawing.Size(397, 406);
			this.ConnectorTabs.TabIndex = 0;
			this.ConnectorTabs.Selected += new System.Windows.Forms.TabControlEventHandler(this.ConnectorTabs_Selected);
			// 
			// MSSql
			// 
			this.MSSql.Controls.Add(this.SqlConnectionPanel);
			this.MSSql.Location = new System.Drawing.Point(4, 22);
			this.MSSql.Name = "MSSql";
			this.MSSql.Padding = new System.Windows.Forms.Padding(3);
			this.MSSql.Size = new System.Drawing.Size(389, 380);
			this.MSSql.TabIndex = 0;
			this.MSSql.Tag = "MSSql";
			this.MSSql.Text = "SQL Server";
			this.MSSql.UseVisualStyleBackColor = true;
			// 
			// SqlConnectionPanel
			// 
			this.SqlConnectionPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.SqlConnectionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SqlConnectionPanel.Location = new System.Drawing.Point(3, 3);
			this.SqlConnectionPanel.Margin = new System.Windows.Forms.Padding(0);
			this.SqlConnectionPanel.MinimumSize = new System.Drawing.Size(383, 374);
			this.SqlConnectionPanel.Name = "SqlConnectionPanel";
			this.SqlConnectionPanel.Size = new System.Drawing.Size(383, 374);
			this.SqlConnectionPanel.TabIndex = 0;
			// 
			// Oracle
			// 
			this.Oracle.Controls.Add(this.OracleConnectionPanel);
			this.Oracle.Location = new System.Drawing.Point(4, 22);
			this.Oracle.Name = "Oracle";
			this.Oracle.Padding = new System.Windows.Forms.Padding(3);
			this.Oracle.Size = new System.Drawing.Size(389, 380);
			this.Oracle.TabIndex = 1;
			this.Oracle.Tag = "Oracle";
			this.Oracle.Text = "Oracle";
			this.Oracle.UseVisualStyleBackColor = true;
			// 
			// OracleConnectionPanel
			// 
			this.OracleConnectionPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.OracleConnectionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.OracleConnectionPanel.Location = new System.Drawing.Point(3, 3);
			this.OracleConnectionPanel.Margin = new System.Windows.Forms.Padding(0);
			this.OracleConnectionPanel.MinimumSize = new System.Drawing.Size(383, 374);
			this.OracleConnectionPanel.Name = "OracleConnectionPanel";
			this.OracleConnectionPanel.Size = new System.Drawing.Size(383, 374);
			this.OracleConnectionPanel.TabIndex = 0;
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(334, 424);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 1;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
			// 
			// TestBtn
			// 
			this.TestBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.TestBtn.Location = new System.Drawing.Point(12, 424);
			this.TestBtn.Name = "TestBtn";
			this.TestBtn.Size = new System.Drawing.Size(75, 23);
			this.TestBtn.TabIndex = 1;
			this.TestBtn.Text = "Test";
			this.TestBtn.UseVisualStyleBackColor = true;
			this.TestBtn.Click += new System.EventHandler(this.TestBtn_Click);
			// 
			// OkBtn
			// 
			this.OkBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OkBtn.Location = new System.Drawing.Point(253, 424);
			this.OkBtn.Name = "OkBtn";
			this.OkBtn.Size = new System.Drawing.Size(75, 23);
			this.OkBtn.TabIndex = 1;
			this.OkBtn.Text = "OK";
			this.OkBtn.UseVisualStyleBackColor = true;
			this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
			// 
			// advancedButton
			// 
			this.advancedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.advancedButton.Location = new System.Drawing.Point(93, 424);
			this.advancedButton.Name = "advancedButton";
			this.advancedButton.Size = new System.Drawing.Size(75, 23);
			this.advancedButton.TabIndex = 1;
			this.advancedButton.Text = "Advanced...";
			this.advancedButton.UseVisualStyleBackColor = true;
			this.advancedButton.Click += new System.EventHandler(this.advancedButton_Click);
			// 
			// DatabaseConnectionDialog
			// 
			this.AcceptButton = this.OkBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(421, 459);
			this.ControlBox = false;
			this.Controls.Add(this.advancedButton);
			this.Controls.Add(this.TestBtn);
			this.Controls.Add(this.OkBtn);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.ConnectorTabs);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DatabaseConnectionDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Open Connection...";
			this.Load += new System.EventHandler(this.DatabaseConnectionDialog_Load);
			this.ConnectorTabs.ResumeLayout(false);
			this.MSSql.ResumeLayout(false);
			this.Oracle.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl ConnectorTabs;
		private System.Windows.Forms.TabPage MSSql;
		private Microsoft.Data.ConnectionUI.SqlConnectionUIControl SqlConnectionPanel;
		private System.Windows.Forms.TabPage Oracle;
		private Microsoft.Data.ConnectionUI.OracleConnectionUIControl OracleConnectionPanel;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Button TestBtn;
		private System.Windows.Forms.Button OkBtn;
		private System.Windows.Forms.Button advancedButton;
	}
}