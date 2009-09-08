using System;
using System.Collections.Generic;
using System.Text;
using Arebis.QuickQueryBuilder.Providers;
using Arebis.QuickQueryBuilder.Windows;

namespace Arebis.QuickQueryBuilder.Model
{
	[Serializable]
	public class ColumnArrayElement : ColumnElement
	{
		private DbColumnArray columnArray;
		private string[] columnNames;

		public ColumnArrayElement(TableElement table, DbColumnArray columnArray)
			: base (table, columnArray)
		{
			this.columnArray = columnArray;
			this.columnNames = columnArray.ColumnNames.ToArray();
		}

		[System.ComponentModel.Browsable(false)]
		public DbColumnArray ColumnArray
		{
			get { return this.columnArray; }
		}

		public string[] ColumnNames
		{
			get { return this.columnNames; }
		}

		public int ColumnCount
		{
			get { return this.columnNames.Length; }
		}

		[System.ComponentModel.Browsable(false)]
		public override string Condition
		{
			get { return base.Condition; }
			set { /* Ignore, condition cannot be set */ }
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			if (this.Grouping != GroupingFunction.None)
			{
				sb.Append(this.Grouping);
				sb.Append(" of ");
			}

			sb.AppendFormat("{0}[{1}]", this.ColumnName, this.ColumnCount);

			if (!String.IsNullOrEmpty(this.Alias))
			{
				sb.Append(" as ");
				sb.AppendFormat("{0}[{1}]", this.Alias, this.ColumnCount);
			}

			if (!String.IsNullOrEmpty(this.Condition))
			{
				sb.Append(" ");
				sb.Append(this.Condition);
			}

			if (this.Visible == false)
				sb.Append(" (hidden)");

			return sb.ToString();
		}
	}
}
