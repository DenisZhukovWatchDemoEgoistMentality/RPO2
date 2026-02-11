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
        public string Login { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }
    }
}