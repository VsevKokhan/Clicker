using Microsoft.EntityFrameworkCore;
namespace Clicker.Models
{       
    public class MyDbContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options):base(options)
        {
        }
    }
}
