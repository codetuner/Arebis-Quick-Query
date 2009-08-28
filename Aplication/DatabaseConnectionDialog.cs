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

			this.SqlConnectionPanel.Initialize(SqlProps);
			this.OracleConnectionPanel.Initialize(OraProps);
			this.ConnectorTabs_Selected(this.ConnectorTabs, null);
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

		private void ConnectorTabs_Selected(object sender, TabControlEventArgs e)
		{
			if ((string)this.ConnectorTabs.SelectedTab.Tag == "SQLSERVER")
				this.CurrentProps = this.SqlProps;
            else if ((string)this.ConnectorTabs.SelectedTab.Tag == "ORACLE")
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
            if ((string)this.ConnectorTabs.SelectedTab.Tag == "SQLSERVER")
				this.result = new MSSqlProvider(this.CurrentProps.ToFullString());
            else if ((string)this.ConnectorTabs.SelectedTab.Tag == "ORACLE")
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
	}
}