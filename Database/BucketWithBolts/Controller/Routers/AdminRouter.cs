using BucketWithBolts.Context;
using BucketWithBolts.Controller.Interfaces;
using BucketWithBolts.Models;
using BucketWithBolts.Services;

namespace BucketWithBolts.Controller.Routers
{
    /// <summary>
    /// Роутер таблицы Admins
    /// </summary>
    public class AdminRouter : IRouter<Admin>
    {
        /// <summary>
        /// Ссылка на бд
        /// </summary>
        private DatabaseContext _db;


        public AdminRouter(DatabaseContext db)
        {
            _db = db;
        }


        public bool Post(Admin newItem)
        {
            if (_db == null)
            {
                InfoMessager.CreateErrorMessage("", $"{this.GetType().Name}");
                return false;
            }

            if (newItem.Login == null)
                return false;
            if (newItem.Password == null)
                return false;

            if (_db.Admins.Any(i => i.Login == newItem.Login))
                return false;

            _db.Admins.Add(newItem);
            _db.SaveChanges();

            return true;
        }

        public Admin GetToId(int itemId)
        {
            if (_db == null)
                return null;

            var admin = _db.Admins.FirstOrDefault(i => i.Id == itemId);

            if (admin == null)
                return null;

            return admin;
        }

        public List<Admin> GetAll()
        {
            if (_db == null)
                return null;

            var admins = _db.Admins.ToList();

            if (admins == null)
                return null;

            return admins;
        }

        public bool Delete(int itemId)
        {
            if (_db == null)
                return false;

            var admin = _db.Admins.FirstOrDefault(i => i.Id == itemId);

            if (admin == null)
                return false;

            _db.Admins.Remove(admin);
            _db.SaveChanges();

            return true;
        }
    }
}