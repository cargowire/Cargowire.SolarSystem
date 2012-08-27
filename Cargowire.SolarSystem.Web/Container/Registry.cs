using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using Ninject;
using Ninject.Web.Common;

using Cargowire.Navigation;
using Cargowire.Web.Navigation;

using Cargowire.SolarSystem.Web.Controllers;
using Cargowire.SolarSystem.ViewModels;

namespace Cargowire.SolarSystem.Web.Container
{
	public class Registry
	{
		private static readonly IKernel Kernel = new StandardKernel();

		public static void Initialize()
		{
			// Required due to: http://stackoverflow.com/questions/9693957/ninject-web-common-throwing-activationexception-trying-to-inject-dependencies-in
			Kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
			Kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();


			Kernel.Bind<IPlanetRepository>().To<StaticPlanetRepository>();
			Kernel.Bind<INavigationService>().To<WebNavigationService>();

			// These are acting like ViewModelFactories/Services and maybe shouldn't (see notes document)
			Kernel.Bind<SolarSystemViewModel>()
				.ToConstructor<SolarSystemViewModel>(x => new SolarSystemViewModel(Kernel.Get<IPlanetRepository>(), Kernel.Get<INavigationService>()));
			Kernel.Bind<PlanetViewModel>()
				.ToConstructor<PlanetViewModel>(x => new PlanetViewModel(Kernel.Get<IPlanetRepository>()));

			Kernel.Bind<SolarSystemController>().To<SolarSystemController>();
		}

		/// <remarks>We're only using this for reference types at the moment anyway and the constraint makes the kernel check easier</remarks>
		public static T Get<T>()
			where T : class
		{
			if (typeof(T) == typeof(IKernel))
				return Kernel as T;
			else
				return Kernel.Get<T>();
		}
	}
}
