using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
    public class HomeController 
    {
        [Route("sayhello")] //Attribute Routing "Route" is an attribute, route template as an argument
       public string method1()
        {
            return "Hello from method1";
        }
    }
}
