﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Cargowire.Navigation;
using Cargowire.SolarSystem.ViewModels;

namespace Cargowire.SolarSystem.Web.Controllers
{
    public class SolarSystemController : Controller
    {
		private INavigationService _navigationService;
		private IPlanetRepository _repo;

		public SolarSystemController(INavigationService navigation, IPlanetRepository repo)
		{
			this._navigationService = navigation;
			this._repo = repo;
		}

		/// <remarks>Actually creates the view models, this may be nicer if a ViewModelFactory/Service was passed
		/// as a dependency instead avoiding any concrete creation here.</remarks>
        public ActionResult Index()
        {
			var vm = new SolarSystemViewModel(_repo, _navigationService);
			return View(vm);
        }

		/// <remarks>Actually creates the view models, this may be nicer if a ViewModelFactory/Service was passed
		/// as a dependency instead avoiding any concrete creation here.</remarks>
		public ActionResult Planet(int id)
		{
			var vm = new PlanetViewModel(_repo, _repo.Get(id));
			return View(vm);
		}
    }
}
