using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using Arebis.QuickQueryBuilder.Windows;

namespace Arebis.QuickQueryBuilder.Windows
{
	public class TreeNavigator : Component
	{
		private TreeView treeView;
		private TreeNavigationAlgorithm algorithm = TreeNavigationAlgorithm.DepthFirst;

		public event TreeNodeNavigateHandler NavigateBegin;
		public event TreeNodeNavigateHandler NavigateEnd;
		public event EventHandler Done;

		public TreeView TreeView
		{
			get { return this.treeView; }
			set { this.treeView = value; }
		}

		[System.ComponentModel.DefaultValue(TreeNavigationAlgorithm.DepthFirst)]
		public TreeNavigationAlgorithm Algorithm
		{
			get { return this.algorithm; }
			set { this.algorithm = value; }
		}

		public void Run()
		{
			if (this.treeView == null)
				throw new InvalidOperationException("A TreeView must be set before running the TreeViewNavigator.");

			foreach(TreeNode node in this.treeView.Nodes)
			{
				this.RunNode(node);
			}

			this.OnDone(EventArgs.Empty);
		}

		protected void RunNode(TreeNode node)
		{
			this.OnNavigateBegin(new TreeNodeNavigateEventArgs(node));

			foreach (TreeNode subnode in node.Nodes)
			{
				this.RunNode(subnode);
			}

			this.OnNavigateEnd(new TreeNodeNavigateEventArgs(node));
		}

		protected void OnNavigateBegin(TreeNodeNavigateEventArgs e)
		{
			if (this.NavigateBegin != null)
				this.NavigateBegin(this, e);
		}

		protected void OnNavigateEnd(TreeNodeNavigateEventArgs e)
		{
			if (this.NavigateEnd != null)
				this.NavigateEnd(this, e);
		}

		protected void OnDone(EventArgs e)
		{
			if (this.Done != null)
				this.Done(this, e);
		}
	}

	public delegate void TreeNodeNavigateHandler(object sender, TreeNodeNavigateEventArgs e);

	public class TreeNodeNavigateEventArgs : EventArgs
	{
		private TreeNode node;

		public TreeNodeNavigateEventArgs(TreeNode node)
		{
			this.node = node;
		}

		public TreeNode Node
		{
			get { return node; }
			set { node = value; }
		}
	}

	public enum TreeNavigationAlgorithm
	{
		DepthFirst
	}
}
