using Microsoft.AspNetCore.Mvc;
using Services;

namespace DIExample.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly CitiesService _citiesService;

        public HomeController()
        {
            //instantiate the CitiesService class;
            //this is a bad practice, you should use DEPENDENCY INJECTION
            _citiesService = new CitiesService();
        }

        [Route("/")]
        public IActionResult Index()
        {
            List<string> cities = _citiesService.GetCities();
            return View(cities);
        }
    }
}
