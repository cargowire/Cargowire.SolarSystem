using Microsoft.Phone.Controls;

using Cargowire.SolarSystem.Phone.Container;
using Cargowire.SolarSystem.ViewModels;

namespace Cargowire.SolarSystem.Phone.Views
{
	public partial class MainPage : PhoneApplicationPage
	{
		public MainPage()
		{
			InitializeComponent();

			DataContext = Registry.Get<SolarSystemViewModel>();
		}
	}
}