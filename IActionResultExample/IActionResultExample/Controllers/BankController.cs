using IActionResultExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
   
    public class BankController : Controller
    {
        private Account acc = new Account()
        {
            AccountNumber = 1001,
            AccountHolderName = "Example Name",
            CurrentBalance = 5000,
        };

        [Route("/")]
        public IActionResult Index()
        {
            return Content("<h1>Welcome to the best Bank</h1>", "text/html");
        }

        [Route("/account-details")]
        public IActionResult Details()
        {
            
            return new JsonResult(acc);
        }

        [Route("/account-statement")]
        public IActionResult Statement()
        {
            
            return new VirtualFileResult("/DummyFile.pdf", "application/pdf");
        }

        [Route("/get-current-balance/{accountNumber:int?}")]
        public IActionResult Balance(int? accountNumber)
        {
            if (accountNumber==null)
            {
                return NotFound("Account Number should be supplied");
            }
            if (accountNumber != 1001)
            {
                return BadRequest("Account Number should be 1001");
            }
            return Content(acc.CurrentBalance.ToString(), "text/plain");
        }
    }
}
