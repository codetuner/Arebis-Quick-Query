using System;
using System.Collections.Generic;
using System.Text;
using Arebis.QuickQueryBuilder.Providers;

namespace Arebis.QuickQueryBuilder
{
	[Serializable]
	public class Session
	{
		public Session(IDatabaseProvider databaseProvider, ICollection<object> queryTreeNodes)
		{
			this.databaseProvider = databaseProvider;
			this.queryTree = new object[queryTreeNodes.Count];
			queryTreeNodes.CopyTo(this.queryTree, 0);
		}

		private IDatabaseProvider databaseProvider;

		public IDatabaseProvider DatabaseProvider
		{
			get { return databaseProvider; }
			set { databaseProvider = value; }
		}

		private object[] queryTree;

		public object[] QueryTree
		{
			get { return queryTree; }
			set { queryTree = value; }
		}

		private string whereText;

		public string WhereText
		{
			get { return whereText; }
			set { whereText = value; }
		}

        private string queryExtText;

        public string QueryExtText
        {
            get { return this.queryExtText; }
            set { this.queryExtText = value; }
        }
	}
}
