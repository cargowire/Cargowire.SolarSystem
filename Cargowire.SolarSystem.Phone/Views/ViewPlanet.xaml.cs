using Microsoft.Phone.Controls;

using Cargowire.SolarSystem.Phone.Container;
using Cargowire.SolarSystem.ViewModels;

namespace Cargowire.SolarSystem.Phone.Views
{
	public partial class ViewPlanet : PhoneApplicationPage
	{
		public ViewPlanet()
		{
			InitializeComponent();

			this.DataContext = Registry.Get<PlanetViewModel>();
		}

		protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);

			BaseViewModel baseViewModel = this.DataContext as BaseViewModel;
			baseViewModel.Initialize(this.NavigationContext.QueryString);
		}
	}
}