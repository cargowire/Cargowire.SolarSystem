using System.Collections.Generic;

namespace Cargowire.Navigation
{
	/// <remarks>Based on another code sample somewhere.  Extracts responsiblity for navigation into a service so that
	/// view models can take it as a dependency rather than baking in the action into command implementations etc</remarks>
	public interface INavigationService
	{
		void Navigate(string uri);
		void Navigate(string uri, IDictionary<string, string> parameters);
	}
}