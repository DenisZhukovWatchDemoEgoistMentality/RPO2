using BucketWithBolts.Context;
using BucketWithBolts.Controller.Interfaces;
using BucketWithBolts.Controller.Tools;
using BucketWithBolts.Models;
using BucketWithBolts.Services;

namespace BucketWithBolts.Controller.Routers
{
    /// <summary>
    /// Роутер таблицы Feedbacks
    /// </summary>
    public class FeedbackRouter : IRouter<Feedback>
    {
        /// <summary>
        /// Ссылка на бд
        /// </summary>
        private DatabaseContext _db;


        public FeedbackRouter(DatabaseContext db)
        {
            _db = db;
        }


        public bool Post(Feedback newItem)
        {
            if (_db == null){
                InfoMessager.CreateErrorMessage("БД не найдена или нет подключения к ней", $"{this.GetType().Name}.Post");
                return false;
            }

            if (FindHelper.GetOrder(_db, newItem.Order_id) == null){
                InfoMessager.CreateErrorMessage("ID заказа пустой", $"{this.GetType().Name}.Post");
                return false;
            }
            if (newItem.Stars <= 0){
                InfoMessager.CreateErrorMessage("Оценка не может быть меньше 1", $"{this.GetType().Name}.Post");
                return false;
            }

            _db.Feedbacks.Add(newItem);
            _db.SaveChanges();

            InfoMessager.CreateSuccessMessage("Добавление в базу данных произошло успешно", $"{this.GetType().Name}.Post");
            return true;
        }

        public Feedback? GetToId(int itemId)
        {
            if (_db == null){
                InfoMessager.CreateErrorMessage("БД не найдена или нет подключения к ней", $"{this.GetType().Name}.GetToId");
                return null;
            }

            var feedback = _db.Feedbacks.FirstOrDefault(i => i.Id == itemId);

            if (feedback == null)
            {
                InfoMessager.CreateErrorMessage("Данные по этому Id не найдены", $"{this.GetType().Name}.GetToId");
                return null;
            }

            InfoMessager.CreateSuccessMessage($"Данные найдены", $"{this.GetType().Name}.GetToId");
            return feedback;
        }

        public List<Feedback>? GetAll()
        {
            if (_db == null)
            {
                InfoMessager.CreateErrorMessage("БД не найдена или нет подключения к ней", $"{this.GetType().Name}.GetAll");
                return null;
            }

            var feedbacks = _db.Feedbacks.ToList();

            if (feedbacks == null)
            {
                InfoMessager.CreateErrorMessage("Данные не найдены", $"{this.GetType().Name}.GetAll");
                return null;
            }

            InfoMessager.CreateSuccessMessage($"Данные найдены", $"{this.GetType().Name}.GetAll");
            return feedbacks;
        }

        public bool Delete(int itemId)
        {
            if (_db == null)
            {
                InfoMessager.CreateErrorMessage("БД не найдена или нет подключения к ней", $"{this.GetType().Name}.Delete");
                return false;
            }

            var feedback = _db.Feedbacks.FirstOrDefault(i => i.Id == itemId);

            if (feedback == null)
            {
                InfoMessager.CreateErrorMessage("Данные по этому Id не найдены", $"{this.GetType().Name}.Delete");
                return false;
            }

            _db.Feedbacks.Remove(feedback);
            _db.SaveChanges();

            InfoMessager.CreateSuccessMessage("Данные удалены", $"{this.GetType().Name}.Delete");
            return true;
        }
    }
}