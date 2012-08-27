using System;
using System.Collections.Generic;

namespace Cargowire.SolarSystem
{
	public class Pre2006PlanetRepository : StaticPlanetRepository
	{
		public Pre2006PlanetRepository()
			: base()
		{
			planets.Add(new Planet
							{
								Id = 9,
								Name="Pluto",
								Diameter = 2360,
								RedColouring = 129,
								BlueColouring = 126,
								GreenColouring = 96,
			       				DistanceFromSun = 5906376272,
			       				Mass = 1.30900E22,
								Description = "Pluto, formal designation 134340 Pluto, is the second-most-massive known dwarf planet in the Solar System (after Eris) and the tenth-most-massive body observed directly orbiting the Sun. Originally classified as the ninth planet from the Sun, Pluto was recategorized as a dwarf planet and plutoid owing to the discovery that it is only one of several large bodies within the Kuiper belt.",
								Image = new Uri("/content/images/pluto.jpg", UriKind.Relative)
							});
		}
	}
}
