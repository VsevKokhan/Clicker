using Clicker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clicker.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            string login;
            string password;
            login = TempData["Login"] as string;
            password = TempData["Password"] as string;
            User list;
            using (MyDbContext context = new MyDbContext())
            {
                list = context.users.Where(x => x.name == login && x.password == password).First();
            }
            return View(model:list);
            

        }
    }
}
