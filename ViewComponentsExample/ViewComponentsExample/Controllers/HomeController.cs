using Microsoft.AspNetCore.Mvc;
using ViewComponentsExample.Models;

namespace ViewComponentsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("about")]
        public IActionResult About()
        {
            return View();
        }

        [Route("friends")]
        public IActionResult LoadFriendsList()
        {
            PersonTableModel personTableModel = new PersonTableModel()
            {
                TableTitle = "Friends",
                Persons = new List<Person>()
                {
                    new Person() { Name ="Friend", JobTitle="A"},
                    new Person() { Name ="Friend2", JobTitle="B"},
                    new Person() { Name ="Friend3", JobTitle="C"},
                }
            };

            return  ViewComponent("Table", new {table = personTableModel}); //ViewComponent(Name of the ViewComponent, model object)
        }
    }
}
