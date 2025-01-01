using Microsoft.AspNetCore.Mvc;
using ViewsExample.Models;

namespace ViewsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            ViewData["pageTitle"] = "Razor Views Example";

            List<Person> people = new List<Person>()
            {
                new Person() {Name="Gil",DateOfBirth = DateTime.Parse("2000-01-01"), PersonGender = Gender.Male},
                new Person() {Name="Gil",DateOfBirth = DateTime.Parse("2000-01-01"), PersonGender = Gender.Male},
                new Person() {Name="Gil",DateOfBirth = null, PersonGender = Gender.Male},
            };
            //ViewData["people"] = people;
            ViewBag.people = people; //heres no benefit, just syntactic sugar

            return View(); //if you dont specify the view name it will take /Views/Home/Index.cshtml because of the method name
            //return View("abcView"); //abcView.chstml
            //return new ViewResult() { ViewName = "abcView" };
        }
    }
}
