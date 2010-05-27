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

		[System.ComponentModel.DefaultValue(false)]
		public bool Distinct
		{
			get { return this.distinct; }
			set { this.SetProperty(ref this.distinct, value, "Distinct"); }
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
