using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

using Cargowire.SolarSystem.ViewModels;

namespace Cargowire.SolarSystem.Windows.Converters
{
	public class ColourValueConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value != null)
			{
				PlanetViewModel planet = (PlanetViewModel)value;
				Color planetColour = new Color { R = (byte)planet.RedColouring, G = (byte)planet.GreenColouring, B = (byte)planet.BlueColouring, A = 255 };
				return planetColour;
			}
			return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return null;
		}
	}
}
