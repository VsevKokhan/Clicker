using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using Clicker.Application.Services;
using Clicker.Domain.Interfaces;
using Clicker.Infrastructure.Data;
using API;

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

            builder.Services.AddScoped<UsersController>();
            
            var app = builder.Build();

            // устанавливаем сопоставление маршрутов с контроллерами
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Authentication}/{action=Index}/{id?}");

            app.Run();
        }
        
    }
}
