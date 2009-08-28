using System;
using System.Collections.Generic;
using System.Text;
using Arebis.QuickQueryBuilder.Model;

namespace Arebis.QuickQueryBuilder.Providers.Oracle
{
	public class OracleQueryBuilder : IQueryBuilder
	{
		private StringBuilder select = new StringBuilder();
		private StringBuilder from = new StringBuilder();
		private StringBuilder where = new StringBuilder();
		private StringBuilder groupBy = new StringBuilder();
		private String selectOptions = String.Empty;
		private List<string> uniqueTableNames = new List<string>();
		private List<string> uniqueColumnNames = new List<string>();

		private Stack<TableElement> tables = new Stack<TableElement>();

		protected TableElement CurrentTable
		{
			get { return tables.Peek(); }
		}

		#region IQueryBuilder Members

		public void BeginQuery(QueryModel query)
		{
			if (query.Distinct)
				selectOptions += " DISTINCT";
		}

		public void EndQuery(QueryModel query)
		{
		}

		public void BeginTable(TableElement table)
		{
			this.tables.Push(table);

			if (from.Length > 0)
			{
				from.Append(",\r\n   ");
			}
			from.Append(GetUniqueFullNameWithAlias(table));
		}

		public void EndTable(TableElement table)
		{
			this.tables.Pop();
		}

		public void BeginJoin(JoinElement join)
		{
			this.tables.Push(join);

			if (join.JoinType == JoinType.InnerJoin)
				from.Append("\r\n   INNER JOIN ");
			else if (join.JoinType == JoinType.LeftOuterJoin)
				from.Append("\r\n   LEFT OUTER JOIN ");
			else if (join.JoinType == JoinType.RightOuterJoin)
				from.Append("\r\n   RIGHT OUTER JOIN ");
			else if (join.JoinType == JoinType.FullOuterJoin)
				from.Append("\r\n   FULL OUTER JOIN ");
			else
				throw new InvalidOperationException("Jointype not supported.");

			from.Append(GetUniqueFullNameWithAlias(join));
		
			from.Append(" ON (");

			string sep = "";
			for(int i=0; i<join.Relation.FromColumns.Count; i++)
			{
				from.Append(sep);
				from.Append(GetFullNameOrAlias(join.LeftTable));
				from.Append('.');
				from.Append(join.Relation.FromColumns[i]);
				from.Append("=");
				from.Append(GetFullNameOrAlias(join));
				from.Append('.');
				from.Append(join.Relation.ToColumns[i]);
				sep = " AND ";
			}

			from.Append(")");
		}

		public void EndJoin(JoinElement join)
		{
			this.tables.Pop();
		}

		public void BeginColumn(ColumnElement column)
		{
			// Determine grouping function:
			string function;
			switch (column.Grouping)
			{ 
				case GroupingFunction.None:
					function = null;
					break;
				case GroupingFunction.Group:
					function = null;
					break;
				case GroupingFunction.AnyValue:
					function = "MIN";
					break;
				case GroupingFunction.Count:
					function = "COUNT";
					break;
				case GroupingFunction.Sum:
					function = "SUM";
					break;
				case GroupingFunction.Average:
					function = "AVG";
					break;
				case GroupingFunction.Min:
					function = "MIN";
					break;
				case GroupingFunction.Max:
					function = "MAX";
					break;
				default:
					throw new NotSupportedException(String.Format("Grouping operation {0} not supported.", column.Grouping));
			}

			// Apply select:
			if (column.Visible)
			{
				if (select.Length > 0)
					select.Append(",\r\n   ");
				select.Append(GetUniqueFullNameWithAlias(column, function));
			}

			// Check for condition:
			if (!String.IsNullOrEmpty(column.Condition))
			{
				if (this.where.Length > 0)
					this.where.Append("\r\n   AND ");
				this.where.AppendFormat("({0}{1})", GetFullName(column), column.Condition);
			}

			// Apply grouping:
			if (column.Grouping == GroupingFunction.Group)
			{
				if (groupBy.Length > 0)
					groupBy.Append(",\r\n   ");
				groupBy.Append(GetFullName(column));
			}
		}

		public void EndColumn(ColumnElement column)
		{
		}

		public void BeginColumnArray(ColumnArrayElement array)
		{
			TableElement table = CurrentTable;

			for (int i = 0; i < array.ColumnCount; i++)
			{
				if (select.Length > 0)
					select.Append(",\r\n   ");

				select.Append(GetFullNameWithAlias(array, i));
			}
		}

