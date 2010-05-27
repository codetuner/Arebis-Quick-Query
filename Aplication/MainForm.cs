using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Arebis.QuickQueryBuilder.Model;
using Arebis.QuickQueryBuilder.Providers;
using Arebis.QuickQueryBuilder.Providers.Oracle;
using Arebis.QuickQueryBuilder.Providers.MSSql;
using Arebis.QuickQueryBuilder.Windows;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace Arebis.QuickQueryBuilder
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();

			this.formTitle = this.Text;
		}

		private string formTitle;
		private IDatabaseProvider provider;
		private QueryModel document;
		private string sessionFileName;
		private bool changed = false;

		#region Event handlers

		private void MainForm_Load(object sender, EventArgs e)
		{
			// Connect QueryNavigator to TreeView:
			this.queryNavigator.TreeView = this.QueryTree.InnerTreeView;

			// Open connection:
			string[] args = Environment.GetCommandLineArgs();

			if (args.Length < 2)
			{
			}
			else if (args[1].Equals("/?", StringComparison.CurrentCultureIgnoreCase))
			{
				this.ShowHelp();
			}
			else if (args[1].Equals("Session", StringComparison.CurrentCultureIgnoreCase))
			{
				if (args.Length >= 3)
				{
					this.sessionFileName = args[2];
					this.OpenSession();
				}
				else
					this.NewSession();
			}
			else if (args[1].Equals("Oracle", StringComparison.CurrentCultureIgnoreCase))
			{
				if (args.Length >= 5)
					this.provider = new OracleProvider(args[2], args[3], args[4]);
				else if (args.Length >= 3)
					this.provider = new OracleProvider(args[2]);
				else
					this.provider = null;
				this.NewSession();
			}
			else if (args[1].Equals("MSSql", StringComparison.CurrentCultureIgnoreCase))
			{
                if (args.Length >= 6)
					this.provider = new MSSqlProvider(args[2], args[3], args[4], args[5]);
				else if (args.Length >= 4)
					this.provider = new MSSqlProvider(args[2], args[3]);
                else if (args.Length >= 3)
                    this.provider = new MSSqlProvider(args[2]);
                else
					this.provider = null;
				this.NewSession();
			}
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!this.CloseSession(e.CloseReason != CloseReason.WindowsShutDown))
				e.Cancel = true;
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (this.provider != null)
			{
				try
				{
					this.provider.Dispose();
					this.provider = null;
				}
				catch { }
			}
		}

		private void SchemasList_SelectedIndexChanged(object sender, EventArgs e)
		{
			using (new WaitCursor(this))
			{
				TablesList.Items.Clear();

				if (SchemasList.SelectedItems.Count > 0)
				{
					DbSchema schema = (DbSchema)SchemasList.SelectedItems[0].Tag;
					SetSelection(schema);

					foreach (DbTable item in this.provider.GetTables(schema))
					{
						ListViewItem lvi = TablesList.Items.Add(item.Name, 2);
						lvi.Tag = item;
						if (item.IsView)
							lvi.Group = TablesList.Groups["Views"];
						else
							lvi.Group = TablesList.Groups["Tables"];
					}
				}

                TablesList.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
			}
		}

		private void TablesList_DoubleClick(object sender, EventArgs e)
		{
			using (new WaitCursor(this))
			{
				if (TablesList.SelectedItems.Count > 0)
				{
					DbTable table = (DbTable)TablesList.SelectedItems[0].Tag;
					this.QueryTree.ModelNodes.Add(
						new TableElement(this.document, table)
					);
				}
			}
		}

		private void QueryTree_Click(object sender, EventArgs e)
		{
			if (QueryTree.SelectedNode != null)
				SetSelection(QueryTree.SelectedNode);
			else
				SetSelection(null);
		}

		private void TablesList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (TablesList.SelectedItems.Count > 0)
			{
				DbTable table = (DbTable)TablesList.SelectedItems[0].Tag;
				SetSelection(table);
			}
		}

		private void QueryTree_AfterSelect(object sender, EasyTreeViewEventArgs e)
		{
			using (new WaitCursor(this))
			{
				ColumnList.Items.Clear();

				object nd = e.Node;

				if (nd != null)
				{
					SetSelection(nd);

					if (nd is TableElement)
					{

						foreach (DbColumn item in this.provider.GetColumns((nd as TableElement).Table))
						{
							ListViewItem lvi = ColumnList.Items.Add(item.ToString(), 3);
							lvi.Tag = item;
							lvi.Group = ColumnList.Groups["Columns"];
						}

						foreach (DbRelation item in this.provider.GetRelations((nd as TableElement).Table))
						{
							ListViewItem lvi = ColumnList.Items.Add(item.ToString(), item.IsReverse ? 5 : 4);
							lvi.Tag = item;
							lvi.Group = ColumnList.Groups["Relations"];
						}
					}

                    ColumnList.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
				}
				else
				{
					SetSelection(null);
				}
			}
		}

		private void ColumnList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ColumnList.SelectedItems.Count == 1)
			{
				SetSelection(ColumnList.SelectedItems[0].Tag);
			}
			else
			{
				SetSelection(null);
			}
		}

		private void ColumnList_DoubleClick(object sender, EventArgs e)
		{
			foreach (ListViewItem item in ColumnList.SelectedItems)
			{
				Object tag = item.Tag;

				TableElement parent = QueryTree.SelectedNode as TableElement;
				if (tag is DbColumnArray)
					QueryTree.ModelNodes.Add(new ColumnArrayElement(parent, (DbColumnArray)tag));
				else if (tag is DbColumn)
					QueryTree.ModelNodes.Add(new ColumnElement(parent, (DbColumn)tag));
				else if (tag is DbRelation)
					QueryTree.ModelNodes.Add(new JoinElement(parent, (DbRelation)tag));
			}
		}

		private void QueryTree_KeyDown(object sender, KeyEventArgs e)
		{
			object selection = QueryTree.SelectedNode;

			if (e.KeyCode == Keys.Delete)
			{
				if (selection == null) return;
                
                QueryTree.ModelNodes.Remove(selection);

                if (selection is QueryModel)
                {
                    // Create new initial node:
                    this.document = new QueryModel();
                    this.QueryTree.ModelNodes.Add(this.document);
                }
			}
		}

		private void modelTreeAdapter1_ResolveImageIndex(object subject, ResolveEventArgs<int> e)
		{
			if (e.Item is QueryModel)
				e.Result = 1;
			else if (e.Item is JoinElement)
				e.Result = ((JoinElement)e.Item).Relation.IsReverse ? 5 : 4;
			else if (e.Item is TableElement)
				e.Result = 2;
			else if (e.Item is ColumnElement)
				e.Result = 3;
		}

		private void modelTreeAdapter1_ResolveSortKey(object subject, ResolveEventArgs<string> e)
		{
			if (e.Item is ColumnElement)
				e.Result = "columns";
			else if (e.Item is TableElement)
				e.Result = "tables";
			else
				e.Result = e.Item.GetType().Name;
		}

        private void QueryExtText_TextChanged(object sender, EventArgs e)
        {
            this.changed = true;
        }
        
        private void WhereText_TextChanged(object sender, EventArgs e)
		{
			this.changed = true;
		}

		private void TablesList_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 13)
				this.TablesList_DoubleClick(this, e);
		}

		private void ColumnList_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 13)
				this.ColumnList_DoubleClick(this, e);
		}

		private void QueryTree_Changed(object sender, EventArgs e)
		{
			this.changed = true;
		}

		#endregion

		#region Menu handlers

        private void newSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open new connection:
            if (this.CloseSession(true))
            {
                this.provider = DatabaseConnectionDialog.Show(this);

                NewSession();
            }
        }

        private void openSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CloseSession(true))
            {
                if (this.OpenSessionFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    this.sessionFileName = this.OpenSessionFileDialog.FileName;
                    this.OpenSession();
                }
            }
        }

        private void saveSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.sessionFileName == null)
                this.saveSessionAsToolStripMenuItem_Click(sender, e);
            else
            {
                this.SaveSession();
            }
        }

        private void saveSessionAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SaveSessionFileDialog.FileName = this.sessionFileName;
            if (this.SaveSessionFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.sessionFileName = this.SaveSessionFileDialog.FileName;
                SaveSession();
            }
        }

		private void editConnectionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.provider != null)
			{
				IDatabaseProvider provider = DatabaseConnectionDialog.Show(this, this.provider.Identifier, this.provider.ConnectionString);
				if (provider != null)
				{
					provider.Open();
					this.provider = provider;

					// Reset list connections:
					this.SchemasList.Items.Clear();
					this.TablesList.Items.Clear();
					foreach (DbSchema item in this.provider.GetSchemas())
					{
						ListViewItem lvi = SchemasList.Items.Add(item.ToString(), 1);
						lvi.Tag = item;
						lvi.Group = SchemasList.Groups["Schemas"];
					}
					this.SchemasList.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
				}
			}
		}
		
		private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.provider == null)
                Process.Start(Environment.GetCommandLineArgs()[0]);
            else
                Process.Start(Environment.GetCommandLineArgs()[0], String.Format("\"{0}\" \"{1}\"", this.provider.Identifier, this.provider.ConnectionString));
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void BuildQueryMenuItem_Click(object sender, EventArgs e)
		{
			this.builder = this.provider.CreateQueryBuilder();
			this.queryNavigator.Run();
		}

        private void copyQueryToClipboardToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Clipboard.SetText(this.QueryText.Text);
        }

        private void fixGroupingToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (object item in this.QueryTree.ModelNodes)
			{
				if (item is ColumnElement)
				{
					ColumnElement c = (ColumnElement)item;
					if (c.Visible && c.Grouping == GroupingFunction.None)
						c.Grouping = GroupingFunction.Group;
				}
			}
		}

		private void clearGroupingToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (object item in this.QueryTree.ModelNodes)
			{
				if (item is ColumnElement)
				{
					ColumnElement c = (ColumnElement)item;
					c.Grouping = GroupingFunction.None;
				}
			}
		}

		private void clearAllConditionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (object item in this.QueryTree.ModelNodes)
			{
				if (item is ColumnElement)
				{
					ColumnElement c = (ColumnElement)item;
					c.Condition = null;
					c.Visible = true;
				}
			}
		}

        private void clearAllAliassesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (object item in this.QueryTree.ModelNodes)
            {
                if (item is TableElement)
                {
                    TableElement t = (TableElement)item;
                    t.Alias = null;
                }
                else if (item is ColumnElement)
                {
                    ColumnElement c = (ColumnElement)item;
                    c.Alias = null;
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Q² - Quick Query Editor\r\nVersion: ");
            sb.Append(((AssemblyFileVersionAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyFileVersionAttribute), true)[0]).Version);
            sb.Append("\r\n\r\nWrite complex queries in a few clicks!\r\n\r\n");
            sb.Append(((AssemblyCopyrightAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false)[0]).Copyright);

            MessageBox.Show(this, sb.ToString(), this.formTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void commandlineOptionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ShowHelp();
		}

        private void goToHomepageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://q2.codeplex.com/");
        }

		#endregion

		#region Query building

		IQueryBuilder builder;

		private void queryNavigator_NavigateBegin(object sender, TreeNodeNavigateEventArgs e)
		{
			Object item = e.Node.Tag;

			if (item is QueryModel)
				this.builder.BeginQuery((QueryModel)item);
			else if (item is JoinElement)
				this.builder.BeginJoin((JoinElement)item);
			else if (item is TableElement)
				this.builder.BeginTable((TableElement)item);
			else if (item is ColumnArrayElement)
				this.builder.BeginColumnArray((ColumnArrayElement)item);
			else if (item is ColumnElement)
				this.builder.BeginColumn((ColumnElement)item);
			else
				throw new InvalidOperationException("Unknown treenode tag element type.");
		}

		private void queryNavigator_NavigateEnd(object sender, TreeNodeNavigateEventArgs e)
		{
			Object item = e.Node.Tag;

			if (item is QueryModel)
				this.builder.EndQuery((QueryModel)item);
			else if (item is JoinElement)
				this.builder.EndJoin((JoinElement)item);
			else if (item is TableElement)
				this.builder.EndTable((TableElement)item);
			else if (item is ColumnArrayElement)
				this.builder.EndColumnArray((ColumnArrayElement)item);
			else if (item is ColumnElement)
				this.builder.EndColumn((ColumnElement)item);
			else
				throw new InvalidOperationException("Unknown treenode tag element type.");
		}

		private void queryNavigator_Done(object sender, EventArgs e)
		{
			string fullquery = this.builder.BuildQuery(this.WhereText.Text, this.QueryExtText.Text);
			this.QueryText.Text = fullquery;
			ExecutionTabControl.SelectedTab = SelectTabPage;

			try
			{
				using (new WaitCursor(this))
				{
                    // Execute query and fill DataGridView:
					DataTable dt = this.provider.ExecuteQuery(fullquery, 500);
					ResultView.DataSource = null;
					ResultView.DataSource = dt;
					ExecutionTabControl.SelectedTab = ResultTabPage;

                    // Autosize columns:
                    ResultView.AutoResizeColumns();
                    foreach (DataGridViewColumn col in ResultView.Columns)
                        if (col.Width > 400) col.Width = 400;
                }
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, this.formTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
        }

		#endregion

		#region Session handling methods

		private bool CloseSession(bool interactive)
		{
			if ((interactive) && (this.changed))
			{
				DialogResult saveFirst = MessageBox.Show(this, "Save the existing session first ?", this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
				if (saveFirst == DialogResult.Yes)
					if (this.sessionFileName == null)
						if (!this.SaveSessionAs())
							return false;
						else
							this.SaveSession();
				if (saveFirst == DialogResult.Cancel)
					return false;
			}

			// Clear screen:
			this.QueryTree.ModelNodes.Clear();
			this.SchemasList.Items.Clear();
			this.TablesList.Items.Clear();
			this.ColumnList.Items.Clear();
			this.QueryText.Text = "";
			this.WhereText.Text = "";
            this.QueryExtText.Text = "";
			this.ResultView.DataSource = null;

			// Clear document:
			this.document = null;
			this.sessionFileName = null;

			// Clear connection:
			if (this.provider != null)
				this.provider.Dispose();
			this.provider = null;

			this.changed = false;

            // Update windowstate:
            this.UpdateWindowState();

			// Session closed:
			return true;
		}

		private void NewSession()
		{
			this.TryOpenConnection();

			if (this.provider != null)
			{
				using (new WaitCursor(this))
				{
					// Fill list connections:
					foreach (DbSchema item in this.provider.GetSchemas())
					{
						ListViewItem lvi = SchemasList.Items.Add(item.ToString(), 1);
						lvi.Tag = item;
						lvi.Group = SchemasList.Groups["Schemas"];
					}
                    this.SchemasList.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

					// Create initial node:
					this.document = new QueryModel();
					this.QueryTree.ModelNodes.Add(this.document);
				}
			}

			this.changed = false;

            this.UpdateWindowState();
        }

		private void OpenSession()
		{
			Session session;
			BinaryFormatter formatter = new BinaryFormatter();
			using (FileStream str = new FileStream(this.sessionFileName, FileMode.Open, FileAccess.Read))
			{
				session = (Session)formatter.Deserialize(str);
				str.Close();
			}

			this.provider = session.DatabaseProvider;

			this.TryOpenConnection();

			if (this.provider == null)
				return;

			using (new WaitCursor(this))
			{
				if (this.provider != null)
				{
					// Fill list connections:
					foreach (DbSchema item in this.provider.GetSchemas())
					{
						ListViewItem lvi = SchemasList.Items.Add(item.ToString(), 1);
						lvi.Tag = item;
						lvi.Group = SchemasList.Groups["Schemas"];
					}
                    this.SchemasList.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                }

				this.document = (QueryModel)session.QueryTree[0];
				foreach (object item in session.QueryTree)
					this.QueryTree.ModelNodes.Add(item);
				this.WhereText.Text = session.WhereText;
                this.QueryExtText.Text = session.QueryExtText;
			}

			this.changed = false;

            this.UpdateWindowState();
		}

		private void SaveSession()
		{
			object[] data = new object[this.QueryTree.ModelNodes.Count];
			this.QueryTree.ModelNodes.CopyTo(data, 0);

			BinaryFormatter formatter = new BinaryFormatter();
			using (FileStream str = new FileStream(this.sessionFileName, FileMode.Create, FileAccess.Write))
			{
				Session session = new Session(this.provider, this.QueryTree.ModelNodes);
				session.WhereText = this.WhereText.Text;
                session.QueryExtText = this.QueryExtText.Text;
				formatter.Serialize(str, session);
				str.Close();
			}

			this.changed = false;

            this.UpdateWindowState();
		}

		private bool SaveSessionAs()
		{
			if (this.SaveSessionFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				this.sessionFileName = this.SaveSessionFileDialog.FileName;
				SaveSession();
				return true;
			}
			else
			{
				return false;
			}
		}

        private void UpdateWindowState()
        {
            if (this.sessionFileName != null)
                this.Text = String.Format("{0} - [{1}]", formTitle, this.sessionFileName);
            else if (this.provider != null)
                this.Text = String.Format("{0} - {1}", formTitle, this.provider.ConnectionName);
            else
                this.Text = String.Format("{0}", formTitle);

            bool sessionActive = (this.document != null);
            this.saveSessionToolStripMenuItem.Enabled = sessionActive;
            this.saveSessionAsToolStripMenuItem.Enabled = sessionActive;
			this.editConnectionToolStripMenuItem.Enabled = (this.provider != null);
            this.copyQueryToClipboardToolStripMenuItem.Enabled = sessionActive;
            this.BuildQueryMenuItem.Enabled = sessionActive;
            this.fixGroupingToolStripMenuItem.Enabled = sessionActive;
            this.clearGroupingToolStripMenuItem.Enabled = sessionActive;
            this.clearAllConditionsToolStripMenuItem.Enabled = sessionActive;
            this.clearAllAliassesToolStripMenuItem.Enabled = sessionActive;
        }

		private void TryOpenConnection()
		{
			bool succeeded = false;
			while ((this.provider != null) && (!succeeded))
			{
				try
				{
					this.provider.Open();
					succeeded = true;
				}
				catch (Exception ex)
				{
					MessageBox.Show(this, "Failed to open connection: " + ex.Message, this.formTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					this.provider = DatabaseConnectionDialog.Show(this, this.provider.Identifier, this.provider.ConnectionString);
				}
			}
		}

		#endregion

		#region Other commands

		private void ShowHelp()
		{
            string help = global::Arebis.QuickQueryBuilder.Properties.Resources.HelpText;
            help = help.Replace("{executable}", Assembly.GetEntryAssembly().GetName().Name);
            help = help.Replace("{copyright}", ((AssemblyCopyrightAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false)[0]).Copyright);
            MessageBox.Show(this, help, this.formTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

		private void SetSelection(object obj)
		{
			this.Properties.SelectedObject = obj;
		}

		#endregion
	}
}