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
			
		}
		public class TheCurrentPlanetProperty
		{
			
		}

		public class ThePropertyChangedEvent
		{
			[Fact]
			public void IsRaisedWhenSettingName()
			{
				var planet = new PlanetViewModel(null, null);

				Assert.PropertyChanged(planet, "Name", () => planet.Name = "test");
			}
		}
    }
}
