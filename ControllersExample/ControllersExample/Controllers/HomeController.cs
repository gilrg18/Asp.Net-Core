using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")] //Attribute Routing "Route" is an attribute, route template as an argument
        [Route("/")]
        public ContentResult Index() //Action Method
        {
            //return new ContentResult() { 
            //    Content = "Hello from Index" ,
            //    ContentType = "text/plain"
            //};
            //Shortcut version of above (using Microsoft.AspNetCore.Mvc.Controller)
            //return Content("Hello from Index Siu", "text/plain");
            return Content("<h1>Welcome</h1> <h2>Hello from Index</h2>", "text/html");
        }

        [Route("about")]
        public string About() //Action Method
        {
            return "Hello from About";
        }

        [Route("contact-us/{mobile:regex(^\\d{{10}}$)}")] //url and action method can be named differently
        public string Contact([FromRoute] string mobile) // Binds the "mobile" route value directly to the parameter
                                                         //Action Method
        {
            return $"Hello from Contact {mobile}";
        }
    }
}
