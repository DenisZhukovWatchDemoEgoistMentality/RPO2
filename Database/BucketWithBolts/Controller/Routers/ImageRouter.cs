using BucketWithBolts.Context;
using BucketWithBolts.Controller.Interfaces;
using BucketWithBolts.Models;
using BucketWithBolts.Services;

namespace BucketWithBolts.Controller.Routers
{
    /// <summary>
    /// Роутер таблицы Images
    /// </summary>
    public class ImageRouter : IRouter<Image>
    {
        /// <summary>
        /// Ссылка на бд
        /// </summary>
        private DatabaseContext _db;


        public ImageRouter(DatabaseContext db)
        {
            _db = db;
        }


        public bool Post(Image newItem)
        {
            if (_db == null)
            {
                InfoMessager.CreateErrorMessage("БД не найдена или нет подключения к ней", $"{this.GetType().Name}.Post");
                return false;
            }

            if (newItem == null || newItem.Image_src == null || newItem.Image_src == "")
            {
                InfoMessager.CreateErrorMessage("Ссылка на картинку отсутствует", $"{this.GetType().Name}.Post");
                return false;
            }

            _db.Images.Add(newItem);
            _db.SaveChanges();

            return true;
        }

        public Image GetToId(int itemId)
        {
            if (_db == null)
            {
                InfoMessager.CreateErrorMessage("БД не найдена или нет подключения к ней", $"{this.GetType().Name}.GetToId");
                return null;
            }

            var image = _db.Images.FirstOrDefault(i => i.Id == itemId);

            if (image == null)
            {
                InfoMessager.CreateErrorMessage("404 Данные не найдены", $"{this.GetType().Name}.GetToId");
                return null;
            }

            InfoMessager.CreateSuccessMessage($"Данные найдены", $"{this.GetType().Name}.GetToId");
            return image;
        }

        public List<Image> GetAll()
        {
            if (_db == null)
            {
                InfoMessager.CreateErrorMessage("БД не найдена или нет подключения к ней", $"{this.GetType().Name}.GetAll");
                return null;
            }

            var images = _db.Images.ToList();

            if (images == null)
            {
                InfoMessager.CreateErrorMessage("Данные не найдены", $"{this.GetType().Name}.GetAll");
                return null;
            }

            InfoMessager.CreateSuccessMessage($"Данные найдены", $"{this.GetType().Name}.GetAll");
            return images;
        }

        public bool Delete(int itemId)
        {
            if (_db == null)
            {
                InfoMessager.CreateErrorMessage("БД не найдена или нет подключения к ней", $"{this.GetType().Name}.Delete");
                return false;
            }

            var image = _db.Images.FirstOrDefault(i => i.Id == itemId);

            if (image == null)
            {
                InfoMessager.CreateErrorMessage("Ресурсы не найдены", $"{this.GetType().Name}.Delete");
                return false;
            }

            _db.Images.Remove(image);
            _db.SaveChanges();

            InfoMessager.CreateSuccessMessage("Данные удалены", $"{this.GetType().Name}.Delete");
            return true;
        }
    }
}