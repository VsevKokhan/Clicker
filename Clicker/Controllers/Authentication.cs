using Clicker.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clicker.Controllers
{
    public class Authentication : Controller
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
                // Если модель не валидна, возвращаем форму с ошибками валидации
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
            TempData["Login"] = user.name;
            TempData["Password"] = user.password;
            return RedirectToAction("Index", "Home");
        }
        
    }
    
}
