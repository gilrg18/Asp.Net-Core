using Microsoft.AspNetCore.Mvc;
using Services;
using ServiceContracts;

namespace DIExample.Controllers
{
   
    public class HomeController : Controller
    {
        //private readonly ICitiesService _citiesService;

        //public HomeController(ICitiesService citiesService) //CONTRUCTOR INJECTION
        //{
        //    //DEPENDENCY INJECTION
        //    _citiesService = citiesService; //new CitiesService() - this happens automatically thanks to our IOC Container in Program.cs
        //}

        [Route("/")]
        public IActionResult Index([FromServices] ICitiesService citiesService) //METHOD INJECTION
            //[FromServices] tells the IOC Container to supply an object of the service
        {
            List<string> cities = citiesService.GetCities();
            return View(cities);
        }
    }
}
