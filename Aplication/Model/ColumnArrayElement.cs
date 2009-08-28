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

		public override string ToString()
		{
			return String.Format("{0}[{1}]", base.ToString(), this.columnNames.Length);
		}
	}
}
