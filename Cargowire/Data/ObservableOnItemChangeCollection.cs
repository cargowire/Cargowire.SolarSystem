using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace Cargowire.Data
{
	public class ObservableOnItemChangeCollection<T> : ObservableCollection<T>
		where T : INotifyPropertyChanged
    {
		public ObservableOnItemChangeCollection()
			: base()
		{
		}

		/// <remarks>To List avoids projections causing problems as the object changes afterwards
		/// and loses its handlers</remarks>
		public ObservableOnItemChangeCollection(IEnumerable<T> collection)
			: base(collection.ToList())
		{
			foreach (T item in this) 
				item.PropertyChanged += OnItemPropertyChanged;
		}

		protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
		{
			base.OnCollectionChanged(args);
			
			if (args.NewItems != null)
				foreach (INotifyPropertyChanged item in args.NewItems)
					item.PropertyChanged += OnItemPropertyChanged;

			if (args.OldItems != null)
				foreach (INotifyPropertyChanged item in args.OldItems)
					item.PropertyChanged -= OnItemPropertyChanged;
		}

		void OnItemPropertyChanged(object sender, PropertyChangedEventArgs args)
		{
			var index = this.IndexOf((T)sender);
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, sender, index));
		}

		protected override void ClearItems()
		{
			foreach (INotifyPropertyChanged item in Items)
				item.PropertyChanged -= OnItemPropertyChanged;

			base.ClearItems();
		}
    }
}
