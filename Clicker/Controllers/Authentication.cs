using Clicker.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clicker.Controllers
{
    public class Authentication : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            //asdasdasd
            return View();
        }
        [HttpPost]
        public IActionResult Index(string login, string password)
        {
            using (var db = new MyDbContext())
            {
                if (!db.users.Any(x => x.name == login))
                {
                    TempData["Exc"] = "Нет такого логина";
                    return RedirectToAction("Index", "Authentication");
                }
                if (db.users.Any(x => x.name == login && !x.password.Equals(password)))
                {
                    TempData["Exc"] = "Неправильный пароль";
                    return RedirectToAction("Index", "Authentication");
                }
                
            }
            TempData["Login"] = login;
            TempData["Password"] = password;
            return RedirectToAction("Index", "Home");
        }
        
    }
    
}
