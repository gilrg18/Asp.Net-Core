﻿using Microsoft.AspNetCore.Mvc;
using ControllersExample.Models;
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

        [Route("person")]
        public JsonResult Person() 
        {
            //Create Object ot the person class
            Person person = new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = "Gil",
                LastName = "Rangel",
                Age = 25,
            };
            //return "{\"key\", \"value\"}"; //instead of writing this confusing code
            //Convert person to json format
            //return new JsonResult(person);
            return Json(person);
        }

        [Route("file-download")] 
        public VirtualFileResult FileDownload() {
            //return new VirtualFileResult("/File.pdf", "application/pdf");
            return File("/File.pdf", "application/pdf");
        }

        [Route("file-download2")]
        public PhysicalFileResult FileDownload2()
        {
            //return new PhysicalFileResult(@"C:\Users\groge\Downloads\File2.pdf", "application/pdf");
            return PhysicalFile(@"C:\Users\groge\Downloads\File2.pdf", "application/pdf");
        }


        [Route("file-download3")]
        public IActionResult FileDownload3()
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"C:\Users\groge\Downloads\File2.pdf");
            //return new FileContentResult(bytes, "application/pdf");
            return File(bytes, "application/pdf");
        }
    }
}
