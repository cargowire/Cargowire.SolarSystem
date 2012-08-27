using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;

using Cargowire.Navigation;

namespace Cargowire.Web.Navigation
{
	/// <remarks>Although not used this shows how a view model/command could take dependencies relevant to the particular
	/// target domain and use them, rather than embedding platform specific code in themselves.</remarks>
	public class WebNavigationService : INavigationService
    {
		private HttpContextBase _context;

		public WebNavigationService(HttpContextBase context)
		{
			this._context = context;
		}

		public void Navigate(string uri)
		{
			this._context.Response.Redirect(uri);
		}

		public void Navigate(string uri, IDictionary<string, string> parameters)
		{
			NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
			foreach (var param in parameters)
			{
				queryString.Add(param.Key, param.Value);
			}
			this._context.Response.Redirect(uri + queryString.ToString());
		}
	}
}
