using System;
using System.Collections.Generic;
using System.Text;

namespace Arebis.QuickQueryBuilder.Providers
{
	[Serializable]
	public class DbColumnArray : DbColumn
	{
		private List<string> columnNames;

		public DbColumnArray(DbTable table, string name, string type)
			: this(table, name, type, new List<string>())
		{ }

		public DbColumnArray(DbTable table, string name, string type, List<string> columnNames)
			: base(table, name, type, false)
		{
			this.columnNames = columnNames;
		}

		public List<string> ColumnNames
		{
			get { return this.columnNames; }
		}

		public override string ToString()
		{
			return String.Format("{0}[{1}]", base.ToString(), columnNames.Count);
		}
	}
}
