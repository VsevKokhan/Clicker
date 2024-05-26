using Clicker.Application.Services;
using Clicker.Domain.Core;

using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Index(string login, string password)
        {
            if(context.GetAllUsers().Any(x => x.name == login))
            {
                TempData["IsUsernameTaken"] = "Этот логин уже занят, выберите другой.";

                return RedirectToAction(nameof(Index));
            }
               
            context.AddUser(new User() { name = login, password = password, coins = 0 });
            context.Save();
            
            return RedirectToAction("Index","Authentication");
        }
    }
}
