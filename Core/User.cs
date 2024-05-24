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

    }
}
