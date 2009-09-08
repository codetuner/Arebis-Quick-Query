using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Arebis.QuickQueryBuilder.Windows;
using Microsoft.Data.ConnectionUI;
using Arebis.QuickQueryBuilder.Providers;
using Arebis.QuickQueryBuilder.Providers.MSSql;
using Arebis.QuickQueryBuilder.Providers.Oracle;

namespace Arebis.QuickQueryBuilder
{
	// Thanks to Daniel Portella:
	// http://undocnet.blogspot.com/2007/11/using-connection-dialog-from-visual.html
	// Requires references to:
	// - Microsoft.Data.ConnectionUI.dll
	// - Microsoft.Data.ConnectionUI.Dialog.dll
	// Those assemblies can be found in Common\IDE folder of VS.NET.

	/// <summary>
	/// Database connection dialog.
	/// </summary>
	public partial class DatabaseConnectionDialog : Form
	{
		private IDataConnectionProperties CurrentProps;
		private SqlConnectionProperties SqlProps = new SqlConnectionProperties();
		private OracleConnectionProperties OraProps = new OracleConnectionProperties();
		private IDatabaseProvider result;

		public DatabaseConnectionDialog()
		{
			InitializeComponent();

			OraProps.ConnectionStringBuilder.ConnectionString = String.Empty;
		}

		public IDatabaseProvider Result
		{
			get { return this.result; }
		}

		public static new IDatabaseProvider Show(IWin32Window owner)
		{
			DatabaseConnectionDialog dlg = new DatabaseConnectionDialog();
			dlg.ShowDialog(owner);
			return dlg.Result;
		}

		public static IDatabaseProvider Show(IWin32Window owner, string connectionType, string connectionString)
		{
			DatabaseConnectionDialog dlg = new DatabaseConnectionDialog();

			if (connectionType == "MSSql")
			{
				dlg.ConnectorTabs.SelectedTab = dlg.ConnectorTabs.TabPages[connectionType];
				dlg.SqlProps.ConnectionStringBuilder.ConnectionString = connectionString;
			}
			else if (connectionType == "Oracle")
			{
				dlg.ConnectorTabs.SelectedTab = dlg.ConnectorTabs.TabPages[connectionType];
				dlg.OraProps.ConnectionStringBuilder.ConnectionString = connectionString;
			}

			dlg.ShowDialog(owner);
			return dlg.Result;
		}

		private void DatabaseConnectionDialog_Load(object sender, EventArgs e)
		{
			this.SqlConnectionPanel.Initialize(SqlProps);
			this.SqlConnectionPanel.LoadProperties();
			this.OracleConnectionPanel.Initialize(OraProps);
			this.OracleConnectionPanel.LoadProperties();

			this.ConnectorTabs_Selected(this, null);
		}

		private void ConnectorTabs_Selected(object sender, TabControlEventArgs e)
		{
			if ((string)this.ConnectorTabs.SelectedTab.Tag == "MSSql")
				this.CurrentProps = this.SqlProps;
            else if ((string)this.ConnectorTabs.SelectedTab.Tag == "Oracle")
				this.CurrentProps = this.OraProps;
			else
				throw new NotImplementedException("Connection provider not implemented.");
		}

		private void TestBtn_Click(object sender, EventArgs e)
		{
			try
			{
				using (new WaitCursor(this))
				{
					this.CurrentProps.Test();
				}
				MessageBox.Show(this, "Test OK.", this.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Test failed with error: " + ex.Message, this.Text);
			}
		}

		private void OkBtn_Click(object sender, EventArgs e)
		{
            if ((string)this.ConnectorTabs.SelectedTab.Tag == "MSSql")
				this.result = new MSSqlProvider(this.CurrentProps.ToFullString());
            else if ((string)this.ConnectorTabs.SelectedTab.Tag == "Oracle")
				this.result = new OracleProvider(this.CurrentProps.ToFullString());
			else
				throw new NotImplementedException("Connection provider not implemented.");
			this.Close();
		}

		private void CancelBtn_Click(object sender, EventArgs e)
		{
			this.result = null;
			this.Close();
		}

		private void advancedButton_Click(object sender, EventArgs e)
		{
			PropertiesBoxDialog.ShowDialog(this, "Connection properties", this.CurrentProps);
		}
	}
}