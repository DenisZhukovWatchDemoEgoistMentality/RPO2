using System.ComponentModel.DataAnnotations.Schema;

namespace BucketWithBolts.Models
{
    /// <summary>
    /// Модель таблица Orders
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        /// <summary>
        /// ID продаваемого ресурса
        /// </summary>
        public int Resource_id { get; set; }
        /// <summary>
        /// ID покупателя
        /// </summary>
        public int Customer_id { get; set; }
        /// <summary>
        /// Количество товара
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Статус заказа
        /// </summary>
        public int Status { get; set; } = 1;


        #region - Внешние ключи -
        [ForeignKey(nameof(Resource_id))]
        public Resource Resource { get; set; }
        [ForeignKey(nameof(Customer_id))]
        public User Customer { get; set; }
        [ForeignKey(nameof(Status))]
        public OrderStatus Status_id { get; set; }
        #endregion
    }
}