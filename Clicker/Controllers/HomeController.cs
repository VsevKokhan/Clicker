using Clicker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
        public JsonResult IncrementCoins(string login, string password)
        {
            User? person;
            using (MyDbContext context = new MyDbContext())
            {
                person = context.users.FirstOrDefault(x => x.name == login && x.password == password);
                if (person != null)
                {
                    person.coins += 1;
                    context.SaveChanges();
                }
            }

            return Json(new { success = person != null, coins = person?.coins ?? 0 });
        }
        
        public IActionResult ChangePasswordMain(int id)
        {
            User? user;
            using (MyDbContext context = new MyDbContext()) 
            {
                user = context.users.FirstOrDefault(x => x.id == id);

            }
            return View(model: user);
            
        }
        public void СhangePasswordButton(int newPassword)
        {
            using(MyDbContext context = new MyDbContext())
            {
                
            }
        }
    }
}
