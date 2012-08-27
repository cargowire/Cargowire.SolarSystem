using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

using Cargowire.SolarSystem.Windows.Container;

namespace Cargowire.SolarSystem.Windows
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected void App_Startup(object sender, StartupEventArgs args)
		{
			Registry.Initialize();
		}
	}
}
