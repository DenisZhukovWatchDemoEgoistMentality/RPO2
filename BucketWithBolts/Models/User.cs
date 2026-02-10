namespace BucketWithBolts.Models
{
    /// <summary>
    /// Модель таблицы Users
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string First_name { get; set; }
        /// <summary>
        /// Фамилия (необязательное)
        /// </summary>
        public string? Second_name { get; set; }
    }
}