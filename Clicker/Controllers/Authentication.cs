
using Clicker.Application.Services;
using Clicker.Domain.Core;
using Microsoft.AspNetCore.Mvc;

namespace Clicker.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly UserService context;

        public AuthenticationController(UserService context)
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
            
            if (!context.GetAll().Any(x => x.name == user.name))
            {
                TempData["Exc"] = "Нет такого логина";
                return RedirectToAction("Index", "Authentication");
            }
            if (context.GetAll().Any(x => x.name == user.name && !x.password.Equals(user.password)))
            {
                TempData["Exc"] = "Неправильный пароль";
                return RedirectToAction("Index", "Authentication");
            }
            HttpContext.Session.SetString("Name",user.name);
            HttpContext.Session.SetString("Password", user.password);

            return RedirectToAction("Index", "Home");
        }
        
    }
    
}
