using BucketWithBolts.Context;
using BucketWithBolts.Controller.Interfaces;
using BucketWithBolts.Controller.Tools;
using BucketWithBolts.Models;
using BucketWithBolts.Services;

namespace BucketWithBolts.Controller.Routers
{
    /// <summary>
    /// Роутер таблицы Resource_Images
    /// </summary>
    public class ResourceImageRouter : IRouter<Resource_Image>
    {
        /// <summary>
        /// Ссылка на бд
        /// </summary>
        private DatabaseContext _db;


        public ResourceImageRouter(DatabaseContext db)
        {
            _db = db;
        }


        public bool Post(Resource_Image newItem)
        {
            if (_db == null)
            {
                InfoMessager.CreateErrorMessage("БД не найдена или нет подключения к ней", $"{this.GetType().Name}.Post");
                return false;
            }

            if (FindHelper.GetResource(_db, newItem.Resource_id) == null)
            {
                InfoMessager.CreateErrorMessage("Ресурса не существует", $"{this.GetType().Name}.Post");
                return false;
            }
            if (FindHelper.GetImage(_db, newItem.Image_scr_id) == null)
            {
                InfoMessager.CreateErrorMessage("Изображения не существует", $"{this.GetType().Name}.Post");
                return false;
            }

            _db.Resource_Images.Add(newItem);
            _db.SaveChanges();

            InfoMessager.CreateSuccessMessage("Добавление в базу данных произошло успешно", $"{this.GetType().Name}.Post");
            return true;
        }

        public Resource_Image? GetToId(int itemId)
        {
            if (_db == null)
            {
                InfoMessager.CreateErrorMessage("БД не найдена или нет подключения к ней", $"{this.GetType().Name}.GetToId");
                return null;
            }

            var resource_image = _db.Resource_Images.FirstOrDefault(i => i.Id == itemId);

            if (resource_image == null)
            {
                InfoMessager.CreateErrorMessage("Данные по этому Id не найдены", $"{this.GetType().Name}.GetToId");
                return null;
            }

            InfoMessager.CreateSuccessMessage($"Данные найдены", $"{this.GetType().Name}.GetToId");
            return resource_image;
        }

        public List<Resource_Image>? GetAll()
        {
            if (_db == null)
            {
                InfoMessager.CreateErrorMessage("БД не найдена или нет подключения к ней", $"{this.GetType().Name}.GetAll");
                return null;
            }

            var resource_images = _db.Resource_Images.ToList();

            if (resource_images == null)
            {
                InfoMessager.CreateErrorMessage("Данные не найдены", $"{this.GetType().Name}.GetAll");
                return null;
            }

            InfoMessager.CreateSuccessMessage($"Данные найдены", $"{this.GetType().Name}.GetAll");
            return resource_images;
        }

        public bool Delete(int itemId)
        {
            if (_db == null)
            {
                InfoMessager.CreateErrorMessage("БД не найдена или нет подключения к ней", $"{this.GetType().Name}.Delete");
                return false;
            }

            var resource_image = _db.Resource_Images.FirstOrDefault(i => i.Id == itemId);

            if (resource_image == null)
            {
                InfoMessager.CreateErrorMessage("Данные по этому Id не найдены", $"{this.GetType().Name}.Delete");
                return false;
            }

            _db.Resource_Images.Remove(resource_image);
            _db.SaveChanges();

            InfoMessager.CreateSuccessMessage("Данные удалены", $"{this.GetType().Name}.Delete");
            return true;
        }
    }
}