using Microsoft.AspNetCore.Mvc;
using Services;
using ServiceContracts;

namespace DIExample.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ICitiesService _citiesService;

        public HomeController(ICitiesService citiesService)
        {
            //DEPENDENCY INJECTION
            _citiesService = citiesService; //new CitiesService() - this happens automatically thanks to our IOC Container in Program.cs
        }

        [Route("/")]
        public IActionResult Index()
        {
            List<string> cities = _citiesService.GetCities();
            return View(cities);
        }
    }
}
