
using System.Collections.Generic;
using System.Linq;

namespace Cargowire.SolarSystem
{
	/// <remarks>Abstracts away the actual implementation of how we get planets</remarks>
	public interface IPlanetRepository : IQueryable<Planet>
	{
		Planet Get(int id);
	}
}
