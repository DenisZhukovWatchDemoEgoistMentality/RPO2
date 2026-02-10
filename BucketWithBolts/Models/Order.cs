namespace BucketWithBolts.Models
{
    /// <summary>
    /// Модель таблица Orders
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        /// <summary>
        /// ID продавца
        /// </summary>
        public int Vendor_id { get; set; }
        /// <summary>
        /// ID продаваемого ресурса
        /// </summary>
        public int Resourse_id { get; set; }
        /// <summary>
        /// ID покупателя
        /// </summary>
        public int Customer_id { get; set; }
        /// <summary>
        /// Статус заказа
        /// </summary>
        public int Status { get; set; } = 1;
    }
}