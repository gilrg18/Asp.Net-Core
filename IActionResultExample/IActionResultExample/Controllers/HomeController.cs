using Microsoft.AspNetCore.Mvc;
using IActionResultExample.Models;
namespace IActionResultExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("bookstore/{bookid?}/{isloggedin?}")]
        //url: /bookstore?bookid=10&isloggedin=true
        //public IActionResult Index([FromRoute] int? bookid, [FromRoute] bool? isloggedin)
        public IActionResult Index([FromQuery] int? bookid, [FromQuery] bool? isloggedin, Book book)

        {

            if (bookid.HasValue == false)
            {
                return BadRequest("Book id is not supplied or empty.");
            }

            if (bookid < 0)
            {
                return BadRequest("Book id can't be less than or equal to 0");
            }

            //if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            //{
            //    return BadRequest("Book id can't be null or empty.");

            //}
            
            if (bookid > 1000)
            {

                return NotFound("Book not found!"); //404
            }

            if (isloggedin == false || isloggedin == null)
            {

                return Unauthorized("User must be authenticated");
            }
            //return new RedirectToActionResult("Books","Store",new { });
            //(actionName, controllerName, routeValues)
            //new{ } is a dummy value since we dont have any specific route parameters to pass

            //true - 301 instead of 302, 301 means Moved Permanently

            //Shortcut version of RedirectToActionResult is RedirectToAction (shorthand method) 
            //- they both work the same way
            //return new RedirectToActionResult("Books", "Store", new { }, true); 
            //return RedirectToAction("Books", "Store", new { id = bookId });
            //return RedirectToActionPermanent("Books", "Store", new { id = bookId });

            //You cannot redirect to another website
            //In real world projects, redirect to action is better because
            //you can easily change the action method name and controller name
            //return new LocalRedirectResult("store/books/{bookId}");
            //return LocalRedirect($"store/books/{bookId}"); //302
            //return new LocalRedirectResult($"store/books/{bookId}", true); //301
            //return LocalRedirectPermanent($"store/books/{bookId}"); //301

            //REDIRECTRESULT
            //return Redirect($"store/books/{bookId}");//302
            //return RedirectPermanent($"store/books/{bookId}"); //301
            return Content($"Book id: {bookid}, Book {book}", "text/plain");
        }
    }
}
