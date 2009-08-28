using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Design;

namespace Arebis.QuickQueryBuilder.Windows
{
	public partial class EasyTreeView : UserControl
	{
		private NodeCollection modelNodes;
		private Dictionary<object, TreeNode> treeNodeIndex = new Dictionary<object, TreeNode>();
		private bool autoExpand = false;
		private bool sorted = false;
		private bool changed = false;
		private EasyTreeAdapter adapter;

		public EasyTreeView()
		{
			InitializeComponent();

			this.modelNodes = new NodeCollection(this);
		}

		#region Public Implementation

		[System.ComponentModel.Browsable(false)]
		public TreeView InnerTreeView
		{
			get { return this.innerTreeView; }
		}

		[Category("Behavior")]
		[DefaultValue(false)]
		public bool AutoExpand
		{
			get { return this.autoExpand; }
			set { this.autoExpand = value; }
		}

		[Category("Behavior")]
		[DefaultValue(false)]
		public bool Sorted
		{
			get { return this.sorted; }
			set { this.sorted = value; }
		}

		[System.ComponentModel.Browsable(false)]
		public bool Changed
		{
			get { return this.changed; }
			set { this.changed = value; }
		}

		[System.ComponentModel.Browsable(false)]
		public ICollection<object> ModelNodes
		{
			get { return this.modelNodes; }
		}

		[System.ComponentModel.Browsable(false)]
		public object SelectedNode
		{
			get 
			{
				return this.GetModelTreeNodeForTreeNode(this.innerTreeView.SelectedNode);
			}
		}

		[Category("Behavior")]
		[DefaultValue(null)]
		public EasyTreeAdapter Adapter
		{
			get { return this.adapter; }
			set { this.adapter = value; }
		}

		public object GetItemParent(object item)
		{
			if (this.adapter != null)
				return this.adapter.GetParentOf(item);
			else if (item is ITreeItem)
				return ((ITreeItem)item).Parent;
			else
				return null;
		}

		public ICollection GetItemChildren(object item)
		{
			ArrayList result = new ArrayList();
			foreach (object child in this.ModelNodes)
			{
				if (this.GetItemParent(child) == item)
					result.Add(child);
			}

			return result;
		}

		public ICollection GetRoots()
		{
			return this.GetItemChildren(null);
		}

		#endregion

		#region Private Implementation

		private void WhenModelNodeAdded(object item)
		{
			bool sorted = ((this.sorted) && (this.adapter != null));
			TreeNode parentNode = this.GetTreeNodeForModelTreeNode(this.GetItemParent(item));
			TreeNode itemNode = this.MakeTreeNode(item);
			string itemSortKey = (sorted) ? this.adapter.GetSortKeyOf(item) : String.Empty;
			if (parentNode == null)
			{
				bool added = false;
				if (sorted)
				{
					foreach (TreeNode otherNode in this.innerTreeView.Nodes)
					{
						if (this.adapter.GetSortKeyOf(otherNode.Tag).CompareTo(itemSortKey) > 0)
						{
							this.innerTreeView.Nodes.Insert(otherNode.Index, itemNode);
							added = true;
							break;
						}
					}
				}
				if (!added)
				{
					this.innerTreeView.Nodes.Add(itemNode);
				}
			}
			else
			{
				bool added = false;
				if (sorted)
				{
					foreach (TreeNode otherNode in parentNode.Nodes)
					{
						if (this.adapter.GetSortKeyOf(otherNode.Tag).CompareTo(itemSortKey) > 0)
						{
							parentNode.Nodes.Insert(otherNode.Index, itemNode);
							added = true;
							break;
						}
					}
				}
				if (!added)
				{
					parentNode.Nodes.Add(itemNode);
				}
				if (this.autoExpand)
					parentNode.Expand();
			}
			this.treeNodeIndex[item] = itemNode;

			if (item is INotifyPropertyChanging)
				((INotifyPropertyChanging)item).PropertyChanging += new PropertyChangingEventHandler(WhenNodePropertyChanging);
			if (item is INotifyPropertyChanged)
				((INotifyPropertyChanged)item).PropertyChanged += new PropertyChangedEventHandler(WhenNodePropertyChanged);

			this.changed = true;
		}

