using Microsoft.AspNetCore.Mvc;
using ModelValidationsExample.CustomModelBinders;
using ModelValidationsExample.Models;

namespace ModelValidationsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        //public IActionResult Index([Bind(nameof(Person.Name), nameof(Person.Email), nameof(Person.Password), 
        //    nameof(Person.ConfirmPassword))] Person person)
        public IActionResult Index([FromBody] [ModelBinder(BinderType = typeof(PersonModelBinder))]Person person)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("\n", 
                ModelState.Values.SelectMany(value => //first loop
                value.Errors).Select(err => //inner loop
                err.ErrorMessage));
                return BadRequest(errors);
            }
            return Content($"{person}");
        }
    }
}
