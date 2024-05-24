using System.Collections.Generic;
using System;
using System.Collections.Generic;
using Clicker.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace Clicker.Infrastructure.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
    }
}
