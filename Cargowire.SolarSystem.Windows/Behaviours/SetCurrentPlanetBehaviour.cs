using System.Windows;
using System.Windows.Interactivity;

using Cargowire.SolarSystem.ViewModels;

namespace Cargowire.SolarSystem.Windows.Behaviours
{
	public class SetCurrentPlanetBehaviour : Behavior<FrameworkElement>
	{
		protected override void OnAttached()
		{
			AssociatedObject.MouseLeftButtonUp += (s, e) =>
			{
				var pvm = AssociatedObject.DataContext as PlanetViewModel;
				var svm = AssociatedObject.Tag as SolarSystemViewModel;
				svm.CurrentPlanet = pvm;
			};
		}
	}
}
