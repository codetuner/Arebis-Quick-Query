using System;
using System.Collections.Generic;
using System.Text;
using Arebis.QuickQueryBuilder.Providers;
using Arebis.QuickQueryBuilder.Windows;

namespace Arebis.QuickQueryBuilder.Model
{
	[Serializable]
	public class JoinElement : TableElement, ITreeItem
	{
		private TableElement leftTable;
		private DbRelation relation;
		private JoinType joinType = JoinType.InnerJoin;
		private string extraCondition;

		public JoinElement(TableElement leftTable, DbRelation relation)
			: base(leftTable.Query, relation.ToTable)
		{
			this.leftTable = leftTable;
			this.relation = relation;
		}

		[System.ComponentModel.Browsable(false)]
		public TableElement LeftTable
		{
			get { return this.leftTable; }
		}

		[System.ComponentModel.Browsable(false)]
		public DbRelation Relation
		{
			get { return this.relation; }
		}

		[System.ComponentModel.DefaultValue(JoinType.InnerJoin)]
		public JoinType JoinType
		{
			get { return this.joinType; }
			set { this.SetProperty(ref this.joinType, value, "JoinType"); }
		}

		/// <summary>
		/// Extra conditions that are And'ed with the regular join condition
		/// </summary>
		[System.ComponentModel.DisplayName("Extra condition(s)")]
		[System.ComponentModel.Description("Extra SQL condition(s) And'ed with the regular join condition.")]
		public string ExtraCondition
		{
			get { return this.extraCondition; }
			set { this.extraCondition = value; }
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			sb.Append(this.JoinType);
			sb.Append(" ");
			sb.Append(this.relation.Name);
			if (!String.IsNullOrEmpty(this.Alias))
			{
				sb.Append(" as ");
				sb.Append(this.Alias);
			}

			return sb.ToString();
		}
			
		#region IModelTreeNode Members

		object ITreeItem.Parent
		{
			get { return this.LeftTable; }
			set { }
		}

		#endregion
	}

	public enum JoinType
	{ 
		InnerJoin,
		LeftOuterJoin,
		RightOuterJoin,
		FullOuterJoin
	}
}
