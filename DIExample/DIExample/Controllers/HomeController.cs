using Microsoft.AspNetCore.Mvc;
using Services;
using ServiceContracts;

namespace DIExample.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ICitiesService _citiesService;

        public HomeController()
        {
            //instantiate the CitiesService class;
            //this is a bad practice, you should use DEPENDENCY INJECTION
            _citiesService = null;//how to create object??
        }

        [Route("/")]
        public IActionResult Index()
        {
            List<string> cities = _citiesService.GetCities();
            return View(cities);
        }
    }
}
