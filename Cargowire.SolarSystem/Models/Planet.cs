using System;

namespace Cargowire.SolarSystem
{
	/// <remarks>The plain planet model as would be expected to be stored in a persistant data store of some kind</remarks>
	public class Planet
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		/// <remarks>No Color class in Portable Class Libraries, or Tuple seemingly</remarks>
		public double RedColouring { get; set; }
		public double GreenColouring { get; set; }
		public double BlueColouring { get; set; }
		public Uri Image { get; set; }
		public double DistanceFromSun { get; set; }
		public double Mass { get; set; }
		public double Diameter { get; set; }
	}
}
