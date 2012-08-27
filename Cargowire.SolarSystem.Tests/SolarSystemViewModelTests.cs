using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargowire.Data;
using Cargowire.Navigation;
using Cargowire.SolarSystem.ViewModels;

using Moq;
using Xunit;

/// Naming conventions as per: http://haacked.com/archive/2012/01/02/structuring-unit-tests.aspx
namespace Cargowire.SolarSystem.Tests
{
    public class SolarSystemViewModelTests
    {
		public class TheConstructor
		{
			/// <summary>Dependencies shoud be 'technically' be optional as an empty repo just means no planets and no planets means
			/// no need for navigation services.  However this is actually unlikely usage.</summary>
			[Fact]
			public void CanCreateWithoutDependencies()
			{
				var solarSystem = new SolarSystemViewModel(null, null);


				Assert.NotNull(solarSystem);
			}

			[Fact]
			public void CanCreateWithDependencies()
			{
				var repo = new Moq.Mock<IPlanetRepository>();
				repo.SetupIQueryable(new Planet[0].AsQueryable());

				var nav = new Moq.Mock<INavigationService>();

				var solarSystem = new SolarSystemViewModel(repo.Object, nav.Object);

				Assert.NotNull(solarSystem);
			}
		}
		public class TheCurrentPlanetProperty
		{
			[Fact]
			public void IsNullOnEmptyConstruction()
			{
				var solarSystem = new SolarSystemViewModel(null, null);


				Assert.Null(solarSystem.CurrentPlanet);
			}

			[Fact]
			public void IsFirstItemInListAfterConstructionId1()
			{
				var repo = new Moq.Mock<IPlanetRepository>();
				var first = new Planet { Id = 1 };
				var second = new Planet { Id = 2 };
				var planets = new Planet[2] { first, second };
				repo.SetupIQueryable(planets.AsQueryable());

				var nav = new Moq.Mock<INavigationService>();

				var solarSystem = new SolarSystemViewModel(repo.Object, nav.Object);
				var currentPlanet = solarSystem.CurrentPlanet;

				Assert.Equal(first.Id, solarSystem.CurrentPlanet.Id);
			}

			[Fact]
			public void IsFirstItemInListAfterConstructionId2()
			{
				var repo = new Moq.Mock<IPlanetRepository>();
				var first = new Planet { Id = 2 };
				var second = new Planet { Id = 1 };
				var planets = new Planet[2] { first, second };
				repo.SetupIQueryable(planets.AsQueryable());

				var nav = new Moq.Mock<INavigationService>();

				var solarSystem = new SolarSystemViewModel(repo.Object, nav.Object);
				var currentPlanet = solarSystem.CurrentPlanet;

				Assert.Equal(first.Id, solarSystem.CurrentPlanet.Id);
			}
		}

		public class ThePropertyChangedEvent
		{
			[Fact]
			public void IsRaisedWhenSettingName()
			{
				var solarSystem = new SolarSystemViewModel(null, null);

				Assert.PropertyChanged(solarSystem, "Name", () => solarSystem.Name = "test");
			}

			[Fact]
			public void IsRaisedWhenSettingPlanets()
			{
				var solarSystem = new SolarSystemViewModel(null, null);

				Assert.PropertyChanged(solarSystem, "Planets", () => solarSystem.Planets = new ObservableOnItemChangeCollection<PlanetViewModel>());
			}

			[Fact]
			public void IsRaisedWhenAddingToPlanets()
			{
				var repo = new Moq.Mock<IPlanetRepository>();
				var first = new Planet { Id = 2 };
				var second = new Planet { Id = 1 };
				var planets = new Planet[2] { first, second };
				repo.SetupIQueryable(planets.AsQueryable());

				var nav = new Moq.Mock<INavigationService>();

				var solarSystem = new SolarSystemViewModel(repo.Object, nav.Object);

				Assert.PropertyChanged(solarSystem, "Planets", () => solarSystem.Planets.Add(new PlanetViewModel(repo.Object)));
			}

			[Fact]
			public void IsRaisedWhenChangingPlanets()
			{
				var repo = new Moq.Mock<IPlanetRepository>();
				var first = new Planet { Id = 2 };
				var second = new Planet { Id = 1 };
				var planets = new Planet[2] { first, second };
				repo.SetupIQueryable(planets.AsQueryable());

				var nav = new Moq.Mock<INavigationService>();

				var solarSystem = new SolarSystemViewModel(repo.Object, nav.Object);

				Assert.PropertyChanged(solarSystem, "Planets", () => solarSystem.Planets.First().Name = "test");
			}

			[Fact]
			public void MaxMassIsRaisedWhenChangingPlanets()
			{
				var repo = new Moq.Mock<IPlanetRepository>();
				var first = new Planet { Id = 2 };
				var second = new Planet { Id = 1 };
				var planets = new Planet[2] { first, second };
				repo.SetupIQueryable(planets.AsQueryable());

				var nav = new Moq.Mock<INavigationService>();

				var solarSystem = new SolarSystemViewModel(repo.Object, nav.Object);

				Assert.PropertyChanged(solarSystem, "MaxMass", () => solarSystem.Planets.First().Mass = 5);
			}

			[Fact]
			public void MaxDiameterIsRaisedWhenChangingPlanets()
			{
				var repo = new Moq.Mock<IPlanetRepository>();
				var first = new Planet { Id = 2 };
				var second = new Planet { Id = 1 };
				var planets = new Planet[2] { first, second };
				repo.SetupIQueryable(planets.AsQueryable());

				var nav = new Moq.Mock<INavigationService>();

				var solarSystem = new SolarSystemViewModel(repo.Object, nav.Object);

				Assert.PropertyChanged(solarSystem, "MaxDiameter", () => solarSystem.Planets.First().Diameter = 5);
			}

			[Fact]
			public void MaxDistanceIsRaisedWhenChangingPlanets()
			{
				var repo = new Moq.Mock<IPlanetRepository>();
				var first = new Planet { Id = 2 };
				var second = new Planet { Id = 1 };
				var planets = new Planet[2] { first, second };
				repo.SetupIQueryable(planets.AsQueryable());

				var nav = new Moq.Mock<INavigationService>();

				var solarSystem = new SolarSystemViewModel(repo.Object, nav.Object);

				Assert.PropertyChanged(solarSystem, "MaxDistanceFromSun", () => solarSystem.Planets.First().DistanceFromSun = 5);
			}
		}

		public class TheViewPlanetMethod
		{
			[Fact]
			public void DelegatesToNavigtionService()
			{
				var nav = new Moq.Mock<INavigationService>();
				nav.Setup(x => x.Navigate("/Views/ViewPlanet.xaml", Moq.It.IsAny<IDictionary<string, string>>()));

				var solarSystem = new SolarSystemViewModel(null, nav.Object);
				solarSystem.ViewPlanet(new PlanetViewModel(null));

				nav.Verify(x => x.Navigate("/Views/ViewPlanet.xaml", Moq.It.IsAny<IDictionary<string, string>>()), Times.Exactly(1));
			}
		}
    }
}
