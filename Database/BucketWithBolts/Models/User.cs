using System.ComponentModel.DataAnnotations;

namespace BucketWithBolts.Models
{
    /// <summary>
    /// Модель таблицы Users
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        /// <summary>
        /// Логин
        /// </summary>
        [MaxLength(50)]
        public string Login { get; set; }
        /// <summary>
        /// Почта
        /// </summary>
        [MaxLength(50)]
        public string Mail { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        [MaxLength(255)]
        public string Password { get; set; }
        /// <summary>
        /// Баланс
        /// </summary>
        public int Balance { get; set; } = 0;
    }
}