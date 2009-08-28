using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Arebis.QuickQueryBuilder.Windows
{
	public class WaitCursor : IDisposable
	{
		private Form form;
		private Cursor previous;

		public WaitCursor(Form form)
		{ 
			this.form = form;
			this.previous = form.Cursor;
			this.form.Cursor = Cursors.WaitCursor;
		}

		void IDisposable.Dispose()
		{
			if (this.form != null)
			{
				this.form.Cursor = this.previous;
				this.form = null;
			}
		}
	}
}
