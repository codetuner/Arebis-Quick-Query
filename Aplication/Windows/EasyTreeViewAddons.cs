using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Arebis.QuickQueryBuilder.Windows
{
	public delegate void EasyTreeViewEventHandler(object sender, EasyTreeViewEventArgs e);

	public class EasyTreeViewEventArgs : EventArgs
	{
		private object node;
		private TreeViewAction action;

		internal EasyTreeViewEventArgs(TreeViewEventArgs e)
			: this(e.Node.Tag, e.Action)
		{ }

		public EasyTreeViewEventArgs(object node)
			: this(node, TreeViewAction.Unknown)
		{ }

		public EasyTreeViewEventArgs(object node, TreeViewAction action)
		{
			this.node = node;
			this.action = action;
		}

		public TreeViewAction Action {
			get { return this.action; }
		}
		
		public object Node {
			get { return this.node; }
		}
	}

	public delegate void EasyTreeNodeMouseClickEventHandler(object sender, EasyTreeNodeMouseClickEventArgs e);

	public class EasyTreeNodeMouseClickEventArgs : MouseEventArgs
	{
		private object node;

		internal EasyTreeNodeMouseClickEventArgs(TreeNodeMouseClickEventArgs e)
			: this(e.Node.Tag, e.Button, e.Clicks, e.X, e.Y, e.Delta)
		{ }

		public EasyTreeNodeMouseClickEventArgs(object node, MouseButtons button, int clicks, int x, int y, int delta)
			: base(button, clicks, x, y, delta)
		{
			this.node = node;
		}

		public object Node 
		{
			get { return this.node; }
		}
	}
}
