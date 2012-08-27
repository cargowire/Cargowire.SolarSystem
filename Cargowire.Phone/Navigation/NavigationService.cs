using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

using Microsoft.Phone.Controls;

using Cargowire.Navigation;

namespace Cargowire.Phone.Navigation
{
	public class SimpleNavigationService : INavigationService
	{
		public void Navigate(string uri)
		{
			this.Navigate(uri, null);
		}

		public void Navigate(string uri, IDictionary<string, string> parameters)
		{
			PhoneApplicationFrame frame = Application.Current.RootVisual as PhoneApplicationFrame;
			if (frame == null)
			{
				return;
			}

			StringBuilder uriBuilder = new StringBuilder();
			uriBuilder.Append(uri);
			if (parameters != null && parameters.Count > 0)
			{
				uriBuilder.Append("?");
				bool prependAmp = false;
				foreach (KeyValuePair<string, string> parameterPair in parameters)
				{
					if (prependAmp)
					{
						uriBuilder.Append("&");
					}
					uriBuilder.AppendFormat("{0}={1}", parameterPair.Key, parameterPair.Value);
					prependAmp = true;
				}
			}

			uri = uriBuilder.ToString();
			frame.Navigate(new Uri(uri, UriKind.RelativeOrAbsolute));
		}
	}
}