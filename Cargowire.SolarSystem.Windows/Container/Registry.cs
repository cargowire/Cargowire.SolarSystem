using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ninject;

using Cargowire.Navigation;
using Cargowire.Windows.Navigation;
using Cargowire.SolarSystem.ViewModels;

namespace Cargowire.SolarSystem.Windows.Container
{
	public class Registry
	{
		private static readonly IKernel Kernel = new StandardKernel();

		public static void Initialize()
		{
			Kernel.Bind<IPlanetRepository>().To<StaticPlanetRepository>();
			Kernel.Bind<INavigationService>().To<WpfNavigationService>();

			Kernel.Bind<SolarSystemViewModel>()
				.ToConstructor<SolarSystemViewModel>(x => new SolarSystemViewModel(Kernel.Get<IPlanetRepository>(), Kernel.Get<INavigationService>()));
			Kernel.Bind<PlanetViewModel>()
				.ToConstructor<PlanetViewModel>(x => new PlanetViewModel(Kernel.Get<IPlanetRepository>()));
		}

		public static T Get<T>()
		{
			return Kernel.Get<T>();
		}
	}
}
