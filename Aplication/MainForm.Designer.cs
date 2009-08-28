namespace Arebis.QuickQueryBuilder
{
	partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Schemas", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Tables", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Views", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Columns", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Relations", System.Windows.Forms.HorizontalAlignment.Left);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSessionAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.newWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BuildQueryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.copyQueryToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.fixGroupingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearGroupingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllConditionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllAliassesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.goToHomepageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandlineOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.DbImageList = new System.Windows.Forms.ImageList(this.components);
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.SchemasList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.TablesList = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.ColumnList = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Properties = new System.Windows.Forms.PropertyGrid();
            this.QueryTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.QueryTree = new Arebis.QuickQueryBuilder.Windows.EasyTreeView();
            this.modelTreeAdapter1 = new Arebis.QuickQueryBuilder.Windows.EasyTreeAdapter();
            this.ExecutionTabControl = new System.Windows.Forms.TabControl();
            this.SelectTabPage = new System.Windows.Forms.TabPage();
            this.QueryText = new System.Windows.Forms.TextBox();
            this.WhereTabPage = new System.Windows.Forms.TabPage();
            this.WhereText = new System.Windows.Forms.TextBox();
            this.ResultTabPage = new System.Windows.Forms.TabPage();
            this.ResultView = new System.Windows.Forms.DataGridView();
            this.OpenSessionFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveSessionFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.testItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.test1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queryNavigator = new Arebis.QuickQueryBuilder.Windows.TreeNavigator();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.QueryTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ExecutionTabControl.SuspendLayout();
            this.SelectTabPage.SuspendLayout();
            this.WhereTabPage.SuspendLayout();
            this.ResultTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.queryToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(882, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSessionToolStripMenuItem,
            this.openSessionToolStripMenuItem,
            this.saveSessionToolStripMenuItem,
            this.saveSessionAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.newWindowToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newSessionToolStripMenuItem
            // 
            this.newSessionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newSessionToolStripMenuItem.Image")));
            this.newSessionToolStripMenuItem.Name = "newSessionToolStripMenuItem";
            this.newSessionToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.newSessionToolStripMenuItem.Text = "New Session...";
            this.newSessionToolStripMenuItem.Click += new System.EventHandler(this.newSessionToolStripMenuItem_Click);
            // 
            // openSessionToolStripMenuItem
            // 
            this.openSessionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openSessionToolStripMenuItem.Image")));
            this.openSessionToolStripMenuItem.Name = "openSessionToolStripMenuItem";
            this.openSessionToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.openSessionToolStripMenuItem.Text = "Open Session...";
            this.openSessionToolStripMenuItem.Click += new System.EventHandler(this.openSessionToolStripMenuItem_Click);
            // 
            // saveSessionToolStripMenuItem
            // 
            this.saveSessionToolStripMenuItem.Enabled = false;
            this.saveSessionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveSessionToolStripMenuItem.Image")));
            this.saveSessionToolStripMenuItem.Name = "saveSessionToolStripMenuItem";
            this.saveSessionToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.saveSessionToolStripMenuItem.Text = "Save Session";
            this.saveSessionToolStripMenuItem.Click += new System.EventHandler(this.saveSessionToolStripMenuItem_Click);
            // 
            // saveSessionAsToolStripMenuItem
            // 
            this.saveSessionAsToolStripMenuItem.Enabled = false;
            this.saveSessionAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveSessionAsToolStripMenuItem.Image")));
            this.saveSessionAsToolStripMenuItem.Name = "saveSessionAsToolStripMenuItem";
            this.saveSessionAsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.saveSessionAsToolStripMenuItem.Text = "Save Session as...";
            this.saveSessionAsToolStripMenuItem.Click += new System.EventHandler(this.saveSessionAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
            // 
            // newWindowToolStripMenuItem
            // 
            this.newWindowToolStripMenuItem.Name = "newWindowToolStripMenuItem";
            this.newWindowToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.newWindowToolStripMenuItem.Text = "New window";
            this.newWindowToolStripMenuItem.Click += new System.EventHandler(this.newWindowToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(160, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // queryToolStripMenuItem
            // 
            this.queryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BuildQueryMenuItem,
            this.toolStripMenuItem3,
            this.copyQueryToClipboardToolStripMenuItem,
            this.toolStripMenuItem4,
            this.fixGroupingToolStripMenuItem,
            this.clearGroupingToolStripMenuItem,
            this.clearAllConditionsToolStripMenuItem,
            this.clearAllAliassesToolStripMenuItem});
            this.queryToolStripMenuItem.Name = "queryToolStripMenuItem";
            this.queryToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.queryToolStripMenuItem.Text = "Query";
            // 
            // BuildQueryMenuItem
            // 
            this.BuildQueryMenuItem.Enabled = false;
            this.BuildQueryMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("BuildQueryMenuItem.Image")));
            this.BuildQueryMenuItem.Name = "BuildQueryMenuItem";
            this.BuildQueryMenuItem.Size = new System.Drawing.Size(179, 22);
            this.BuildQueryMenuItem.Text = "Build && Run";
            this.BuildQueryMenuItem.Click += new System.EventHandler(this.BuildQueryMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(176, 6);
            // 
            // copyQueryToClipboardToolStripMenuItem
            // 
            this.copyQueryToClipboardToolStripMenuItem.Enabled = false;
            this.copyQueryToClipboardToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyQueryToClipboardToolStripMenuItem.Image")));
            this.copyQueryToClipboardToolStripMenuItem.Name = "copyQueryToClipboardToolStripMenuItem";
            this.copyQueryToClipboardToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.copyQueryToClipboardToolStripMenuItem.Text = "Copy to Clipboard";
            this.copyQueryToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyQueryToClipboardToolStripMenuItem_Click_1);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(176, 6);
            // 
            // fixGroupingToolStripMenuItem
            // 
            this.fixGroupingToolStripMenuItem.Enabled = false;
            this.fixGroupingToolStripMenuItem.Name = "fixGroupingToolStripMenuItem";
            this.fixGroupingToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.fixGroupingToolStripMenuItem.Text = "Fix Grouping";
            this.fixGroupingToolStripMenuItem.Click += new System.EventHandler(this.fixGroupingToolStripMenuItem_Click);
            // 
            // clearGroupingToolStripMenuItem
            // 
            this.clearGroupingToolStripMenuItem.Enabled = false;
            this.clearGroupingToolStripMenuItem.Name = "clearGroupingToolStripMenuItem";
            this.clearGroupingToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.clearGroupingToolStripMenuItem.Text = "Clear Grouping";
            this.clearGroupingToolStripMenuItem.Click += new System.EventHandler(this.clearGroupingToolStripMenuItem_Click);
            // 
            // clearAllConditionsToolStripMenuItem
            // 
            this.clearAllConditionsToolStripMenuItem.Enabled = false;
            this.clearAllConditionsToolStripMenuItem.Name = "clearAllConditionsToolStripMenuItem";
            this.clearAllConditionsToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.clearAllConditionsToolStripMenuItem.Text = "Clear All Conditions";
            this.clearAllConditionsToolStripMenuItem.Click += new System.EventHandler(this.clearAllConditionsToolStripMenuItem_Click);
            // 
            // clearAllAliassesToolStripMenuItem
            // 
            this.clearAllAliassesToolStripMenuItem.Enabled = false;
            this.clearAllAliassesToolStripMenuItem.Name = "clearAllAliassesToolStripMenuItem";
            this.clearAllAliassesToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.clearAllAliassesToolStripMenuItem.Text = "Clear All Aliasses";
            this.clearAllAliassesToolStripMenuItem.Click += new System.EventHandler(this.clearAllAliassesToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.toolStripMenuItem1,
            this.goToHomepageToolStripMenuItem,
            this.commandlineOptionsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(199, 6);
            // 
            // goToHomepageToolStripMenuItem
            // 
            this.goToHomepageToolStripMenuItem.Name = "goToHomepageToolStripMenuItem";
            this.goToHomepageToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.goToHomepageToolStripMenuItem.Text = "Go to Homepage";
            this.goToHomepageToolStripMenuItem.Click += new System.EventHandler(this.goToHomepageToolStripMenuItem_Click);
            // 
            // commandlineOptionsToolStripMenuItem
            // 
            this.commandlineOptionsToolStripMenuItem.Name = "commandlineOptionsToolStripMenuItem";
            this.commandlineOptionsToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.commandlineOptionsToolStripMenuItem.Text = "Commandline options...";
            this.commandlineOptionsToolStripMenuItem.Click += new System.EventHandler(this.commandlineOptionsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(171, 6);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 407);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(882, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // DbImageList
            // 
            this.DbImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("DbImageList.ImageStream")));
            this.DbImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.DbImageList.Images.SetKeyName(0, "Computer.ico");
            this.DbImageList.Images.SetKeyName(1, "db.ico");
            this.DbImageList.Images.SetKeyName(2, "RoseClass.ico");
            this.DbImageList.Images.SetKeyName(3, "RoseOperation.ico");
            this.DbImageList.Images.SetKeyName(4, "arrowright.ico");
            this.DbImageList.Images.SetKeyName(5, "arrowleft.ico");
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox2.Location = new System.Drawing.Point(0, 315);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(882, 92);
            this.textBox2.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 291);
            this.panel1.TabIndex = 6;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.SchemasList);
            this.splitContainer3.Panel1.Controls.Add(this.toolStrip2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.TablesList);
            this.splitContainer3.Size = new System.Drawing.Size(271, 291);
            this.splitContainer3.SplitterDistance = 100;
            this.splitContainer3.TabIndex = 2;
            // 
            // SchemasList
            // 
            this.SchemasList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.SchemasList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SchemasList.FullRowSelect = true;
            listViewGroup1.Header = "Schemas";
            listViewGroup1.Name = "Schemas";
            this.SchemasList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.SchemasList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.SchemasList.HideSelection = false;
            this.SchemasList.Location = new System.Drawing.Point(0, 25);
            this.SchemasList.MultiSelect = false;
            this.SchemasList.Name = "SchemasList";
            this.SchemasList.Size = new System.Drawing.Size(271, 75);
            this.SchemasList.SmallImageList = this.DbImageList;
            this.SchemasList.TabIndex = 2;
            this.SchemasList.UseCompatibleStateImageBehavior = false;
            this.SchemasList.View = System.Windows.Forms.View.Details;
            this.SchemasList.SelectedIndexChanged += new System.EventHandler(this.SchemasList_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 100;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(271, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // TablesList
            // 
            this.TablesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.TablesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TablesList.FullRowSelect = true;
            listViewGroup2.Header = "Tables";
            listViewGroup2.Name = "Tables";
            listViewGroup3.Header = "Views";
            listViewGroup3.Name = "Views";
            this.TablesList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup2,
            listViewGroup3});
            this.TablesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.TablesList.HideSelection = false;
            this.TablesList.Location = new System.Drawing.Point(0, 0);
            this.TablesList.MultiSelect = false;
            this.TablesList.Name = "TablesList";
            this.TablesList.Size = new System.Drawing.Size(271, 187);
            this.TablesList.SmallImageList = this.DbImageList;
            this.TablesList.TabIndex = 3;
            this.TablesList.UseCompatibleStateImageBehavior = false;
            this.TablesList.View = System.Windows.Forms.View.Details;
            this.TablesList.SelectedIndexChanged += new System.EventHandler(this.TablesList_SelectedIndexChanged);
            this.TablesList.DoubleClick += new System.EventHandler(this.TablesList_DoubleClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 100;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(584, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(298, 291);
            this.panel2.TabIndex = 7;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.ColumnList);
            this.splitContainer2.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.Properties);
            this.splitContainer2.Size = new System.Drawing.Size(298, 291);
            this.splitContainer2.SplitterDistance = 143;
            this.splitContainer2.TabIndex = 1;
            // 
            // ColumnList
            // 
            this.ColumnList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.ColumnList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ColumnList.FullRowSelect = true;
            listViewGroup4.Header = "Columns";
            listViewGroup4.Name = "Columns";
            listViewGroup5.Header = "Relations";
            listViewGroup5.Name = "Relations";
            this.ColumnList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup4,
            listViewGroup5});
            this.ColumnList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ColumnList.HideSelection = false;
            this.ColumnList.Location = new System.Drawing.Point(0, 25);
            this.ColumnList.Name = "ColumnList";
            this.ColumnList.Size = new System.Drawing.Size(298, 118);
            this.ColumnList.SmallImageList = this.DbImageList;
            this.ColumnList.TabIndex = 4;
            this.ColumnList.UseCompatibleStateImageBehavior = false;
            this.ColumnList.View = System.Windows.Forms.View.Details;
            this.ColumnList.SelectedIndexChanged += new System.EventHandler(this.ColumnList_SelectedIndexChanged);
            this.ColumnList.DoubleClick += new System.EventHandler(this.ColumnList_DoubleClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 100;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(298, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Properties
            // 
            this.Properties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Properties.Location = new System.Drawing.Point(0, 0);
            this.Properties.Name = "Properties";
            this.Properties.Size = new System.Drawing.Size(298, 144);
            this.Properties.TabIndex = 2;
            // 
            // QueryTabControl
            // 
            this.QueryTabControl.Controls.Add(this.tabPage1);
            this.QueryTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QueryTabControl.Location = new System.Drawing.Point(271, 24);
            this.QueryTabControl.Name = "QueryTabControl";
            this.QueryTabControl.SelectedIndex = 0;
            this.QueryTabControl.Size = new System.Drawing.Size(313, 291);
            this.QueryTabControl.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(305, 265);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Query";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.QueryTree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ExecutionTabControl);
            this.splitContainer1.Size = new System.Drawing.Size(299, 259);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 5;
            // 
            // QueryTree
            // 
            this.QueryTree.Adapter = this.modelTreeAdapter1;
            this.QueryTree.AutoExpand = true;
            this.QueryTree.Changed = false;
            this.QueryTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QueryTree.HideSelection = false;
            this.QueryTree.ImageIndex = 0;
            this.QueryTree.ImageList = this.DbImageList;
            this.QueryTree.Location = new System.Drawing.Point(0, 0);
            this.QueryTree.Name = "QueryTree";
            this.QueryTree.SelectedImageIndex = 0;
            this.QueryTree.Size = new System.Drawing.Size(299, 25);
            this.QueryTree.Sorted = true;
            this.QueryTree.TabIndex = 0;
            this.QueryTree.AfterSelect += new Arebis.QuickQueryBuilder.Windows.EasyTreeViewEventHandler(this.QueryTree_AfterSelect);
            this.QueryTree.Click += new System.EventHandler(this.QueryTree_Click);
            this.QueryTree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.QueryTree_KeyDown);
            // 
            // modelTreeAdapter1
            // 
            this.modelTreeAdapter1.ResolveImageIndex += new Arebis.QuickQueryBuilder.Windows.ResolveEventHandler<int>(this.modelTreeAdapter1_ResolveImageIndex);
            this.modelTreeAdapter1.ResolveSortKey += new Arebis.QuickQueryBuilder.Windows.ResolveEventHandler<string>(this.modelTreeAdapter1_ResolveSortKey);
            // 
            // ExecutionTabControl
            // 
            this.ExecutionTabControl.Controls.Add(this.SelectTabPage);
            this.ExecutionTabControl.Controls.Add(this.WhereTabPage);
            this.ExecutionTabControl.Controls.Add(this.ResultTabPage);
            this.ExecutionTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExecutionTabControl.Location = new System.Drawing.Point(0, 0);
            this.ExecutionTabControl.Name = "ExecutionTabControl";
            this.ExecutionTabControl.SelectedIndex = 0;
            this.ExecutionTabControl.Size = new System.Drawing.Size(299, 230);
            this.ExecutionTabControl.TabIndex = 0;
            // 
            // SelectTabPage
            // 
            this.SelectTabPage.Controls.Add(this.QueryText);
            this.SelectTabPage.Location = new System.Drawing.Point(4, 22);
            this.SelectTabPage.Name = "SelectTabPage";
            this.SelectTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.SelectTabPage.Size = new System.Drawing.Size(291, 204);
            this.SelectTabPage.TabIndex = 0;
            this.SelectTabPage.Text = "Select";
            this.SelectTabPage.UseVisualStyleBackColor = true;
            // 
            // QueryText
            // 
            this.QueryText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QueryText.Location = new System.Drawing.Point(3, 3);
            this.QueryText.Multiline = true;
            this.QueryText.Name = "QueryText";
            this.QueryText.ReadOnly = true;
            this.QueryText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.QueryText.Size = new System.Drawing.Size(285, 198);
            this.QueryText.TabIndex = 1;
            // 
            // WhereTabPage
            // 
            this.WhereTabPage.Controls.Add(this.WhereText);
            this.WhereTabPage.Location = new System.Drawing.Point(4, 22);
            this.WhereTabPage.Name = "WhereTabPage";
            this.WhereTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.WhereTabPage.Size = new System.Drawing.Size(291, 204);
            this.WhereTabPage.TabIndex = 1;
            this.WhereTabPage.Text = "Where";
            this.WhereTabPage.UseVisualStyleBackColor = true;
            // 
            // WhereText
            // 
            this.WhereText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WhereText.Location = new System.Drawing.Point(3, 3);
            this.WhereText.Multiline = true;
            this.WhereText.Name = "WhereText";
            this.WhereText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.WhereText.Size = new System.Drawing.Size(285, 198);
            this.WhereText.TabIndex = 1;
            this.WhereText.TextChanged += new System.EventHandler(this.WhereText_TextChanged);
            // 
            // ResultTabPage
            // 
            this.ResultTabPage.Controls.Add(this.ResultView);
            this.ResultTabPage.Location = new System.Drawing.Point(4, 22);
            this.ResultTabPage.Name = "ResultTabPage";
            this.ResultTabPage.Size = new System.Drawing.Size(291, 204);
            this.ResultTabPage.TabIndex = 2;
            this.ResultTabPage.Text = "Result";
            this.ResultTabPage.UseVisualStyleBackColor = true;
            // 
            // ResultView
            // 
            this.ResultView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ResultView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultView.Location = new System.Drawing.Point(0, 0);
            this.ResultView.Name = "ResultView";
            this.ResultView.Size = new System.Drawing.Size(291, 204);
            this.ResultView.TabIndex = 0;
            // 
            // OpenSessionFileDialog
            // 
            this.OpenSessionFileDialog.DefaultExt = "q2s";
            this.OpenSessionFileDialog.Filter = "Q2 Session files (*.q2s)|*.q2s|All files (*.*)|*.*";
            this.OpenSessionFileDialog.Title = "Open query session";
            // 
            // SaveSessionFileDialog
            // 
            this.SaveSessionFileDialog.DefaultExt = "q2s";
            this.SaveSessionFileDialog.Filter = "Q2 Session files (*.q2s)|*.q2s|All files (*.*)|*.*";
            this.SaveSessionFileDialog.Title = "Save query session";
            // 
            // testItemToolStripMenuItem
            // 
            this.testItemToolStripMenuItem.Name = "testItemToolStripMenuItem";
            this.testItemToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.testItemToolStripMenuItem.Text = "TestItem";
            // 
            // test1ToolStripMenuItem
            // 
            this.test1ToolStripMenuItem.Name = "test1ToolStripMenuItem";
            this.test1ToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.test1ToolStripMenuItem.Text = "Test1";
            // 
            // queryNavigator
            // 
            this.queryNavigator.TreeView = null;
            this.queryNavigator.Done += new System.EventHandler(this.queryNavigator_Done);
            this.queryNavigator.NavigateEnd += new Arebis.QuickQueryBuilder.Windows.TreeNodeNavigateHandler(this.queryNavigator_NavigateEnd);
            this.queryNavigator.NavigateBegin += new Arebis.QuickQueryBuilder.Windows.TreeNodeNavigateHandler(this.queryNavigator_NavigateBegin);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 429);
            this.Controls.Add(this.QueryTabControl);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Q² Editor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.QueryTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ExecutionTabControl.ResumeLayout(false);
            this.SelectTabPage.ResumeLayout(false);
            this.SelectTabPage.PerformLayout();
            this.WhereTabPage.ResumeLayout(false);
            this.WhereTabPage.PerformLayout();
            this.ResultTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ResultView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ImageList DbImageList;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.SplitContainer splitContainer3;
		private System.Windows.Forms.ListView SchemasList;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ToolStrip toolStrip2;
		private System.Windows.Forms.ListView TablesList;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.ListView ColumnList;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.PropertyGrid Properties;
		private System.Windows.Forms.TabControl QueryTabControl;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private Arebis.QuickQueryBuilder.Windows.EasyTreeView QueryTree;
		private System.Windows.Forms.TabControl ExecutionTabControl;
		private System.Windows.Forms.TabPage SelectTabPage;
		private System.Windows.Forms.TextBox QueryText;
		private System.Windows.Forms.TabPage WhereTabPage;
		private System.Windows.Forms.TextBox WhereText;
		private System.Windows.Forms.TabPage ResultTabPage;
		private System.Windows.Forms.DataGridView ResultView;
		private System.Windows.Forms.ToolStripMenuItem queryToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem BuildQueryMenuItem;
		private Arebis.QuickQueryBuilder.Windows.TreeNavigator queryNavigator;
		private Arebis.QuickQueryBuilder.Windows.EasyTreeAdapter modelTreeAdapter1;
		private System.Windows.Forms.ToolStripMenuItem openSessionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveSessionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveSessionAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.OpenFileDialog OpenSessionFileDialog;
		private System.Windows.Forms.SaveFileDialog SaveSessionFileDialog;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem fixGroupingToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem clearGroupingToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem clearAllConditionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newSessionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyQueryToClipboardToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem commandlineOptionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newWindowToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem testItemToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem test1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem goToHomepageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllAliassesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
	}
}

