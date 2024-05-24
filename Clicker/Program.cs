using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using Clicker.Application.Services;
using Clicker.Domain.Interfaces;
using Clicker.Infrastructure.Data;

namespace Clicker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews(); // добавляем сервисы MVC
            builder.Services.AddDbContext<MyDbContext>(options =>
               options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<UserService>();
            var app = builder.Build();

            // устанавливаем сопоставление маршрутов с контроллерами
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Registration}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