		private void WhenNodePropertyChanging(object sender, PropertyChangingEventArgs e)
		{
			if (e.PropertyName == "Parent")
			{
				this.ModelNodes.Remove(sender);
				if (sender is INotifyPropertyChanged)
					((INotifyPropertyChanged)sender)
						.PropertyChanged += new PropertyChangedEventHandler(WhenNodePropertyChanged);

				this.changed = true;
			}
		}

		private void WhenNodePropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Parent")
			{
				this.ModelNodes.Add(sender);
				this.changed = true;
			}
			else
			{
				this.SyncTreeNode(sender, this.GetTreeNodeForModelTreeNode(sender));
				this.changed = true;
			}
		}

		private void WhenModelNodeRemoved(object item)
		{
			if (item is INotifyPropertyChanging)
				((INotifyPropertyChanging)item).PropertyChanging -= new PropertyChangingEventHandler(WhenNodePropertyChanging);
			if (item is INotifyPropertyChanged)
				((INotifyPropertyChanged)item).PropertyChanged -= new PropertyChangedEventHandler(WhenNodePropertyChanged);

			TreeNode parentNode = this.GetTreeNodeForModelTreeNode(this.GetItemParent(item));
			TreeNode itemNode = this.GetTreeNodeForModelTreeNode(item);
			if (parentNode == null)
				this.innerTreeView.Nodes.Remove(itemNode);
			else
				parentNode.Nodes.Remove(itemNode);
			this.treeNodeIndex.Remove(item);

			this.changed = true;
		}

		#endregion

		#region Translation and helper methods

		protected TreeNode MakeTreeNode(object modelTreeNode)
		{
			TreeNode result = new TreeNode();
			this.SyncTreeNode(modelTreeNode, result);
			return result;
		}

		protected void SyncTreeNode(object modelTreeNode, TreeNode treeViewNode)
		{
			if (this.adapter != null)
			{
				treeViewNode.Text = adapter.GetTextOf(modelTreeNode) ?? this.ToString();
				treeViewNode.ImageIndex = adapter.GetImageIndexOf(modelTreeNode);
				treeViewNode.SelectedImageIndex = adapter.GetSelectedImageIndexOf(modelTreeNode);
				treeViewNode.ToolTipText = adapter.GetToolTipTextOf(modelTreeNode);
			}
			else
			{
				treeViewNode.Text = modelTreeNode.ToString();
			}
			treeViewNode.Tag = modelTreeNode;
		}

		protected object GetModelTreeNodeForTreeNode(TreeNode treeNode)
		{
			if (treeNode == null)
				return null;
			else
				return treeNode.Tag;
		}

		protected TreeNode GetTreeNodeForModelTreeNode(object modelTreeNode)
		{
			if (modelTreeNode == null)
				return null;
			else
				return treeNodeIndex[modelTreeNode];
		}

		#endregion

		#region Properties & events forwarding to InnerTreeView

		public new event EventHandler Click;
		public new event EventHandler DoubleClick;
		public event EasyTreeViewEventHandler AfterSelect;
		public event EasyTreeViewEventHandler AfterCheck;
		public event EasyTreeNodeMouseClickEventHandler NodeMouseClick;
		public event EasyTreeNodeMouseClickEventHandler NodeMouseDoubleClick;
		public new event KeyEventHandler KeyDown;
		public new event KeyPressEventHandler KeyPress;
		public new event KeyEventHandler KeyUp;
		public new event PreviewKeyDownEventHandler PreviewKeyDown;

		[Category("Behavior")]
		[DefaultValue(null)]
		[RefreshProperties(RefreshProperties.Repaint)]
		public ImageList ImageList
		{
			get { return this.innerTreeView.ImageList; }
			set { this.innerTreeView.ImageList = value; }
		}

