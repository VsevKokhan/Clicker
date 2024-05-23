using Clicker.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clicker.Controllers
{
    public class RegistrationController : Controller
    {
        MyDbContext context;
        public RegistrationController(MyDbContext context)
        {
            this.context= context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string login, string password)
        {
            if(context.users.Any(x => x.name == login))
            {
                TempData["IsUsernameTaken"] = "Этот логин уже занят, выберите другой.";

                return RedirectToAction(nameof(Index));
            }
               
            context.users.Add(new User() { name = login, password = password, coins = 0 });
            context.SaveChanges();
            
            return RedirectToAction("Index","Authentication");
        }
    }
}
