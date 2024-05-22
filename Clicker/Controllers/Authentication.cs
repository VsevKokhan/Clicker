using Clicker.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clicker.Controllers
{
    public class AuthenticationController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Index(User user)
        {
            if (!ModelState.IsValid)
            {
                
                return View(user);
            }
            using (var db = new MyDbContext())
            {
                if (!db.users.Any(x => x.name == user.name))
                {
                    TempData["Exc"] = "Нет такого логина";
                    return RedirectToAction("Index", "Authentication");
                }
                if (db.users.Any(x => x.name == user.name && !x.password.Equals(user.password)))
                {
                    TempData["Exc"] = "Неправильный пароль";
                    return RedirectToAction("Index", "Authentication");
                }
                
            }
            return RedirectToAction("Index", "Home", new { name = user.name, password = user.password } );
        }
        
    }
    
}