		[DefaultValue(true)]
		public bool HideSelection
		{
			get { return this.innerTreeView.HideSelection; }
			set { this.innerTreeView.HideSelection = value; }
		}

		[Localizable(true)]
		[DefaultValue(-1)]
		[Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
		[RelatedImageList("ImageList")]
		public int ImageIndex
		{
			get { return this.innerTreeView.ImageIndex; }
			set { this.innerTreeView.ImageIndex = value; }
		}

		[Localizable(true)]
		[DefaultValue(-1)]
		[Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
		[RelatedImageList("ImageList")]
		public int SelectedImageIndex
		{
			get { return this.innerTreeView.SelectedImageIndex; }
			set { this.innerTreeView.SelectedImageIndex = value; }
		}

		#endregion

		#region Event dispatchers for InnerTreeView

		private void InnerTreeView_Click(object sender, EventArgs e)
		{
			if (this.Click != null)
				this.Click(this, e);
		}

		private void InnerTreeView_DoubleClick(object sender, EventArgs e)
		{
			if (this.DoubleClick != null)
				this.DoubleClick(this, e);
		}

		private void InnerTreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (this.AfterSelect != null)
				this.AfterSelect(this, new EasyTreeViewEventArgs(e));
		}

		private void InnerTreeView_AfterCheck(object sender, TreeViewEventArgs e)
		{
			if (this.AfterCheck != null)
				this.AfterCheck(this, new EasyTreeViewEventArgs(e));
		}

		private void InnerTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (this.NodeMouseClick != null)
				this.NodeMouseClick(this, new EasyTreeNodeMouseClickEventArgs(e));
		}

		private void InnerTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (this.NodeMouseDoubleClick != null)
				this.NodeMouseDoubleClick(this, new EasyTreeNodeMouseClickEventArgs(e));
		}

		private void InnerTreeView_KeyDown(object sender, KeyEventArgs e)
		{
			if (this.KeyDown != null)
				this.KeyDown(this, e);
		}

		private void InnerTreeView_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (this.KeyPress != null)
				this.KeyPress(this, e);
		}

		private void InnerTreeView_KeyUp(object sender, KeyEventArgs e)
		{
			if (this.KeyUp != null)
				this.KeyUp(this, e);
		}

		private void InnerTreeView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (this.PreviewKeyDown != null)
				this.PreviewKeyDown(this, e);
		}

		#endregion

		#region Nested types

		public sealed class NodeCollection : ICollection<object>
		{
			private EasyTreeView view;
			private List<object> innerList = new List<object>();

			internal NodeCollection(EasyTreeView view)
			{
				this.view = view;
			}

			#region ICollection<object> Members

			public void Add(object item)
			{
				this.innerList.Add(item);
				this.view.WhenModelNodeAdded(item);
			}

			public void Clear()
			{
				while (this.innerList.Count > 0)
					this.Remove(this.innerList[0]);
			}

			public bool Contains(object item)
			{
				return this.innerList.Contains(item);
			}

			public void CopyTo(object[] array, int arrayIndex)
			{
				this.innerList.CopyTo(array, arrayIndex);
			}

			public int Count
			{
				get { return this.innerList.Count; }
			}

			public bool IsReadOnly
			{
				get { return false; }
			}

			public bool Remove(object item)
			{
				// Remove children depth-first:
				foreach (object child in this.innerList.ToArray())
				{
					if (this.view.GetItemParent(child) == item)
						this.Remove(child);
				}
				
				// Remove item:
				int index = this.innerList.IndexOf(item);
				if (index >= 0)
				{
					this.innerList.RemoveAt(index);
					this.view.WhenModelNodeRemoved(item);
					return true;
				}
				else
				{
					return false;
				}
			}

			#endregion

			#region IEnumerable<ModelTreeNode> Members

			public IEnumerator<object> GetEnumerator()
			{
				return this.innerList.GetEnumerator();
			}

			#endregion

			#region IEnumerable Members

			System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
			{
				return ((System.Collections.IEnumerable)this.innerList).GetEnumerator();
			}

			#endregion
		}

		#endregion
	}
}
