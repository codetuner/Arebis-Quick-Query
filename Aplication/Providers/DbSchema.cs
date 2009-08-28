using System;
using System.Collections.Generic;
using System.Text;

namespace Arebis.QuickQueryBuilder.Providers
{
	[Serializable]
	public class DbSchema
	{
		private string name;

		public DbSchema(string name)
		{
			this.name = name;
		}

		public string Name
		{
			get { return this.name; }
		}

		public override string ToString()
		{
			return String.Format("{0}", this.name);
		}
	}
}
