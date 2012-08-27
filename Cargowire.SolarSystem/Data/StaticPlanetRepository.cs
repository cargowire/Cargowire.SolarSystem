using System;
using System.Collections.Generic;
using System.Linq;

namespace Cargowire.SolarSystem
{
	public class StaticPlanetRepository : IPlanetRepository
	{
		protected List<Planet> planets;

		public StaticPlanetRepository()
		{
			planets = new List<Planet>
			       	{
			       		new Planet()
			       			{
								Id = 1,
			       				Name = "Mercury",
			       				Diameter = 4879.4, // KM
								RedColouring = 138,
								BlueColouring = 137,
								GreenColouring = 142,
			       				DistanceFromSun = 57910000, // KM
			       				Mass = 328.5E21,
								Description = "Mercury is the innermost of the eight planets in the Solar System. It is also the smallest, and its orbit has the highest eccentricity of the eight. It orbits the Sun once in about 88 Earth days, completing three rotations about its axis for every two orbits. Mercury has the smallest axial tilt of the Solar System planets. The perihelion of Mercury's orbit precesses around the Sun at an excess of 43 arcseconds per century beyond what is predicted by Newtonian mechanics, a phenomenon that was explained in the 20th century by Albert Einstein's General Theory of Relativity.",
								Image = new Uri("/content/images/mercury.jpg", UriKind.Relative)
			       			},
						new Planet()
							{
								Id = 2,
								Name = "Venus",
  								Diameter =  12103.6,
								RedColouring = 210,
								BlueColouring = 202,
								GreenColouring = 199,
			       				DistanceFromSun = 108200000,
			       				Mass = 4.867E24,
								Description = "Venus is the second planet from the Sun, orbiting it every 224.7 Earth days. The planet is named after Venus, the Roman goddess of love and beauty. After the Moon, it is the brightest natural object in the night sky, reaching an apparent magnitude of −4.6, bright enough to cast shadows. Because Venus is an inferior planet from Earth, it never appears to venture far from the Sun: its elongation reaches a maximum of 47.8°. Venus reaches its maximum brightness shortly before sunrise or shortly after sunset, for which reason it has been known in ancient time as the Morning Star or Evening Star. It was not until the Hellenistic era (300-200 BC) astronomers realised it was one object and gave it the name it has today.",
								Image = new Uri("/content/images/venus.jpg", UriKind.Relative)
				       		},
						new Planet()
							{
								Id = 3,
								Name = "Earth",
								Diameter = 12756.2,
								RedColouring = 112,
								BlueColouring = 115,
								GreenColouring = 156,
			       				DistanceFromSun = 149600000,
			       				Mass = 5.972E24,
								Description = "Earth (or the Earth) is the third planet from the Sun, and the densest and fifth-largest of the eight planets in the Solar System. It is also the largest of the Solar System's four terrestrial planets. It is sometimes referred to as the world, the Blue Planet, or by its Latin name, Terra.",
								Image = new Uri("/Content/Images/earth.jpg", UriKind.Relative)
							},
						new Planet
							{
								Id = 4,
								Name = "Mars",
								Diameter = 6794,
								RedColouring = 211,
								BlueColouring = 140,
								GreenColouring = 90,
			       				DistanceFromSun = 227900000,
			       				Mass = 639E21,
								Description = "Mars is the fourth planet from the Sun in the Solar System. Named after the Roman god of war, Mars, it is often described as the \"Red Planet\", as the iron oxide prevalent on its surface gives it a reddish appearance. Mars is a terrestrial planet with a thin atmosphere, having surface features reminiscent both of the impact craters of the Moon and the volcanoes, valleys, deserts, and polar ice caps of Earth. The rotational period and seasonal cycles of Mars are likewise similar to those of Earth, as is the tilt that produces the seasons. Mars is the site of Olympus Mons, the highest known mountain within the Solar System, and of Valles Marineris, one of the largest canyons.",
								Image = new Uri("/content/images/mars.jpg", UriKind.Relative)
							},
						new Planet
							{
								Id = 5,
								Name="Jupiter",
								Diameter = 142984,
								RedColouring = 128,
								BlueColouring = 110,
								GreenColouring = 90,
			       				DistanceFromSun = 778500000,
			       				Mass = 1.898E27,
								Description = "Jupiter is the fifth planet from the Sun and the largest planet within the Solar System. It is a gas giant with mass one-thousandth that of the Sun but is two and a half times the mass of all the other planets in our Solar System combined. Jupiter is classified as a gas giant along with Saturn, Uranus and Neptune. Together, these four planets are sometimes referred to as the Jovian or outer planets.",
								Image = new Uri("/content/images/jupiter.jpg", UriKind.Relative)
							},
						new Planet
							{
								Id = 7,
								Name="Saturn",
								Diameter = 120536,
								RedColouring = 217,
								BlueColouring = 189,
								GreenColouring = 150,
			       				DistanceFromSun = 1433000000,
			       				Mass = 568.3E24,
								Description = "Saturn is the sixth planet from the Sun and the second largest planet in the Solar System, after Jupiter. Named after the Roman god Saturn, its astronomical symbol represents the god's sickle. Saturn is a gas giant with an average radius about nine times that of Earth. While only one-eighth the average density of Earth, with its larger volume Saturn is just over 95 times as massive as Earth.",
								Image = new Uri("/content/images/saturn.jpg", UriKind.Relative)
							},
						new Planet
							{
								Id = 6,
								Name="Uranus",
								Diameter = 51118,
								RedColouring = 200,
								BlueColouring = 238,
								GreenColouring = 241,
			       				DistanceFromSun = 2877000000,
			       				Mass = 86.81E24,
								Description = "Uranus is the seventh planet from the Sun. It has the third-largest planetary radius and fourth-largest planetary mass in the Solar System. It is named after the ancient Greek deity of the sky Uranus, the father of Cronus and grandfather of Zeus.",
								Image = new Uri("/content/images/uranus.jpg", UriKind.Relative)
							},
						new Planet
							{
								Id = 8,
								Name="Neptune",
								Diameter = 49528,
								RedColouring = 108,
								BlueColouring = 161,
								GreenColouring = 253,
			       				DistanceFromSun = 4503000000,
			       				Mass = 102.4E24,
								Description = "Neptune is the eighth and farthest planet from the Sun in the Solar System. It is the fourth-largest planet by diameter and the third largest by mass. Neptune is 17 times the mass of Earth and is somewhat more massive than its near-twin Uranus, which is 15 times the mass of Earth but not as dense. On average, Neptune orbits the Sun at a distance of 30.1 AU, approximately 30 times the Earth–Sun distance. Named for the Roman god of the sea, its astronomical symbol is ♆, a stylized version of the god Neptune's trident.",
								Image = new Uri("/content/images/neptune.jpg", UriKind.Relative)
							}
			       	};
		}

		public Planet Get(int id)
		{
			return this.FirstOrDefault(p => p.Id == id);
		}

		#region IQueryable

		public IEnumerator<Planet> GetEnumerator()
		{
			return planets.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return planets.GetEnumerator();
		}

		public Type ElementType
		{
			get { return planets.AsQueryable().ElementType; }
		}

		public System.Linq.Expressions.Expression Expression
		{
			get { return planets.AsQueryable().Expression; }
		}

		public System.Linq.IQueryProvider Provider
		{
			get { return planets.AsQueryable().Provider; }
		}

		#endregion
	}
}
