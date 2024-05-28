using Clicker.Application.Services;
using Clicker.Domain.Core;

using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Clicker.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserService context;
        public HomeController(UserService context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult Index(string name, string password)
        {
            User? person = context.GetAllUsers().FirstOrDefault(x => x.name == name && x.password == password);
            
            return View(model: person);
        }

        [HttpPost]
        public JsonResult IncrementCoins(string login, string password)
        {
            User? person = context.GetAllUsers().FirstOrDefault(x => x.name == login && x.password == password);
            if (person != null)
            {
                person.coins += 1;
                context.Save();
            }
            
            return Json(new { success = person != null, coins = person?.coins ?? 0 });
        }
        [HttpGet]
        public IActionResult ChangePasswordMain(int id)
        {
            User?  user = context.GetAllUsers().FirstOrDefault(x => x.id == id);

            return View(model: user);
        }
        [HttpPost]
        public IActionResult СhangePasswordButton(User user)
        {
            if (!ModelState.IsValid)
            {
                return View("ChangePasswordMain", model: user);
            }
            
            context.GetAllUsers().FirstOrDefault(x => x.id == user.id).password = user.password;
            context.Save();
            
            return RedirectToAction("Index", new {name = user.name, password = user.password});
        }
    }
}
