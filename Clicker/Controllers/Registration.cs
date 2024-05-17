using Clicker.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clicker.Controllers
{
    public class Registration : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string login, string password)
        {
            TempData["IsUsernameTaken"] = false;
            using (MyDbContext db = new MyDbContext())
            {
                if(db.users.Any(x => x.name == login))
                {
                    TempData["IsUsernameTaken"] = true;

                    return RedirectToAction(nameof(Index));
                }
                
                db.users.Add(new User() { name = login, password = password, coins = 0 });
                db.SaveChanges();
            }
            return RedirectToAction("Index","Authentication");
        }
    }
}
