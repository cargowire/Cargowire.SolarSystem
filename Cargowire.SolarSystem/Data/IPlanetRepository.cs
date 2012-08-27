
using System.Collections.Generic;
using System.Linq;

namespace Cargowire.SolarSystem
{
	public interface IPlanetRepository : IQueryable<Planet>
	{
		Planet Get(int id);
	}
}
