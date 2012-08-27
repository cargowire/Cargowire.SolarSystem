using System.Collections.Generic;

using Cargowire.Data;

namespace Cargowire.SolarSystem.ViewModels
{
	/// <remarks>A base view model that guarantees the item is observable and provides a way
	/// of initialising itself based upon a querystring (used by WP7 as per some samples online
	/// seems a semi-sane way of getting the view model created if we can't inject the resolution
	/// in any way)</remarks>
	public abstract class BaseViewModel : ObservableObject
	{
		public virtual void Initialize(IDictionary<string, string> parameters)
		{
		}
	}
}
