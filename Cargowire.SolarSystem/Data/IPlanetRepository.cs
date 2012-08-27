
using System.Collections.Generic;
using System.Linq;

using Cargowire.Data;

namespace Cargowire.SolarSystem
{
	/// <remarks>Abstracts away the actual implementation of how we get planets</remarks>
	public interface IPlanetRepository : IRepository<Planet, int>
	{
	}
}
