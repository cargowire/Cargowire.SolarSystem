using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cargowire.Navigation;

namespace Cargowire.Windows.Navigation
{
	public class WpfNavigationService : INavigationService
	{
		public void Navigate(string uri)
		{
			this.Navigate(uri, null);
		}

		public void Navigate(string uri, IDictionary<string, string> parameters)
		{
			
		}
	}
}
