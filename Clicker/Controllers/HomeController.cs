using Clicker.Application.Services;
using Clicker.Domain.Core;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Cryptography.Xml;

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
        public IActionResult Index()
        {
            var name = HttpContext.Session.GetString("Name");
            var password = HttpContext.Session.GetString("Password");
            User? person = context.GetAll().FirstOrDefault(x => x.name == name && x.password == password);
            
            return View(model: person);
        }

        [HttpPost]
        public JsonResult IncrementCoins(string login, string password)
        {
            User? person = context.GetAll().FirstOrDefault(x => x.name == login && x.password == password);
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
            User? user = context.GetAll().FirstOrDefault(x => x.id == id);

            return View(model: user);
        }
        [HttpPost]
        public IActionResult СhangePasswordButton(User user)
        {
            if (!ModelState.IsValid)
            {
                return View("ChangePasswordMain", model: user);
            }
            
            context.GetAll().FirstOrDefault(x => x.id == user.id).password = user.password;
            context.Save();
            HttpContext.Session.SetString("Password", user.password);

            return RedirectToAction("Index");
        }
    }
}
