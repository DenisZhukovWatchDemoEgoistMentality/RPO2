using BucketWithBolts.Context;
using BucketWithBolts.Controller.Interfaces;
using BucketWithBolts.Controller.Tools;
using BucketWithBolts.Models;
using BucketWithBolts.Services;

namespace BucketWithBolts.Controller.Routers
{
    /// <summary>
    /// Роутер таблицы Resourse
    /// </summary>
    public class ResourceRouter : IRouter<Resource>
    {
        /// <summary>
        /// Ссылка на бд
        /// </summary>
        private DatabaseContext _db;


        public ResourceRouter(DatabaseContext db)
        {
            _db = db;
        }


        public bool Post(Resource newItem)
        {
            if (_db == null)
            {
                InfoMessager.CreateErrorMessage("БД не найдена или нет подключения к ней", $"{this.GetType().Name}.Post");
                return false;
            }

            if (FindHelper.GetUser(_db, newItem.Owner_id) == null)
            {
                InfoMessager.CreateErrorMessage("Юзера не существует", $"{this.GetType().Name}.Post");
                return false;
            }
            if (newItem.Name == null || newItem.Name == "")
            {
                InfoMessager.CreateErrorMessage("Название заказа отсутствует", $"{this.GetType().Name}.Post");
                return false;
            }
            if (newItem.Condition <= 0)
            {
                InfoMessager.CreateErrorMessage("Отсутствует описание", $"{this.GetType().Name}.Post");
                return false;
            }
            if (newItem.Price < 0)
            {
                InfoMessager.CreateErrorMessage("Ценая не может быть меньше нуля", $"{this.GetType().Name}.Post");
                return false;
            }

            newItem.Status = 1;

            _db.Resources.Add(newItem);
            _db.SaveChanges();

            InfoMessager.CreateSuccessMessage("Добавление в базу данных произошло успешно", $"{this.GetType().Name}.Post");
            return true;
        }

        public Resource? GetToId(int itemId)
        {
            if (_db == null)
            {
                InfoMessager.CreateErrorMessage("БД не найдена или нет подключения к ней", $"{this.GetType().Name}.GetToId");
                return null;
            }

            var resource = _db.Resources.FirstOrDefault(i => i.Id == itemId);

            if (resource == null)
            {
                InfoMessager.CreateErrorMessage("Данные по этому Id не найдены", $"{this.GetType().Name}.GetToId");
                return null;
            }

            InfoMessager.CreateSuccessMessage($"Данные найдены", $"{this.GetType().Name}.GetToId");
            return resource;
        }

        public List<Resource>? GetAll()
        {
            if (_db == null)
            {
                InfoMessager.CreateErrorMessage("БД не найдена или нет подключения к ней", $"{this.GetType().Name}.GetAll");
                return null;
            }

            var resources = _db.Resources.ToList();

            if (resources == null)
            {
                InfoMessager.CreateErrorMessage("Данные не найдены", $"{this.GetType().Name}.GetAll");
                return null;
            }

            InfoMessager.CreateSuccessMessage($"Данные найдены", $"{this.GetType().Name}.GetAll");
            return resources;
        }

        public bool Delete(int itemId)
        {
            if (_db == null)
            {
                InfoMessager.CreateErrorMessage("БД не найдена или нет подключения к ней", $"{this.GetType().Name}.Delete");
                return false;
            }

            var resource = _db.Resources.FirstOrDefault(i => i.Id == itemId);

            if (resource == null)
            {
                InfoMessager.CreateErrorMessage("Данные по этому Id не найдены", $"{this.GetType().Name}.Delete");
                return false;
            }

            _db.Resources.Remove(resource);
            _db.SaveChanges();

            InfoMessager.CreateSuccessMessage("Данные удалены", $"{this.GetType().Name}.Delete");
            return true;
        }
    }
}