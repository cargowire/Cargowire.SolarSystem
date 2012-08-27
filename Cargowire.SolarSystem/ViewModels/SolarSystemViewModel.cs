using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

using Cargowire.Commands;
using Cargowire.Navigation;

namespace Cargowire.SolarSystem.ViewModels
{
	/// <remarks>The ViewModel for the solar system delegates retrieval of data to a passed in IPlanetRepository.  Set's its own
	/// other properties although they again could come from an ISolarSystemRepository.</remarks>
	public class SolarSystemViewModel : BaseViewModel
	{
		public INavigationService Navigation { get; set; }
		public IPlanetRepository Repository { get; set; }

		private string _name;
		public string Name
		{
			get { return _name; }
			set { _name = value; RaisePropertyChanged("Name"); }
		}

		private PlanetViewModel _currentPlanet;
		public PlanetViewModel CurrentPlanet
		{
			get { return _currentPlanet; }
			set { _currentPlanet = value; RaisePropertyChanged("CurrentPlanet"); }
		}

		private IList<PlanetViewModel> _planets;
		/// <remarks>Exposed as an IList to keep ASP.NET happy (and not having to directly reference System.Windows in it's project)</remarks>
		public IList<PlanetViewModel> Planets
		{
			get { return _planets; }
			set { _planets = value; RaisePropertyChanged("Planets"); } // if the list changes completely not just items changed within
		}

		public SolarSystemViewModel(IPlanetRepository repository, INavigationService navigation)
		{
			this.Repository = repository;
			this.Navigation = navigation;
			this.Name = "Solar System";
			this.Planets = new ObservableCollection<PlanetViewModel>(Repository.Select(p => new PlanetViewModel(repository, p)));
			this.CurrentPlanet = this.Planets.FirstOrDefault();
		}

		public ICommand NavigateToDetails
		{
			get { return new RelayCommand<PlanetViewModel>(this.ViewPlanet); }
		}

		private void ViewPlanet(PlanetViewModel planet)
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>();
			parameters.Add("Id", planet.Id.ToString());

			// Uri specification should be abstracted out or at least agnostic of platform.  Possibly by passing the instance
			// and the service using the type and properties to figure out what to do.
			// This isn't actually used by web though so doesn't matter at the moment.
			Navigation.Navigate("/Views/ViewPlanet.xaml", parameters);
		}
	}
}
