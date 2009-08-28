using System;
using System.Collections.Generic;
using System.Text;
using Arebis.QuickQueryBuilder.Model;

namespace Arebis.QuickQueryBuilder.Providers
{
	public interface IQueryBuilder
	{
		void BeginQuery(QueryModel table);
		void EndQuery(QueryModel table);

		void BeginTable(TableElement table);
		void EndTable(TableElement table);

		void BeginJoin(JoinElement join);
		void EndJoin(JoinElement join);

		void BeginColumn(ColumnElement column);
		void EndColumn(ColumnElement column);

		void BeginColumnArray(ColumnArrayElement array);
		void EndColumnArray(ColumnArrayElement array);

		string BuildQuery(string additionalWhereConditions);
	}
}
