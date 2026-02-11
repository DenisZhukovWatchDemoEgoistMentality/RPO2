using System.ComponentModel.DataAnnotations.Schema;

namespace BucketWithBolts.Models
{
    /// <summary>
    /// Модель таблицы Feedback
    /// </summary>
    public class Feedbacks
    {
        public int Id { get; set; }
        /// <summary>
        /// Заказ
        /// </summary>
        public int Order_id { get; set; }
        /// <summary>
        /// Оценка
        /// </summary>
        public int Stars { get; set; }
        /// <summary>
        /// Текст отзыва (необязательное)
        /// </summary>
        public string? Description { get; set; }

        #region - Внешние ключи -
        [ForeignKey(nameof(Order_id))]
        public Order Order { get; set; }
        #endregion
    }
}