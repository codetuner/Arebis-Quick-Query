using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Arebis.QuickQueryBuilder
{
	public partial class PropertiesBoxDialog : Form
	{
		public PropertiesBoxDialog()
		{
			InitializeComponent();
		}

		public static DialogResult ShowDialog(IWin32Window owner, string title, object obj)
		{
			PropertiesBoxDialog dlg = new PropertiesBoxDialog();
			dlg.Text = title;
			dlg.grid.SelectedObject = obj;
			return dlg.ShowDialog(owner);
		}
	}
}