using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Data;
using System.Data.OracleClient;
using System.Runtime.Serialization;

namespace Arebis.QuickQueryBuilder.Providers.Oracle
{
	[Serializable]
	public class OracleProvider : IDatabaseProvider
	{
		private static readonly Regex ColumnArrayParser = new Regex(@"^(.+?)(_)(\d+)$");

		[NonSerialized]private OracleConnection connection;
        private string connectionString;

		public OracleProvider(string database, string username, string password)
			: this(String.Format("Data Source={0};Persist Security Info=True;User ID={1};Password={2}", database, username, password))
		{ }

		public OracleProvider(string connectionString)
		{
            this.connectionString = connectionString;
		}

		#region IDatabaseProvider Members

		public string Identifier
		{
			get { return "Oracle"; }
		}

		public string ConnectionString
		{
			get { return this.connectionString; }
		}

		public string ConnectionName
		{
			get 
			{
				using (OracleCommand cmd = new OracleCommand(OracleQueries.RetrieveConnectionName, connection))
				using (OracleDataReader reader = cmd.ExecuteReader())
				{
					if (reader.Read())
						return reader.GetString(0);
					else
						return null;
				}
			}
		}

		public void Open()
		{
			this.connection = new OracleConnection(connectionString);
			this.connection.Open();
		}

		public IList<DbSchema> GetSchemas()
		{
			List<DbSchema> result = new List<DbSchema>();

			using (OracleCommand cmd = new OracleCommand(OracleQueries.RetrieveSchemas, connection))
			using (OracleDataReader reader = cmd.ExecuteReader())
			{
				while (reader.Read())
				{
					result.Add(new DbSchema(reader.GetString(0)));
				}
			}

			return result;
		}

		public IList<DbTable> GetTables(DbSchema schema)
		{
			List<DbTable> result = new List<DbTable>();

			using (OracleCommand cmd = new OracleCommand(OracleQueries.RetrieveTables, connection))
			{
				cmd.Parameters.Add(new OracleParameter(":Owner", schema.Name));
				OracleDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					result.Add(new DbTable(schema, reader.GetString(0), reader.GetString(1) != "TABLE"));
				}
			}

			return result;
		}

		public IList<DbColumn> GetColumns(DbTable table)
		{
			List<DbColumn> result = new List<DbColumn>();
			Dictionary<string, DbColumnArray> columnArrays = new Dictionary<string, DbColumnArray>();

			using (OracleCommand cmd = new OracleCommand(OracleQueries.RetrieveColumns, connection))
			{
				cmd.Parameters.Add(new OracleParameter(":Owner", table.Schema.Name));
				cmd.Parameters.Add(new OracleParameter(":TableName", table.Name));
				OracleDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					string colname = reader.GetString(0);
					string coltype = reader.GetString(1);
					if (coltype.Contains("CHAR"))
					{
						coltype = String.Format("{0}({1})", coltype, reader.GetValue(2));
					}
					else if (reader.GetValue(3) != DBNull.Value)
					{
						coltype = String.Format("{0}({1},{2})", coltype, reader.GetValue(3), reader.GetValue(4));
					}
					bool mandatory = "N".Equals(reader.GetString(5));

					if ("TRC_NUM".Equals(colname)) continue;
					if ("DAT_CRE".Equals(colname)) continue;
					if ("USR_CRE".Equals(colname)) continue;
					if ("DAT_MOD".Equals(colname)) continue;
					if ("USR_MOD".Equals(colname)) continue;

					Match match = ColumnArrayParser.Match(colname);
					if (match.Success)
					{
						DbColumnArray array;
						string basename = match.Groups[1].Value;
						if (!columnArrays.TryGetValue(basename, out array))
						{
							array = new DbColumnArray(table, basename, coltype);
							columnArrays[basename] = array;
							result.Add(array);
						}
						array.ColumnNames.Add(colname);
					}

					result.Add(new DbColumn(table, colname, coltype, mandatory));
				}
			}

			return result;
		}

		public IList<DbRelation> GetRelations(DbTable table)
		{
			Hashtable handledrelations;
			List<DbRelation> result = new List<DbRelation>();

			// 'Straight' relations:
			using (OracleCommand cmd = new OracleCommand(OracleQueries.RetrieveRelations, connection))
			{
				handledrelations = new Hashtable();
				DbRelation rel = null;

				cmd.Parameters.Add(new OracleParameter(":Owner", table.Schema.Name));
				cmd.Parameters.Add(new OracleParameter(":TableName", table.Name));
				OracleDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					string relname = reader.GetString(0);
					if (!handledrelations.Contains(reader.GetString(0)))
					{
						rel = new DbRelation(relname, table, new DbTable(new DbSchema(reader.GetString(5)), reader.GetString(6), false), "One-To-Many", false);
						handledrelations.Add(relname, rel);
						result.Add(rel);
					}

					rel.FromColumns.Add(reader.GetString(3));
					rel.ToColumns.Add(reader.GetString(7));
				}
			}

			// 'Reverse' relations:
			using (OracleCommand cmd = new OracleCommand(OracleQueries.RetrieveReverseRelations, connection))
			{
				handledrelations = new Hashtable();
				DbRelation rel = null;

				cmd.Parameters.Add(new OracleParameter(":Owner", table.Schema.Name));
				cmd.Parameters.Add(new OracleParameter(":TableName", table.Name));
				OracleDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					string relname = reader.GetString(0);
					if (!handledrelations.Contains(reader.GetString(0)))
					{
						rel = new DbRelation(relname, table, new DbTable(new DbSchema(reader.GetString(1)), reader.GetString(2), false), "One-To-Many", true);
						handledrelations.Add(relname, rel);
						result.Add(rel);
					}

					rel.FromColumns.Add(reader.GetString(7));
					rel.ToColumns.Add(reader.GetString(3));
				}
			}
			
			return result;
		}

		public System.Data.DataTable ExecuteQuery(string query)
		{
			DataTable result = new DataTable();
			OracleDataAdapter da = new OracleDataAdapter(String.Format("SELECT * FROM ({0}) WHERE ROWNUM <= 500", query), this.connection);
			da.ReturnProviderSpecificTypes = true;

			da.Fill(result);

			return result;
		}

		public IQueryBuilder CreateQueryBuilder()
		{
			return new OracleQueryBuilder();
		}

		#endregion

		#region IDisposable Members

		public void Dispose()
		{
			if (this.connection != null)
			{
				this.connection.Dispose();
				this.connection = null;
			}
		}

		#endregion
	}
}
