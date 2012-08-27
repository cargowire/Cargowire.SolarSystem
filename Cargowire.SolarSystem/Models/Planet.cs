using System;

namespace Cargowire.SolarSystem
{
	public class Planet
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		// No colour class in Portable Class Libraries
		public double RedColouring { get; set; }
		public double GreenColouring { get; set; }
		public double BlueColouring { get; set; }
		public Uri Image { get; set; }
		public double DistanceFromSun { get; set; }
		public double Mass { get; set; }
		public double Diameter { get; set; }
	}
}
