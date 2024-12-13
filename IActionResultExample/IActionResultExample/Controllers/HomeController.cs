using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("bookstore")]
        public IActionResult Index()
        {

            if (!Request.Query.ContainsKey("bookid"))
            {
                return BadRequest("Book id is not supplied.");
            }


            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                return BadRequest("Book id can't be null or empty.");

            }
            int bookId = Convert.ToInt16(ControllerContext.HttpContext.Request.Query["bookid"]);
            if (bookId <= 0)
            {

                return BadRequest("Book id cant be less than or equal to zero");

            }
            if (bookId > 1000)
            {

                return NotFound("Book not found!"); //404
            }

            if (!Convert.ToBoolean(Request.Query["isloggedin"]))
            {

                return Unauthorized("User must be authenticated");
            }
            //return new RedirectToActionResult("Books","Store",new { });
            //(actionName, controllerName, routeValues)
            //new{ } is a dummy value since we dont have any specific route parameters to pass
            return new RedirectToActionResult("Books", "Store", new { }, true); 
            //true - 301 instead of 302, 301 means Moved Permanently
        }
    }
}
