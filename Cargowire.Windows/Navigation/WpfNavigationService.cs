using System;
using System.Collections.Generic;

using Cargowire.Navigation;

namespace Cargowire.Windows.Navigation
{
	/// <remarks>Although not used this shows how a view model/command could take dependencies relevant to the particular
	/// target domain and use them, rather than embedding platform specific code in themselves.
	/// Could, for example, create new windows.</remarks>
	public class WpfNavigationService : INavigationService
	{
		public void Navigate(string uri)
		{
			this.Navigate(uri, null);
		}

		public void Navigate(string uri, IDictionary<string, string> parameters)
		{
			throw new NotImplementedException();
		}
	}
}
