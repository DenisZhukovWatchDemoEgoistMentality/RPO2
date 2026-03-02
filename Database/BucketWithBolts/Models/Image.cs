using System.ComponentModel.DataAnnotations;

namespace BucketWithBolts.Models
{
    /// <summary>
    /// Модель таблицы Images
    /// </summary>
    public class Image
    {
        public int Id { get; set; }
        /// <summary>
        /// Полный путь к картинке
        /// </summary>
        [MaxLength(255)]
        public string Image_src { get; set; }
    }
}