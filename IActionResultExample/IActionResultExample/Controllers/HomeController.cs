using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("book")]
        public IActionResult Index()
        {
            //Book id should be supplied
            if (!Request.Query.ContainsKey("bookid"))
            {
                //Response.StatusCode = 400; //bad request
                //return Content("Book id is not supplied.");
                //Instead of writing the above 2 statements you can write:
                return BadRequest("Book id is not supplied.");
            }

            //Book id can't be empty
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                //Response.StatusCode = 400; //bad request
                //return Content("Book id can't be null or empty.");
                return BadRequest("Book id can't be null or empty.");

            }

            //Book id should be between 1 to 1000
            //It is possible to write this validations in the route constraints but its not advisable
            //because if a value doesnt match you cant give an appropiate error message to user, which is what
            //we are doing right now.
            int bookId = Convert.ToInt16(ControllerContext.HttpContext.Request.Query["bookid"]);
            if (bookId <= 0)
            {
                //Response.StatusCode = 400; //bad request
                //return Content("Book id cant be less than or equal to zero");
                return BadRequest("Book id cant be less than or equal to zero");

            }
            if (bookId > 1000)
            {
                //Response.StatusCode = 400; //bad request
                //return Content("Book id cant be greater than 1000");
                return NotFound("Book not found!"); //404
                //The difference between NotFound and NotFoundResult is the error message
                //you pass into the method
            }

            if (!Convert.ToBoolean(Request.Query["isloggedin"]))
            {
                //Response.StatusCode = 401; //unauthorized
                //return Content("User must be authenticated");
                return Unauthorized("User must be authenticated");
            }
            return File("/sample.pdf", "application/pdf");
        }
    }
}
