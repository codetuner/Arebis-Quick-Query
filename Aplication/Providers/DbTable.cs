using System;
using System.Collections.Generic;
using System.Text;

namespace Arebis.QuickQueryBuilder.Providers
{
	[Serializable]
	public class DbTable
	{
		private DbSchema schema;
		private string name;
		private bool isView;

		public DbTable(DbSchema schema, string name, bool isView)
		{
			this.schema = schema;
			this.name = name;
			this.isView = isView;
		}

		public DbSchema Schema
		{
			get { return this.schema; }
		}

		public string Name
		{
			get { return this.name; }
		}

		public bool IsView
		{
			get { return this.isView; }
		}

		public override string ToString()
		{
			return String.Format("{0}.{1}", this.schema, this.name);
		}
	}
}
