
using System.Collections.Generic;

namespace Cargowire.SolarSystem
{
	/// <remarks>The plain solar system model as would be expected to be stored in a persistant data store of some kind
	/// (particularly if we were going for multiple solar systems)</remarks>
	public class SolarSystem
	{
		public string Name { get; set; }
		public ICollection<Planet> Planets { get; set; }
	}
}
