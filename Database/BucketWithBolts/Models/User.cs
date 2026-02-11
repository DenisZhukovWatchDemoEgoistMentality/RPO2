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
        public string Login { get; set; }
        /// <summary>
        /// Почта
        /// </summary>
        public string Mail { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Баланс
        /// </summary>
        public int Balance { get; set; } = 0;
    }
}