		public void EndColumnArray(ColumnArrayElement array)
		{
		}

		public string BuildQuery(string additionalWhereConditions)
		{
			// Extend where condition with additional conditions:
			if ((additionalWhereConditions != null) && (additionalWhereConditions.Replace("\r", "").Replace("\n","").Trim().Length > 0))
			{
				if (this.where.Length > 0)
					this.where.Append("\r\n   AND ");
				this.where.Append("(");
				this.where.Append(additionalWhereConditions.Trim().Replace("\r\n", "\r\n     "));
				this.where.Append(")");
			}

			// Build SQL statement:
			string sql = String.Format("SELECT{0}\r\n   {1}\r\nFROM\r\n   {2}", this.selectOptions, this.select, this.from);
			if (this.where.Length > 0)
			{
				sql += "\r\nWHERE\r\n   " + this.where.ToString().Trim();
			}
			if (this.groupBy.Length > 0)
			{
				sql += "\r\nGROUP BY " + groupBy.ToString();
			}

			// Return SQL statement:
			return sql;
		}

		#endregion

		#region Helper methods

		private string GetFullNameOrAlias(TableElement item)
		{
			if (String.IsNullOrEmpty(item.Alias))
			{
				return String.Format("{0}.{1}", item.SchemaName, item.TableName);
			}
			else
			{
				return item.Alias;
			}
		}

		private string GetUniqueFullNameWithAlias(TableElement item)
		{
			// Set an alias if name would not be unique:
			if (String.IsNullOrEmpty(item.Alias))
			{
				// Build a unique column name:
				string ext = String.Empty;
				string tableName;
				while (true)
				{
					tableName = String.Format("{0}{1}", item.TableName, ext);
					if (!this.uniqueTableNames.Contains(tableName)) break;
					if (ext == String.Empty)
						ext = "2";
					else
						ext = (Int32.Parse(ext) + 1).ToString();
				}
				this.uniqueTableNames.Add(tableName);

				// Store alias if one was created:
				if (tableName != item.TableName)
					item.Alias = tableName;
			}

			// Return name with unique alias:
			return String.Format(
				"{0}.{1} {2}",
				item.SchemaName,
				item.TableName,
				item.Alias
			).Trim();
		}

		private string GetFullName(ColumnElement item)
		{
			return String.Format("{0}.{1}", GetFullNameOrAlias(item.Table), item.ColumnName);
		}

		private string GetFullNameOrAlias(ColumnElement item)
		{
			if (String.IsNullOrEmpty(item.Alias))
			{
				return String.Format("{0}.{1}", GetFullNameOrAlias(item.Table), item.ColumnName);
			}
			else
			{
				return item.Alias;
			}
		}

		private string GetUniqueFullNameWithAlias(ColumnElement item, string function)
		{
			// Build a unique alias if name would not be unique:
			if (String.IsNullOrEmpty(item.Alias))
			{ 
				// Build a unique column name:
				string ext = String.Empty;
				string columnName;
				while(true)
				{
					columnName = String.Format("{0}{1}", item.ColumnName, ext);
					if (!this.uniqueColumnNames.Contains(columnName)) break;
					if (ext == String.Empty)
						ext = "2";
					else
						ext = (Int32.Parse(ext) + 1).ToString();
				}
				this.uniqueColumnNames.Add(columnName);

				// Store alias if one was created:
				if (columnName != item.ColumnName)
					item.Alias = columnName;
			}

			// Build name with alias:
			return String.Format(
				(function == null) ? "{0}.{1} {2}" : "{3}({0}.{1}) {2}",
				GetFullNameOrAlias(item.Table),
				item.ColumnName,
				item.Alias,
				function
			).Trim();
		}

		private string GetFullNameOrAlias(ColumnArrayElement item, int index)
		{
			if (String.IsNullOrEmpty(item.Alias))
			{
				return String.Format("{0}.{1}", GetFullNameOrAlias(item.Table), item.ColumnNames[index]);
			}
			else
			{
				return this.GetAlias(item, index);
			}
		}

		private string GetFullNameWithAlias(ColumnArrayElement item, int index)
		{
			return String.Format("{0}.{1} {2}", 
				GetFullNameOrAlias(item.Table), 
				item.ColumnNames[index],
				(String.IsNullOrEmpty(item.Alias) ? "" : this.GetAlias(item, index))
			).Trim();
		}

		private string GetAlias(ColumnArrayElement item, int index)
		{
			return String.Format("{0}_{1:00}", item.Alias, index+1);
		}

		#endregion
	}
}
