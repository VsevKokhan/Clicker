using Clicker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Clicker.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDbContext context;
        public HomeController(MyDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(string name, string password)
        {
            User? person = context.users.FirstOrDefault(x => x.name == name && x.password == password);
            
            return View(model: person);
        }

        [HttpPost]
        public JsonResult IncrementCoins(string login, string password)
        {
            User? person = context.users.FirstOrDefault(x => x.name == login && x.password == password);
            if (person != null)
            {
                person.coins += 1;
                context.SaveChanges();
            }
            
            return Json(new { success = person != null, coins = person?.coins ?? 0 });
        }
        
        public IActionResult ChangePasswordMain(int id)
        {
            User?  user = context.users.FirstOrDefault(x => x.id == id);

            return View(model: user);
        }
        public IActionResult СhangePasswordButton(User user)
        {
            if (!ModelState.IsValid)
            {
                return View("ChangePasswordMain", model: user);
            }
            
            context.users.FirstOrDefault(x => x.id == user.id).password = user.password;
            context.SaveChanges();
            
            return RedirectToAction("Index", new {name = user.name, password = user.password});
        }
    }
}
