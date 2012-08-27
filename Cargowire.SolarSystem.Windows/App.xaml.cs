using System.Windows;

using Cargowire.SolarSystem.Windows.Container;

namespace Cargowire.SolarSystem.Windows
{
	public partial class App : Application
	{
		protected void App_Startup(object sender, StartupEventArgs args)
		{
			// Setup our dependency injection so view models can be created
			Registry.Initialize();
		}
	}
}
