using System;

using System.Windows.Data;

namespace Cargowire.SolarSystem.Windows.Converters
{
	public class TopOffsetValueConverter : IMultiValueConverter
	{
		public const int BASE_OFFSET = 75;

		public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (values != null &&  values.Length == 2)
			{
				double diameter = (double)values[0];
				double maxDiameter = (double)values[1];
				return BASE_OFFSET - (((double)new DiameterValueConverter().Convert(new[] { values[0], values[1] }, targetType, parameter, culture)) / 2);
			}
			return null;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
		{
			return null;
		}
	}
}
