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
            //ViewBag.people = people; //heres no benefit, just syntactic sugar

            //Instead of using ViewBag for List of persons we pass the List of persons (people) to the View
            return View("Index", people); //if you dont specify the view name it will take /Views/Home/Index.cshtml because of the method name
            //return View("abcView"); //abcView.chstml
            //return new ViewResult() { ViewName = "abcView" };
        }

        [Route("person-details/{name}")]
        public IActionResult Details(string? name)
        {
            if (name == null)
            {
                return Content("Person name can't be null");
            }
            List<Person> people = new List<Person>()
            {
                new Person() {Name="Gil",DateOfBirth = DateTime.Parse("2000-01-01"), PersonGender = Gender.Male},
                new Person() {Name="Gil",DateOfBirth = DateTime.Parse("2000-01-01"), PersonGender = Gender.Male},
                new Person() {Name="Gil",DateOfBirth = null, PersonGender = Gender.Male},
            };
            //Return the first match
            Person matchingPerson = people.Where(temp => temp.Name == name).FirstOrDefault();
            return View(matchingPerson); //Views/Home/Details.cshtml
        }

        [Route("person-with-product")]
        public IActionResult PersonWithProduct()
        {
            Person person = new Person()
            {
                Name = "Name",
                PersonGender = Gender.Male,
                DateOfBirth = Convert.ToDateTime("2004-05-05")
            };

            Product product = new Product()
            {
                ProductId = 1,
                ProductName = "Shampoo",
            };

            PersonAndProductWrapperModel personAndProductWrapperModel = new PersonAndProductWrapperModel()
            {
                PersonData = person,
                ProductData = product,
            };
            return View(personAndProductWrapperModel);
        }

        [Route("home/all")]
        public IActionResult All()
        {
            return View();
            //Views/Home/All.cshtml - First searches in Home Folder
            //Views/Shared/All.cshtml
        }

    }
}
