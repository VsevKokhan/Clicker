using Clicker.Application.Services;
using Clicker.Domain.Core;

using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Clicker.Controllers
{
    public class RegistrationController : Controller
    {
        UserService context;
        public RegistrationController(UserService context)
        {
            this.context= context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(User model)
        {
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (context.GetAllUsers().Any(x => x.name == model.name))
            {
                TempData["IsUsernameTaken"] = "Этот логин уже занят, выберите другой.";

                return RedirectToAction(nameof(Index));
            }
               
            context.AddUser(new User() { name = model.name, password = model.password, coins = 0 });
            context.Save();
            
            return RedirectToAction("Index","Authentication");
        }
    }
}
