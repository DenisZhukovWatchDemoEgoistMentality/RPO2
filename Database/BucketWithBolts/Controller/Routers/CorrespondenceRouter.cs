using BucketWithBolts.Context;
using BucketWithBolts.Controller.Interfaces;
using BucketWithBolts.Controller.Tools;
using BucketWithBolts.Models;
using BucketWithBolts.Services;

namespace BucketWithBolts.Controller.Routers
{
    /// <summary>
    /// Роутер таблицы Correspondences
    /// </summary>
    public class CorrespondenceRouter : IRouter<Correspondence>
    {
        /// <summary>
        /// Ссылка на бд
        /// </summary>
        private DatabaseContext _db;


        public CorrespondenceRouter(DatabaseContext db)
        {
            _db = db;
        }


        public bool Post(Correspondence newItem)
        {
            if (_db == null)
            {
                InfoMessager.CreateErrorMessage("БД не найдена или нет подключения к ней", $"{this.GetType().Name}.Post");
                return false;
            }

            if (FindHelper.GetUser(_db, newItem.Recipient_Id) == null || FindHelper.GetUser(_db, newItem.Sender_Id) == null)
            {
                InfoMessager.CreateErrorMessage("ID получателя пустой", $"{this.GetType().Name}.Post");
                return false;
            }
            if (FindHelper.GetUser(_db, newItem.Sender_Id) == null || FindHelper.GetUser(_db, newItem.Sender_Id) == null)
            {
                InfoMessager.CreateErrorMessage("ID отправителя пустой", $"{this.GetType().Name}.Post");
                return false;
            }

            _db.Correspondences.Add(newItem);
            _db.SaveChanges();

            InfoMessager.CreateSuccessMessage("Добавление в базу данных произошло успешно", $"{this.GetType().Name}.Post");
            return true;
        }

        public Correspondence? GetToId(int itemId)
        {
            if (_db == null)
            {
                InfoMessager.CreateErrorMessage("БД не найдена или нет подключения к ней", $"{this.GetType().Name}.GetToId");
                return null;
            }

            var correspondence = _db.Correspondences.FirstOrDefault(i => i.Id == itemId);

            if (correspondence == null)
            {
                InfoMessager.CreateErrorMessage("Данные по этому Id не найдены", $"{this.GetType().Name}.GetToId");
                return null;
            }

            InfoMessager.CreateSuccessMessage($"Данные найдены", $"{this.GetType().Name}.GetToId");
            return correspondence;
        }

        public List<Correspondence>? GetAll()
        {
            if (_db == null)
            {
                InfoMessager.CreateErrorMessage("БД не найдена или нет подключения к ней", $"{this.GetType().Name}.GetAll");
                return null;
            }

            var correspondence = _db.Correspondences.ToList();

            if (correspondence == null)
            {
                InfoMessager.CreateErrorMessage("Данные не найдены", $"{this.GetType().Name}.GetAll");
                return null;
            }

            InfoMessager.CreateSuccessMessage($"Данные найдены", $"{this.GetType().Name}.GetAll");
            return correspondence;
        }

        public bool Delete(int itemId)
        {
            if (_db == null)
            {
                InfoMessager.CreateErrorMessage("БД не найдена или нет подключения к ней", $"{this.GetType().Name}.Delete");
                return false;
            }

            var correspondence = _db.Correspondences.FirstOrDefault(i => i.Id == itemId);

            if (correspondence == null)
            {
                InfoMessager.CreateErrorMessage("Данные по этому Id не найдены", $"{this.GetType().Name}.Delete");
                return false;
            }

            _db.Correspondences.Remove(correspondence);
            _db.SaveChanges();

            InfoMessager.CreateSuccessMessage("Данные удалены", $"{this.GetType().Name}.Delete");
            return true;
        }
    }
}