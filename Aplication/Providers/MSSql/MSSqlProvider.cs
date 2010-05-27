using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Collections;
using System.Data;
using System.Runtime.Serialization;

namespace Arebis.QuickQueryBuilder.Providers.MSSql
{
	[Serializable]
	public class MSSqlProvider : IDatabaseProvider
	{
		private static readonly Regex ColumnArrayParser = new Regex(@"^(.+?)(_)(\d+)$");

		[NonSerialized]private SqlConnection connection;
        private string connectionString;
        
		public MSSqlProvider(string servername, string catalog)
			: this(String.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3};", servername, catalog))
		{
		}

		public MSSqlProvider(string servername, string catalog, string username, string password)
			: this(String.Format("Data Source={0};Initial Catalog={1};Integrated Security=SSPI;", servername, catalog, username, password))
		{
		}

		public MSSqlProvider(string connectionString)
		{
            this.connectionString = connectionString;
		}

		#region IDatabaseProvider Members

		public string Identifier
		{
			get { return "MSSql"; }
		}

		public string ConnectionString
		{
			get { return this.connectionString; }
		}

		public string ConnectionName
		{
			get
			{
				using (SqlCommand cmd = new SqlCommand(MSSqlQueries.RetrieveConnectionName, connection))
				using (SqlDataReader reader = cmd.ExecuteReader())
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
			this.connection = new SqlConnection(this.connectionString);
			this.connection.Open();
		}

		public IList<DbSchema> GetSchemas()
		{
			List<DbSchema> result = new List<DbSchema>();

			using (SqlCommand cmd = new SqlCommand(MSSqlQueries.RetrieveSchemas, connection))
			using (SqlDataReader reader = cmd.ExecuteReader())
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

            using (SqlCommand cmd = new SqlCommand(String.Format("USE \"{0}\"", schema.Name), connection))
            {
                cmd.ExecuteNonQuery();
            }

			using (SqlCommand cmd = new SqlCommand(MSSqlQueries.RetrieveTables, connection))
			{
				cmd.Parameters.Add(new SqlParameter("@Schema", schema.Name));
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						result.Add(new DbTable(schema, reader.GetString(0), reader.GetString(1) != "BASE TABLE"));
					}
				}
			}

			return result;
		}

		public IList<DbColumn> GetColumns(DbTable table)
		{
			List<DbColumn> result = new List<DbColumn>();
			Dictionary<string, DbColumnArray> columnArrays = new Dictionary<string, DbColumnArray>();

            using (SqlCommand cmd = new SqlCommand(String.Format("USE \"{0}\"", table.Schema.Name), connection))
            {
                cmd.ExecuteNonQuery();
            }
            
            using (SqlCommand cmd = new SqlCommand(MSSqlQueries.RetrieveColumns, connection))
			{
				cmd.Parameters.Add(new SqlParameter("@Schema", table.Name.Split(new char[] {'.'}, 2)[0]));
				cmd.Parameters.Add(new SqlParameter("@Table", table.Name.Split(new char[] {'.'}, 2)[1]));
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
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
			}

			return result;
		}

		public IList<DbRelation> GetRelations(DbTable table)
		{
			// Source of queries:
			// http://msdn.microsoft.com/en-us/library/aa175805(SQL.80).aspx

			Hashtable handledrelations;
			List<DbRelation> result = new List<DbRelation>();

            using (SqlCommand cmd = new SqlCommand(String.Format("USE \"{0}\"", table.Schema.Name), connection))
            {
                cmd.ExecuteNonQuery();
            }
            
            // 'Straight' relations:
			using (SqlCommand cmd = new SqlCommand(MSSqlQueries.RetrieveRelations, connection))
			{
				handledrelations = new Hashtable();
				DbRelation rel = null;

                cmd.Parameters.Add(new SqlParameter("@Schema", table.Name.Split(new char[] { '.' }, 2)[0]));
                cmd.Parameters.Add(new SqlParameter("@Table", table.Name.Split(new char[] { '.' }, 2)[1]));
                using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						string relname = reader.GetString(0);
						if (!handledrelations.Contains(reader.GetString(0)))
						{
							rel = new DbRelation(relname, table, new DbTable(new DbSchema(reader.GetString(3)), reader.GetString(4), false), "One-To-Many", false);
							handledrelations.Add(relname, rel);
							result.Add(rel);
						}

						rel.FromColumns.Add(reader.GetString(11));
						rel.ToColumns.Add(reader.GetString(5));
					}
				}
			}

			// 'Reverse' relations:
			using (SqlCommand cmd = new SqlCommand(MSSqlQueries.RetrieveReverseRelations, connection))
			{
				handledrelations = new Hashtable();
				DbRelation rel = null;

                cmd.Parameters.Add(new SqlParameter("@Schema", table.Name.Split(new char[] { '.' }, 2)[0]));
                cmd.Parameters.Add(new SqlParameter("@Table", table.Name.Split(new char[] { '.' }, 2)[1]));
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						string relname = reader.GetString(0);
						if (!handledrelations.Contains(reader.GetString(0)))
						{
							rel = new DbRelation(relname, table, new DbTable(new DbSchema(reader.GetString(9)), reader.GetString(10), false), "One-To-Many", true);
							handledrelations.Add(relname, rel);
							result.Add(rel);
						}

						rel.FromColumns.Add(reader.GetString(5));
						rel.ToColumns.Add(reader.GetString(11));
					}
				}
			}
			
			return result;
		}

		public System.Data.DataTable ExecuteQuery(string query, int maxRows)
		{
			DataTable result = new DataTable();
			SqlDataAdapter da = new SqlDataAdapter(String.Format("SET ROWCOUNT {1}\r\n{0}", query, maxRows), this.connection);

			da.Fill(result);

			return result;
		}

		public IQueryBuilder CreateQueryBuilder()
		{
			return new MSSqlQueryBuilder();
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
