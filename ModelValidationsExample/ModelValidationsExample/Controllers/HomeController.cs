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
        //public IActionResult Index([FromBody] [ModelBinder(BinderType = typeof(PersonModelBinder))]Person person)
        public IActionResult Index(Person person, [FromHeader(Name = "User-Agent")] string UserAgent)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("\n", 
                ModelState.Values.SelectMany(value => //first loop
                value.Errors).Select(err => //inner loop
                err.ErrorMessage));
                return BadRequest(errors);
            }
            //Retrieve value from request headers in traditional code:
            //ControllerContext.HttpContext.Request.Headers["key"];
            return Content($"{person}, {UserAgent}");
        }
    }
}
