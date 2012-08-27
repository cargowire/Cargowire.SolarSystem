using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Shapes;

using Cargowire.SolarSystem.ViewModels;

namespace Cargowire.SolarSystem.Windows.Behaviours
{
	public class SetCurrentPlanetBehaviour : Behavior<FrameworkElement>
	{
		private bool mouseDown;
		private Vector delta;

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
