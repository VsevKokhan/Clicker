using Clicker.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clicker.Controllers
{
    public class Authentication : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            TempData["Exc"] = Exc.None;
            return View();
        }
        [HttpPost]
        public IActionResult Index(string login, string password)
        {
            
            switch (Check(login, password))
            {
                case Exc.None:
                    TempData["Login"] = login;
                    TempData["Password"] = password;

                    return RedirectToAction("Index","Home");
                    
                case Exc.Password:
                    TempData["Exc"] = Exc.Password;
                    return RedirectToAction(nameof(Index));
                case Exc.Name:
                    TempData["Exc"] = Exc.Name;
                    return RedirectToAction(nameof(Index));

            }
            return Content("Неизвестная ошибка");
        }
        public Exc Check(string login, string password)
        {
            using(var db = new MyDbContext()) 
            {
                if(db.users.Any(x => x.name != login))
                {
                    return Exc.Name;
                }
                else if(db.users.Any(x => x.name == login && !x.password.Equals(password)))
                {
                    return Exc.Password;
                }
                else  return Exc.None; 
            }
        }
        
    }
    public enum Exc
    {
        Password = 0,
        Name = 1,
        None = 2
    }
}
