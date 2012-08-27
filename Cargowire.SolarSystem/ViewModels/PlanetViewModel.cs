using System;

using Cargowire.Extensions;

namespace Cargowire.SolarSystem.ViewModels
{
	/// <remarks>The ViewModel for planets delegates retrieval of data to a passed in IPlanetRepository</remarks>
	public class PlanetViewModel : BaseViewModel
	{
		protected IPlanetRepository Repository;

		protected Planet _planet;

		public int Id
		{
			get { return _planet.Id; }
			set { CheckPlanet(); _planet.Id = value; RaisePropertyChanged("Id"); }
		}

		public string Name
		{
			get { return _planet.Name; }
			set { CheckPlanet(); _planet.Name = value; RaisePropertyChanged("Name"); }
		}

		public string Description
		{
			get { return _planet.Description; }
			set { CheckPlanet(); _planet.Description = value; RaisePropertyChanged("Description"); }
		}

		public double RedColouring
		{
			get { return _planet.RedColouring; }
			set { CheckPlanet(); _planet.RedColouring = value; RaisePropertyChanged("RedColouring"); }
		}

		public double GreenColouring
		{
			get { return _planet.GreenColouring; }
			set { CheckPlanet(); _planet.GreenColouring = value; RaisePropertyChanged("GreenColouring"); }
		}

		public double BlueColouring
		{
			get { return _planet.BlueColouring; }
			set { CheckPlanet(); _planet.BlueColouring = value; RaisePropertyChanged("BlueColouring"); }
		}

		public Uri Image
		{
			get { return _planet.Image; }
			set { CheckPlanet(); _planet.Image = value; RaisePropertyChanged("Image"); }
		}

		public double DistanceFromSun
		{
			get { return _planet.DistanceFromSun; }
			set { CheckPlanet(); _planet.DistanceFromSun = value; RaisePropertyChanged("DistanceFromSun"); }
		}
		public double Mass
		{
			get { return _planet.Mass; }
			set { CheckPlanet(); _planet.Mass = value; RaisePropertyChanged("Mass"); }
		}
		public double Diameter
		{
			get { return _planet.Diameter; }
			set { CheckPlanet(); _planet.Diameter = value; RaisePropertyChanged("Diameter"); }
		}

		public PlanetViewModel(IPlanetRepository repository)
		{
			CheckPlanet();
			this.Repository = repository;
		}

		public PlanetViewModel(IPlanetRepository repository, Planet planet)
		{
			this._planet = planet;
			this.Repository = repository;
		}

		private void CheckPlanet()
		{
			if (this._planet == null)
				this._planet = new Planet();
		}

		public override void Initialize(System.Collections.Generic.IDictionary<string, string> parameters)
		{
			base.Initialize(parameters);

			var planet = Repository.Get(parameters["Id"].ToInt(0));
			this.Id = planet.Id;
			this.Name = planet.Name;
			this.Description = planet.Description;
			this.Image = planet.Image;
			this.DistanceFromSun = planet.DistanceFromSun;
			this.Mass = planet.Mass;
			this.Diameter = planet.Diameter;
		}
	}
}
