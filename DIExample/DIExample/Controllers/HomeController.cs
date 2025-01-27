using Microsoft.AspNetCore.Mvc;
using Services;
using ServiceContracts;
using Autofac;

namespace DIExample.Controllers
{

    public class HomeController : Controller
    {
        private readonly ICitiesService _citiesService1;
        private readonly ICitiesService _citiesService2;
        private readonly ICitiesService _citiesService3;
        private readonly IEnumerable<ICitiesService> _citiesServices;
        //CHILD SCOPE
        //private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILifetimeScope _lifeTimeScope; //From autofac

        public HomeController(IEnumerable<ICitiesService> citiesServices,ICitiesService citiesService1, ICitiesService citiesService2, ICitiesService citiesService3
            , ILifetimeScope serviceScopeFactory) //CONTRUCTOR INJECTION
        {
            //DEPENDENCY INJECTION
            _citiesServices = citiesServices;
            _citiesService1 = citiesService1; //new CitiesService() - this happens automatically thanks to our IOC Container in Program.cs
            _citiesService2 = citiesService2;
            _citiesService3 = citiesService3;
            _lifeTimeScope = serviceScopeFactory;
        }

        [Route("/")]
        public IActionResult Index()
        //[FromServices] tells the IOC Container to supply an object of the service
        {
            // Create a list to store the results
            List<string> allCities = new List<string>();
            foreach (ICitiesService service in _citiesServices)
            {
                List<string> citiesFromBothServices = service.GetCities();
                allCities.AddRange(citiesFromBothServices);
            }
            ViewBag.citiesFromBothServices = allCities;

            List<string> cities = _citiesService1.GetCities();
            ViewBag.InstanceId_CitiesService_1 = _citiesService1.ServiceInstanceId;
            ViewBag.InstanceId_CitiesService_2 = _citiesService2.ServiceInstanceId;
            ViewBag.InstanceId_CitiesService_3 = _citiesService3.ServiceInstanceId;

            //CHILD SCOPE
            using (ILifetimeScope scope = _lifeTimeScope.BeginLifetimeScope())
            {
                //Inject CitiesService
                ICitiesService citiesService = scope.Resolve<ICitiesService>(); //just like injecting the citiesservice in the constructor
                //DB Work

                ViewBag.InstanceId_CititesService_InScope = citiesService.ServiceInstanceId;
            }   //end of scope; it callas CitiesService.Dispose()


            return View(cities);
        }
    }
}
