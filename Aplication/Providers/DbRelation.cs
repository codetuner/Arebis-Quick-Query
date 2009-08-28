using System;
using System.Collections.Generic;
using System.Text;

namespace Arebis.QuickQueryBuilder.Providers
{
	[Serializable]
	public class DbRelation
	{
		private DbTable fromTable;
		private List<string> fromColumns;
		private DbTable toTable;
		private List<string> toColumns;
		private string name;
		private string multiplicity;
		private bool isReverse;

		public DbRelation(string name, DbTable fromTable, DbTable toTable, string multiplicity, bool isReverse)
			: this(name, fromTable, new List<string>(), toTable, new List<string>(), multiplicity, isReverse)
		{ }

		public DbRelation(string name, DbTable fromTable, List<string> fromColumns, DbTable toTable, List<string> toColumns, string multiplicity, bool isReverse)
		{
			this.name = name;
			this.fromTable = fromTable;
			this.fromColumns = fromColumns;
			this.toTable = toTable;
			this.toColumns = toColumns;
			this.multiplicity = multiplicity;
			this.isReverse = isReverse;
		}

		public DbTable FromTable
		{
			get { return this.fromTable; }
		}

		public List<string> FromColumns
		{
			get { return this.fromColumns; }
		}
		
		public DbTable ToTable
		{
			get { return this.toTable; }
		}

		public List<string> ToColumns
		{
			get { return this.toColumns; }
		}
		
		public string Name
		{
			get { return this.name; }
		}

		public string Multiplicity
		{
			get { return this.multiplicity; }
		}

		public bool IsReverse
		{
			get { return this.isReverse; }
		}

		public override string ToString()
		{
			return this.name;
		}
	}
}
