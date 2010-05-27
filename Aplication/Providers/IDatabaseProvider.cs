using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Arebis.QuickQueryBuilder.Providers
{
	public interface IDatabaseProvider : IDisposable
	{
		string Identifier { get; }

		string ConnectionString { get; }

		string ConnectionName { get; }

		void Open();

		IList<DbSchema> GetSchemas();

		IList<DbTable> GetTables(DbSchema schema);

		IList<DbColumn> GetColumns(DbTable table);

		IList<DbRelation> GetRelations(DbTable table);

        DataTable ExecuteQuery(string query, int maxRows);

		IQueryBuilder CreateQueryBuilder();
	}
}
