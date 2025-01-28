using Microsoft.AspNetCore.Mvc;

namespace EnvironmentsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        [Route("some-route")]
        public IActionResult Index()
        {
            return View();
        }

        //Purposely causing an exception to show dev exception page
        [Route("some-route")]
        public IActionResult Other()
        {
            return View();
        }
    }
}
