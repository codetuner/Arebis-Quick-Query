using System;
using System.Collections.Generic;
using System.Text;

namespace Arebis.QuickQueryBuilder.Providers
{
	[Serializable]
	public class DbColumn
	{
		private DbTable table;
		private string name;
		private string type;
		private bool mandatory;

		public DbColumn(DbTable table, string name, string type, bool mandatory)
		{
			this.table = table;
			this.name = name;
			this.type = type;
			this.mandatory = mandatory;
		}

		public DbTable Table
		{
			get { return this.table; }
		}
		
		public string Name
		{
			get { return this.name; }
		}

		public string Type
		{
			get { return this.type; }
		}

		public bool Mandatory
		{
			get { return this.mandatory; }
		}

		public override string ToString()
		{
			return String.Format("{0}", this.name);
		}
	}
}
