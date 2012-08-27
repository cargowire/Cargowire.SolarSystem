using Cargowire.Navigation;
using Cargowire.Phone.Navigation;
using Cargowire.SolarSystem.ViewModels;

using Ninject;

namespace Cargowire.SolarSystem.Phone.Container
{
	public class Registry
	{
		private static readonly IKernel Kernel = new StandardKernel();

		public static void Initialize()
		{
			Kernel.Bind<IPlanetRepository>().To<StaticPlanetRepository>();
			Kernel.Bind<INavigationService>().To<SimpleNavigationService>();

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
