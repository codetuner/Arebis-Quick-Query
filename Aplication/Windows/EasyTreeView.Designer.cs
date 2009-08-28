namespace Arebis.QuickQueryBuilder.Windows
{
	partial class EasyTreeView
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.innerTreeView = new System.Windows.Forms.TreeView();
			this.SuspendLayout();
			// 
			// innerTreeView
			// 
			this.innerTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.innerTreeView.Location = new System.Drawing.Point(0, 0);
			this.innerTreeView.Name = "innerTreeView";
			this.innerTreeView.Size = new System.Drawing.Size(150, 150);
			this.innerTreeView.TabIndex = 0;
			this.innerTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.InnerTreeView_NodeMouseDoubleClick);
			this.innerTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.InnerTreeView_AfterCheck);
			this.innerTreeView.DoubleClick += new System.EventHandler(this.InnerTreeView_DoubleClick);
			this.innerTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.InnerTreeView_AfterSelect);
			this.innerTreeView.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.InnerTreeView_PreviewKeyDown);
			this.innerTreeView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InnerTreeView_KeyPress);
			this.innerTreeView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.InnerTreeView_KeyUp);
			this.innerTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.InnerTreeView_NodeMouseClick);
			this.innerTreeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InnerTreeView_KeyDown);
			this.innerTreeView.Click += new System.EventHandler(this.InnerTreeView_Click);
			// 
			// EasyTreeView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.innerTreeView);
			this.Name = "EasyTreeView";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView innerTreeView;

	}
}
