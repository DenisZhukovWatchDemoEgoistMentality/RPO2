using BucketWithBolts.Context;
using BucketWithBolts.Controller.Interfaces;
using BucketWithBolts.Controller.Tools;
using BucketWithBolts.Models;

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
            if (_db == null)
                return false;

            if (FindHelper.GetOrder(_db, newItem.Order_id) == null)
                return false;
            if (newItem.Stars <= 0)
                return false;

            _db.Feedbacks.Add(newItem);
            _db.SaveChanges();
            return true;
        }

        public Feedback GetToId(int itemId)
        {
            if (_db == null)
                return null;

            var feedback = _db.Feedbacks.FirstOrDefault(i => i.Id == itemId);

            if (feedback == null)
                return null;

            return feedback;
        }

        public List<Feedback> GetAll()
        {
            if (_db == null)
                return null;

            var feedbacks = _db.Feedbacks.ToList();

            if (feedbacks == null)
                return null;

            return feedbacks;
        }

        public bool Delete(int itemId)
        {
            if (_db == null)
                return false;

            var feedback = _db.Feedbacks.FirstOrDefault(i => i.Id == itemId);

            if (feedback == null)
                return false;

            _db.Feedbacks.Remove(feedback);
            _db.SaveChanges();

            return true;
        }
    }
}