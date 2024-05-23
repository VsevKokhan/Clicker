using Clicker.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clicker.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly MyDbContext context;

        public AuthenticationController(MyDbContext context)
        {
            this.context = context;
        }
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
            
            if (!context.users.Any(x => x.name == user.name))
            {
                TempData["Exc"] = "Нет такого логина";
                return RedirectToAction("Index", "Authentication");
            }
            if (context.users.Any(x => x.name == user.name && !x.password.Equals(user.password)))
            {
                TempData["Exc"] = "Неправильный пароль";
                return RedirectToAction("Index", "Authentication");
            }
                
            return RedirectToAction("Index", "Home", new { name = user.name, password = user.password } );
        }
        
    }
    
}
