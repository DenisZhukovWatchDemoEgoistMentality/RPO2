using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BucketWithBolts.Models
{
    /// <summary>
    /// Модель таблицы Resourses
    /// </summary>
    public class Resource
    {
        public int Id { get; set; }
        /// <summary>
        /// ID владельца ресурса
        /// </summary>
        public int Owner_id { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Image { get; set; }
        /// <summary>
        /// Описание (необязательное)
        /// </summary>
        [MaxLength(255)]
        public string? Description { get; set; }
        /// <summary>
        /// Цена
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// Состояние товара
        /// </summary>
        public int Condition { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public int Status { get; set; } = 1;


        #region - Внешние ключи -
        [ForeignKey(nameof(Owner_id))]
        public User Owner { get; set; }
        [ForeignKey(nameof(Condition))]
        public Condition Condition_id { get; set; }
        [ForeignKey(nameof(Status))]
        public ResourceStatus Status_id { get; set; }
        #endregion
    }
}