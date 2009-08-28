using System;
using System.Collections.Generic;
using System.Text;
using Arebis.QuickQueryBuilder.Providers;
using Arebis.QuickQueryBuilder.Windows;

namespace Arebis.QuickQueryBuilder.Model
{
	[Serializable]
	public class ColumnElement : ModelBase, ITreeItem
	{
		private TableElement table;
		private DbColumn column;
		private string alias;
		private string condition;
		private GroupingFunction grouping = GroupingFunction.None;
		private bool visible = true;

		public ColumnElement(TableElement table, DbColumn column)
		{
			this.table = table;
			this.column = column;
		}

		[System.ComponentModel.Browsable(false)]
		public TableElement Table
		{
			get { return this.table; }
		}

		[System.ComponentModel.Browsable(false)]
		public DbColumn Column
		{
			get { return this.column; }
		}

		public string ColumnName
		{
			get { return this.column.Name; }
		}

		public string Alias
		{
			get { return this.alias; }
			set { this.SetProperty(ref this.alias, value, "Alias"); }
		}

		public string Condition
		{
			get { return this.condition; }
			set { this.SetProperty(ref this.condition, value, "Condition"); }
		}

		[System.ComponentModel.DefaultValue(GroupingFunction.None)]
		public GroupingFunction Grouping
		{
			get { return this.grouping; }
			set { this.SetProperty(ref this.grouping, value, "Grouping"); }
		}

		[System.ComponentModel.DefaultValue(true)]
		public bool Visible
		{
			get { return this.visible; }
			set { this.SetProperty(ref this.visible, value, "Visible"); }
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			if (this.Grouping != GroupingFunction.None)
			{
				sb.Append(this.Grouping);
				sb.Append(" of ");
			}

			sb.Append(this.ColumnName);

			if (!String.IsNullOrEmpty(this.Alias))
			{
				sb.Append(" as ");
				sb.Append(this.Alias);
			}

			if (!String.IsNullOrEmpty(this.Condition))
			{
				sb.Append(" ");
				sb.Append(this.Condition);
			}

			return sb.ToString();
		}

		#region ITreeItem Members

		object ITreeItem.Parent
		{
			get { return this.table; }
			set { }
		}

		#endregion
	}

	public enum GroupingFunction
	{ 
		None,
		Group,
		AnyValue,
		Sum,
		Average,
		Count,
		Min,
		Max
	}
}
