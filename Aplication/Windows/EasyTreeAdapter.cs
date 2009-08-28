using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Arebis.QuickQueryBuilder.Windows
{
	public class EasyTreeAdapter : Component
	{
		public event ResolveEventHandler<object> ResolveParent;
		public event ResolveEventHandler<int> ResolveImageIndex;
		public event ResolveEventHandler<int> ResolveSelectedImageIndex;
		public event ResolveEventHandler<string> ResolveText;
		public event ResolveEventHandler<string> ResolveToolTipText;
		public event ResolveEventHandler<string> ResolveSortKey;

		public object GetParentOf(object item)
		{
			if (this.ResolveParent != null)
			{
				ResolveEventArgs<object> e = new ResolveEventArgs<object>(item);
				this.ResolveParent(this, e);
				return e.Result;
			}
			else if (item is ITreeItem)
			{
				return ((ITreeItem)item).Parent;
			}
			else
			{
				return null;
			}
		}

		public int GetImageIndexOf(object item)
		{
			if (this.ResolveImageIndex != null)
			{
				ResolveEventArgs<int> e = new ResolveEventArgs<int>(item);
				this.ResolveImageIndex(this, e);
				return e.Result;
			}
			else
			{
				return 0;
			}
		}

		public int GetSelectedImageIndexOf(object item)
		{
			if (this.ResolveSelectedImageIndex != null)
			{
				ResolveEventArgs<int> e = new ResolveEventArgs<int>(item);
				this.ResolveSelectedImageIndex(this, e);
				return e.Result;
			}
			else
			{
				return this.GetImageIndexOf(item);
			}
		}

		public string GetTextOf(object item)
		{
			if (this.ResolveText != null)
			{
				ResolveEventArgs<string> e = new ResolveEventArgs<string>(item);
				this.ResolveText(this, e);
				return e.Result;
			}
			else if (item == null)
			{
				return "Null";
			}
			else
			{
				return item.ToString();
			}
		}

		public string GetToolTipTextOf(object item)
		{
			if (this.ResolveToolTipText != null)
			{
				ResolveEventArgs<string> e = new ResolveEventArgs<string>(item);
				this.ResolveToolTipText(this, e);
				return e.Result;
			}
			else
			{
				return null;
			}
		}

		public string GetSortKeyOf(object item)
		{
			if (this.ResolveSortKey != null)
			{
				ResolveEventArgs<string> e = new ResolveEventArgs<string>(item);
				this.ResolveSortKey(this, e);
				return e.Result;
			}
			else
			{
				return String.Empty;
			}
		}
	}

	public delegate void ResolveEventHandler<T>(object subject, ResolveEventArgs<T> e);

	public class ResolveEventArgs<T> : EventArgs
	{
		public ResolveEventArgs(object item)
		{
			this.item = item;
		}

		private object item;

		public object Item
		{
			get { return item; }
		}
		
		private T result;

		public T Result
		{
			get { return result; }
			set { result = value; }
		}
	}
}
