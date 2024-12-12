﻿using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
    public class HomeController
    {
        [Route("home")] //Attribute Routing "Route" is an attribute, route template as an argument
        [Route("/")]
        public string Index() //Action Method
        {
            return "Hello from Index";
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