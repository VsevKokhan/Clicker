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

            builder.Services.AddDistributedMemoryCache(); // Использование в памяти кэша для сессий
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true; 
                options.Cookie.IsEssential = true;
            });
            builder.Services.AddControllersWithViews(); // добавляем сервисы MVC
            builder.Services.AddDbContext<MyDbContext>(options =>
               options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<UserService>();

            builder.Services.AddScoped<UsersController>();
            
            var app = builder.Build();

            
            app.UseSession();

            // устанавливаем сопоставление маршрутов с контроллерами
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Registration}/{action=Index}/{id?}");

            app.Run();
        }
        
    }
}
