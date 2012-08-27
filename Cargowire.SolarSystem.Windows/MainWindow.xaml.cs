using System.Windows;

using Cargowire.SolarSystem.Windows.Container;
using Cargowire.SolarSystem.ViewModels;

namespace Cargowire.SolarSystem.Windows
{
	/// <summary>The only direct access to the container outside of app start.  Used as the 'cascade'
	/// of view models as each user control will run off of this one</summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			DataContext = Registry.Get<SolarSystemViewModel>();
		}
	}
}
