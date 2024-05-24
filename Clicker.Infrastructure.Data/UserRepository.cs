using Clicker.Domain.Core;
using Clicker.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clicker.Infrastructure.Data
{
    public class UserRepository:IUserRepository
    {
        private MyDbContext db;

        public UserRepository(MyDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<User> GetUserList()
        {
            return db.users.ToList();
        }

        public User GetUser(int id)
        {
            return db.users.Find(id);
        }

        public void Create(User user)
        {
            db.users.Add(user);
        }

        public void Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            User user = db.users.Find(id);
            if (user != null)
                db.users.Remove(user);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

