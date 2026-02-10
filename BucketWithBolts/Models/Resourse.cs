namespace BucketWithBolts.Models
{
    /// <summary>
    /// Модель таблицы Resourses
    /// </summary>
    public class Resourse
    {
        public int Id { get; set; }
        /// <summary>
        /// ID владельца ресурса
        /// </summary>
        public int Owner_id { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Описание (необязательное)
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Цена
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public int Status { get; set; } = 1;
    }
}