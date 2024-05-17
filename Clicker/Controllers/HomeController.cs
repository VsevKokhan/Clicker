using Clicker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Clicker.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            string login = TempData["Login"] as string;
            string password = TempData["Password"] as string;
            
            User? person;
            
            using (MyDbContext context = new MyDbContext())
            {
                person = context.users.FirstOrDefault(x => x.name == login && x.password == password);
            }
            
            return View(model: person);
            
        }
        
        [HttpPost]
        public ActionResult IncrementCoins(string login, string password)
        {


            User? person;
            using (MyDbContext context = new MyDbContext())
            {
                person = context.users.FirstOrDefault(x => x.name == login && x.password == password);
                person.coins += 1;
                context.SaveChanges();
            }
            TempData["Login"] = login;
            TempData["Password"] = password;
            return RedirectToAction("Index"); // Перенаправляем пользователя обратно на страницу кликера
        }
    }
}
