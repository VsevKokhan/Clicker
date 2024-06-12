using System;
using System.ComponentModel.DataAnnotations;

namespace Clicker.Domain.Core
{
    public class User
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Имя обязательно для заполнения.")]
        public string name { get; set; }
        [Required(ErrorMessage = "Пароль обязателен для заполнения.")]
        public string password { get; set; }
        public long coins { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is User us)
            {
                return name.Equals(us.name) && password.Equals(us.password) && id.Equals(us.id) && coins.Equals(us.coins);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(id, name, password, coins);
        }

    }
}
