using Microsoft.AspNetCore.Mvc;
using WishlistWebsiteMVC.Models;
using System.Data.SQLite;

namespace InputBasedWebsiteMVC.Controllers
{
    public class HomeController : Controller
    {
        private string connectionString = "Data Source=app.db;Version=3;";

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
        public ActionResult AwwabPage(string action, string value)
        {          
            var hisModel = new AwwabModel(){
                    CanEdit = true
                };
            if (action == "view")
            {
                var myViewModel = new ZainabModel{
                    CanEdit = false
                };
                return View("ZainabPage", myViewModel);
            }
            else if(action == "add"){
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO table1 (Value) VALUES (@Value)";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Value", value);
                        command.ExecuteNonQuery();
                    }
                }
                return View("AwwabPage", hisModel);
            }
            else if(action == "back"){
                var myModel = new ZainabModel(){
                    CanEdit = true
                };
                return View("ZainabPage", myModel);
            }
            else{
                return View("AwwabPage", hisModel);
            }
        }

        [HttpPost]
        public ActionResult ZainabPage(string action, string value)
        {          
            var myModel = new ZainabModel(){
                    CanEdit = true
                };
            if (action == "view")
            {
                var hisViewModel = new AwwabModel{
                    CanEdit = false
                };
                return View("ZainabPage", hisViewModel);
            }
            else if (action == "add"){

                using (var connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();
                        string query = "INSERT INTO table2 (Value) VALUES (@Value)";
                        using (var command = new SQLiteCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Value", value);
                            command.ExecuteNonQuery();
                        }
                    }
                return View("ZainabPage", myModel);
            }
            else if(action == "back"){
                var hisModel = new AwwabModel(){
                    CanEdit = true
                };
                return View("AwwabPage", hisModel);
            }
            else{
                return View("ZainabPage", myModel);
            }
        }
    }
}
