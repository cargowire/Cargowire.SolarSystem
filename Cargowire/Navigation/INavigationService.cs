using System.Collections.Generic;

namespace Cargowire.Navigation
{
	public interface INavigationService
	{
		void Navigate(string uri);
		void Navigate(string uri, IDictionary<string, string> parameters);
	}
}