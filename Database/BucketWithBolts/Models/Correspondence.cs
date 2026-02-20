using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BucketWithBolts.Models
{
    /// <summary>
    /// Модель таблицы Correspondences
    /// </summary>
    public class Correspondence
    {
        public int Id { get; set; }
        /// <summary>
        /// Получатель сообщения
        /// </summary>
        public int Recipient_Id { get; set; }
        /// <summary>
        /// Отправитель сообщения
        /// </summary>
        public int Sender_Id { get; set; }
        /// <summary>
        /// Сообщение
        /// </summary>
        [MaxLength(255)]
        public string Message { get; set; }
        /// <summary>
        /// время отправки
        /// </summary>
        public DateTime DateTime { get; set; } = DateTime.UtcNow;


        #region - Внешние ключи -
        [ForeignKey(nameof(Recipient_Id))]
        public User Recipient { get; set; }
        [ForeignKey(nameof(Sender_Id))]
        public User Sender { get; set; }
        #endregion
    }
}
