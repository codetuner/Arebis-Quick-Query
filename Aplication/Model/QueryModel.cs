using System;
using System.Collections.Generic;
using System.Text;
using Arebis.QuickQueryBuilder.Windows;

namespace Arebis.QuickQueryBuilder.Model
{
	[Serializable]
	public class QueryModel : ModelBase, ITreeItem
	{
        private bool distinct;

		private int maxRows = 500;

		[System.ComponentModel.DefaultValue(false)]
		public bool Distinct
		{
			get { return this.distinct; }
			set { this.SetProperty(ref this.distinct, value, nameof(Distinct)); }
		}

		[System.ComponentModel.DefaultValue(500)]
		public int MaxRows
		{
			get { return this.maxRows; }
			set { this.SetProperty(ref this.maxRows, value, nameof(MaxRows)); }
		}
		
		public override string ToString()
		{
			if (this.distinct)
				return "SELECT DISTINCT";
			else
				return "SELECT";
		}

		#region IModelTreeNode Members

		object ITreeItem.Parent
		{
			get { return null; }
			set { }
		}

		#endregion
	}
}
