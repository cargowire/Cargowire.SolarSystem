using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

using Cargowire.Commands;
using Cargowire.Navigation;

namespace Cargowire.SolarSystem.ViewModels
{
	public class SolarSystemViewModel : BaseViewModel
	{
		public INavigationService Navigation { get; set; }
		public IPlanetRepository Repository { get; set; }

		public string Name { get; set; }
		public PlanetViewModel SelectedPlanet { get; set; }
		public IList<PlanetViewModel> Planets { get; set; }

		public SolarSystemViewModel(IPlanetRepository repository, INavigationService navigation)
		{
			this.Repository = repository;
			this.Navigation = navigation;
			this.Name = "Solar System";
			this.Planets = new ObservableCollection<PlanetViewModel>(Repository.Select(p => new PlanetViewModel(repository, p)));
			this.SelectedPlanet = this.Planets.FirstOrDefault();
		}

		public ICommand NavigateToDetails
		{
			get { return new RelayCommand<PlanetViewModel>(this.ViewPlanet); }
		}

		private void ViewPlanet(PlanetViewModel planet)
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>();
			parameters.Add("Id", planet.Id.ToString());

			Navigation.Navigate("/Views/ViewPlanet.xaml", parameters);
		}
	}
}
