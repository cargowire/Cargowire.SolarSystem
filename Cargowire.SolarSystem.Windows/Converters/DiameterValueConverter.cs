using System;

using System.Windows.Data;

namespace Cargowire.SolarSystem.Windows.Converters
{
	public class DiameterValueConverter : IMultiValueConverter
	{
		public const int SCALE_FACTOR = 100;

		public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (values != null && values.Length == 2)
			{
				double diameter = (double)values[0];
				double maxDiameter = (double)values[1];
				return ((diameter / maxDiameter) * SCALE_FACTOR);
			}
			return null;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
		{
			return null;
		}
	}
}
