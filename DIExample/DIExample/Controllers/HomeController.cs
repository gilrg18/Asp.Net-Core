﻿using Microsoft.AspNetCore.Mvc;
using Services;
using ServiceContracts;

namespace DIExample.Controllers
{

    public class HomeController : Controller
    {
        private readonly ICitiesService _citiesService1;
        private readonly ICitiesService _citiesService2;
        private readonly ICitiesService _citiesService3;
        //CHILD SCOPE
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public HomeController(ICitiesService citiesService1, ICitiesService citiesService2, ICitiesService citiesService3
            , IServiceScopeFactory serviceScopeFactory) //CONTRUCTOR INJECTION
        {
            //DEPENDENCY INJECTION
            _citiesService1 = citiesService1; //new CitiesService() - this happens automatically thanks to our IOC Container in Program.cs
            _citiesService2 = citiesService2;
            _citiesService3 = citiesService3;
            _serviceScopeFactory = serviceScopeFactory;
        }

        [Route("/")]
        public IActionResult Index()
        //[FromServices] tells the IOC Container to supply an object of the service
        {
            List<string> cities = _citiesService1.GetCities();
            ViewBag.InstanceId_CitiesService_1 = _citiesService1.ServiceInstanceId;
            ViewBag.InstanceId_CitiesService_2 = _citiesService2.ServiceInstanceId;
            ViewBag.InstanceId_CitiesService_3 = _citiesService3.ServiceInstanceId;

            //CHILD SCOPE
            using (IServiceScope scope = _serviceScopeFactory.CreateScope())
            {
                //Inject CitiesService
                ICitiesService citiesService = scope.ServiceProvider.GetRequiredService<ICitiesService>(); //just like injecting the citiesservice in the constructor
                //DB Work

                ViewBag.InstanceId_CititesService_InScope = citiesService.ServiceInstanceId;
            }   //end of scope; it callas CitiesService.Dispose()


            return View(cities);
        }
    }
}
