using Microsoft.AspNetCore.Mvc;
using WishlistWebsiteMVC.Models;

namespace InputBasedWebsiteMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home
        public IActionResult Index()
        {
            return View(new InputModel());
        }

        // POST: /Home
        [HttpPost]
        public IActionResult Index(InputModel model)
        {
            // Reset header color flags
            model.IsAwwab = false;
            model.IsZainab = false;
            model.Message = string.Empty;

            if (model.UserInput == "awwab")
            {
                model.IsAwwab = true;
            }
            else if (model.UserInput == "zainab")
            {
                model.IsZainab = true;
            }
            else
            {
                model.Message = "Invalid input";
            }

            return View(model);
        }
    }
}
