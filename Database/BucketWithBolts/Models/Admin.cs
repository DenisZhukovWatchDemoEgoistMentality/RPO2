using System.ComponentModel.DataAnnotations;

namespace BucketWithBolts.Models
{
    /// <summary>
    /// Модель таблицы Admins
    /// </summary>
    public class Admin
    {
        public int Id { get; set; }
        /// <summary>
        /// Логин
        /// </summary>
        [MaxLength(50)]
        public string Login { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        [MaxLength(255)]
        public string Password { get; set; }
    }
}