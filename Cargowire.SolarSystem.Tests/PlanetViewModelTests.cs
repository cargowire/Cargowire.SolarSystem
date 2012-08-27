using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargowire.Navigation;
using Cargowire.SolarSystem.ViewModels;
using Xunit;

/// Naming conventions as per: http://haacked.com/archive/2012/01/02/structuring-unit-tests.aspx
namespace Cargowire.SolarSystem.Tests
{
    public class PlanetViewModelTests
    {
		public class TheConstructor
		{
			[Fact]
			public void NullDependenciesAreAccepted()
			{
				var pvm = new PlanetViewModel(null, null);

				Assert.NotNull(pvm);
			}
		}
	

		public class ThePropertyChangedEvent
		{
			[Fact]
			public void IsRaisedWhenSettingId()
			{
				var planet = new PlanetViewModel(null, null);

				Assert.PropertyChanged(planet, "Id", () => planet.Id = 1);
			}

			[Fact]
			public void IsRaisedWhenSettingName()
			{
				var planet = new PlanetViewModel(null, null);

				Assert.PropertyChanged(planet, "Name", () => planet.Name = "test");
			}

			[Fact]
			public void IsRaisedWhenSettingDescription()
			{
				var planet = new PlanetViewModel(null, null);

				Assert.PropertyChanged(planet, "Description", () => planet.Description = "test");
			}

			[Fact]
			public void IsRaisedWhenSettingMass()
			{
				var planet = new PlanetViewModel(null, null);

				Assert.PropertyChanged(planet, "Mass", () => planet.Mass = 1);
			}

			[Fact]
			public void IsRaisedWhenSettingDiameter()
			{
				var planet = new PlanetViewModel(null, null);

				Assert.PropertyChanged(planet, "Diameter", () => planet.Diameter = 1);
			}

			[Fact]
			public void IsRaisedWhenSettingDistanceFromSun()
			{
				var planet = new PlanetViewModel(null, null);

				Assert.PropertyChanged(planet, "DistanceFromSun", () => planet.DistanceFromSun = 1);
			}
		}

		public class TheInitializeMethod
		{
			[Fact]
			public void ValuesPersistedToViewModel()
			{
				Dictionary<string, string> properties = new Dictionary<string, string>
				{
					{ "Id", "2" },
					{ "Name", "my name" },
					{ "Description", "My description" },
					{ "Mass", "90" },
					{ "Diameter", "1234" },
					{ "DistanceFromSun", "123" },
					{ "Image", "~/image.jpg" }
				};

				var pvm = new PlanetViewModel(null, null);
				pvm.Initialize(properties);

				Assert.Equal(properties["Id"], pvm.Id.ToString());
				Assert.Equal(properties["Name"], pvm.Name.ToString());
				Assert.Equal(properties["Description"], pvm.Description.ToString());
				Assert.Equal(properties["Mass"], pvm.Mass.ToString());
				Assert.Equal(properties["Diameter"], pvm.Diameter.ToString());
				Assert.Equal(properties["DistanceFromSun"], pvm.DistanceFromSun.ToString());
				Assert.Equal(properties["Image"], pvm.Image.ToString());
			}
		}
    }
}
