using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using Clicker.Models;

namespace Clicker
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews(); // добавляем сервисы MVC

            var app = builder.Build();

            // устанавливаем сопоставление маршрутов с контроллерами
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Authentication}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
