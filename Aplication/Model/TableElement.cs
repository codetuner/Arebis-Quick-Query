using System;
using System.Collections.Generic;
using System.Text;
using Arebis.QuickQueryBuilder.Providers;
using Arebis.QuickQueryBuilder.Windows;

namespace Arebis.QuickQueryBuilder.Model
{
	[Serializable]
	public class TableElement : ModelBase, ITreeItem
	{
		private QueryModel query;
		private DbTable table;
		private string alias;

		public TableElement(QueryModel query, DbTable table)
		{
			this.query = query;
			this.table = table;
		}

		[System.ComponentModel.Browsable(false)]
		public QueryModel Query
		{
			get { return this.query; }
		}


		[System.ComponentModel.Browsable(false)]
		public DbTable Table
		{
			get { return this.table; }
		}

		public string SchemaName
		{
			get { return this.table.Schema.Name; }
		}

		public string TableName
		{
			get { return this.table.Name; }
		}
		
		public string Alias
		{
			get { return this.alias; }
			set { this.SetProperty(ref this.alias, value, "Alias"); }
		}

		public override string ToString()
		{
			if (String.IsNullOrEmpty(this.Alias))
				return String.Format("{0}.{1}", this.SchemaName, this.TableName);
			else
				return String.Format("{0}.{1} as {2}", this.SchemaName, this.TableName, this.Alias);
		}

		#region IModelTreeNode Members

		object ITreeItem.Parent
		{
			get { return this.query; ; }
			set { }
		}

		#endregion
	}
}
