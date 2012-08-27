using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Data;

namespace Cargowire.SolarSystem.Windows.Converters
{
	public class DistanceValueConverter : IMultiValueConverter
	{
		public const int SCALE_FACTOR = 800;
		public const int BASE_OFFSET = 220;

		public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (values != null && values.Length == 4)
			{
				double distance = (double)values[0];
				double maxDistance = (double)values[1];
				double diameter = (double)values[2];
				double maxDiameter = (double)values[3];
				
				// minus half the planet size as planets are positioned from top left
				return ((distance / maxDistance) * SCALE_FACTOR) - (((double)new DiameterValueConverter().Convert(new []{ values[2], values[3] }, targetType, parameter, culture))/2) - BASE_OFFSET;
			}
			return null;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
		{
			return null;
		}
	}
}
