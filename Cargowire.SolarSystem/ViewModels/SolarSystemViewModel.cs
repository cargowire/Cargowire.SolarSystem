using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

using Cargowire.Commands;
using Cargowire.Data;
using Cargowire.Navigation;

namespace Cargowire.SolarSystem.ViewModels
{
	/// <remarks>The ViewModel for the solar system delegates retrieval of data to a passed in IPlanetRepository.  Set's its own
	/// other properties although they again could come from an ISolarSystemRepository.</remarks>
	public class SolarSystemViewModel : BaseViewModel
	{
		protected INavigationService Navigation { get; set; }
		protected IPlanetRepository Repository { get; set; }

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

		public double MaxDistanceFromSun
		{
			get { return _planets.Max(p => p.DistanceFromSun); }
		}

		public double MaxMass
		{
			get { return _planets.Max(p => p.Mass); }
		}

		public double MaxDiameter
		{
			get { return _planets.Max(p => p.Diameter); }
		}

		public SolarSystemViewModel(IPlanetRepository repository, INavigationService navigation)
		{
			this.Repository = repository;
			this.Navigation = navigation;
			this.Name = "Solar System";

			this.PropertyChanged += SolarSystemViewModel_PropertyChanged;

			if (Repository != null)
			{
				var planets = new ObservableOnItemChangeCollection<PlanetViewModel>(Repository.Select(p => new PlanetViewModel(repository, p)));
				planets.CollectionChanged += planets_CollectionChanged;
				this.Planets = planets;
			}
		}

		void SolarSystemViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case "Planets":
					this.CurrentPlanet = this.Planets.FirstOrDefault();
					break;
			}
		}

		void planets_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			RaisePropertyChanged("Planets");
			RaisePropertyChanged("MaxDistanceFromSun");
			RaisePropertyChanged("MaxMass");
			RaisePropertyChanged("MaxDiameter");
		}

		private ICommand _setCurrent;
		public ICommand SetCurrent
		{
			get 
			{
				if(_setCurrent == null)
					_setCurrent = new RelayCommand<PlanetViewModel>((planet) => this.CurrentPlanet = planet);
				return _setCurrent;
			}
		}
		
		private ICommand _navigateToDetails;
		public ICommand NavigateToDetails
		{
			get 
			{
				if(_navigateToDetails == null)
					_navigateToDetails = new RelayCommand<PlanetViewModel>(this.ViewPlanet);
				return _navigateToDetails;
			}
		}

		public void ViewPlanet(PlanetViewModel planet)
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
