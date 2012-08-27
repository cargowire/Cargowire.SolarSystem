
using System.Collections.Generic;

namespace Cargowire.SolarSystem
{
	public class SolarSystem
	{
		public string Name { get; set; }
		public ICollection<Planet> Planets { get; set; }
	}
}
