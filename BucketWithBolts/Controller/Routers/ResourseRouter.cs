using BucketWithBolts.Context;
using BucketWithBolts.Controller.Interfaces;
using BucketWithBolts.Controller.Tools;
using BucketWithBolts.Models;

namespace BucketWithBolts.Controller.Routers
{
    /// <summary>
    /// Роутер таблицы Resourse
    /// </summary>
    public class ResourseRouter : IRouter<Resourse>
    {
        /// <summary>
        /// Ссылка на бд
        /// </summary>
        private DatabaseContext _db;


        public ResourseRouter(DatabaseContext db)
        {
            _db = db;
        }


        public bool Post(Resourse newItem)
        {
            if (_db == null)
                return false;

            if (FindHelper.GetUser(_db, newItem.Owner_id) == null)
                return false;
            if (newItem.Name == null || newItem.Name == "")
                return false;
            if (newItem.Price <= 0)
                return false;

            newItem.Status = 1;

            _db.Resourses.Add(newItem);
            _db.SaveChanges();
            return true;
        }

        public Resourse GetToId(int itemId)
        {
            if (_db == null)
                return null;

            var resourse = _db.Resourses.FirstOrDefault(i => i.Id == itemId);

            if (resourse == null)
                return null;

            return resourse;
        }

        public List<Resourse> GetAll()
        {
            if (_db == null)
                return null;

            var resourses = _db.Resourses.ToList();

            if (resourses == null)
                return null;

            return resourses;
        }

        public bool Delete(int itemId)
        {
            if (_db == null)
                return false;

            var resourse = _db.Resourses.FirstOrDefault(i => i.Id == itemId);

            if (resourse == null)
                return false;

            _db.Resourses.Remove(resourse);
            _db.SaveChanges();

            return true;
        }
    }
}