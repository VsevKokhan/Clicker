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

            builder.Services.AddControllersWithViews(); // ��������� ������� MVC

            var app = builder.Build();

            // ������������� ������������� ��������� � �������������
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Authentication}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
