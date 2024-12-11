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
        public IActionResult Index(InputModel model, string action)
        {
            // Reset header color flags
            model.IsAwwab = false;
            model.IsZainab = false;
            // model.Message = string.Empty;

            if (model.UserInput == "awwab" && action == "enter")
            {
                model.IsAwwab = true;
                var hisModel = new AwwabModel(){
                    CanEdit = true
                };
                return View("AwwabPage", hisModel);
            }
            else if (model.UserInput == "zainab" && action == "enter")
            {
                model.IsZainab = true;
                var myModel = new ZainabModel{
                    CanEdit = true
                };
                return View("ZainabPage", myModel);
            }
            else
            {
                // model.Message = "Invalid input";
                return View(model);
            }
            
        }
        
        [HttpPost]
        public ActionResult AwwabPage(string action)
        {          
            if (action == "view")
            {
                var myViewModel = new ZainabModel{
                    CanEdit = false
                };
                return View("ZainabPage", myViewModel);
            }
            else if(action == "back"){
                var myModel = new ZainabModel(){
                    CanEdit = true
                };
                return View("ZainabPage", myModel);
            }
            else{
                var hisModel = new AwwabModel(){
                    CanEdit = true
                };
                return View("AwwabPage", hisModel);
            }
        }

        [HttpPost]
        public ActionResult ZainabPage(string action)
        {          
            if (action == "view")
            {
                var hisViewModel = new AwwabModel{
                    CanEdit = false
                };
                return View("ZainabPage", hisViewModel);
            }
            else if(action == "back"){
                var hisModel = new AwwabModel(){
                    CanEdit = true
                };
                return View("AwwabPage", hisModel);
            }
            else{
                var myModel = new ZainabModel(){
                    CanEdit = true
                };
                return View("ZainabPage", myModel);
            }
        }
    }
}
