using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Arebis.QuickQueryBuilder.Model
{
	[Serializable]
	public abstract class ModelBase : INotifyPropertyChanged
	{
		[field:NonSerialized]
		public event PropertyChangedEventHandler PropertyChanged;

		protected void SetProperty<T>(ref T field, T value, string propertyName)
		{
			field = value;

			if (this.PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
