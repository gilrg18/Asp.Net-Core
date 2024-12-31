using Microsoft.AspNetCore.Mvc;

namespace ViewsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            return View(); //if you dont specify the view name it will take /Views/Home/Index.cshtml because of the method name
            //return View("abcView"); //abcView.chstml
            //return new ViewResult() { ViewName = "abcView" };
        }
    }
}
