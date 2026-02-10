using BucketWithBolts.Context;
using BucketWithBolts.Controller.Interfaces;
using BucketWithBolts.Models;

namespace BucketWithBolts.Controller.Routers
{
    /// <summary>
    /// Роутер таблицы Users
    /// </summary>
    public class UserRouter : IRouter<User>
    {
        /// <summary>
        /// Ссылка на бд
        /// </summary>
        private DatabaseContext _db;


        public UserRouter(DatabaseContext db)
        {
            _db = db;
        }


        public bool Post(User newItem)
        {
            if (_db == null)
                return false;

            if (newItem.First_name == null)
                return false;

            if (_db.Users.Any(i => i.First_name == newItem.First_name))
                return false;

            _db.Users.Add(newItem);
            _db.SaveChanges();

            return true;
        }

        public User GetToId(int itemId)
        {
            if (_db == null)
                return null;

            var user = _db.Users.FirstOrDefault(i => i.Id == itemId);

            if (user == null)
                return null;

            return user;
        }

        public List<User> GetAll()
        {
            if (_db == null)
                return null;

            var users = _db.Users.ToList();

            if (users == null)
                return null;

            return users;
        }

        public bool Delete(int itemId)
        {
            if (_db == null)
                return false;

            var user = _db.Users.FirstOrDefault(i => i.Id == itemId);

            if (user == null)
                return false;

            _db.Users.Remove(user);
            _db.SaveChanges();

            return true;
        }
    }
}