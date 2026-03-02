using System.ComponentModel.DataAnnotations.Schema;

namespace BucketWithBolts.Models
{
    /// <summary>
    /// Модель таблицы Recource_Images
    /// </summary>
    public class Resource_Image
    {
        public int Id { get; set; }
        /// <summary>
        /// ID ресурса
        /// </summary>
        public int Resource_id { get; set; }
        /// <summary>
        /// ID изображения ресурса
        /// </summary>
        public int Image_scr_id { get; set; }


        #region - Внешние ключи -
        [ForeignKey(nameof(Resource_id))]
        public Resource Resource { get; set; }
        [ForeignKey(nameof(Image_scr_id))]
        public Image Image_scr { get; set; }
        #endregion
    }
}