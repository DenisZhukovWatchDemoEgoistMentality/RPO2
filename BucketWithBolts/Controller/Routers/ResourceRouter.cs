using BucketWithBolts.Context;
using BucketWithBolts.Controller.Interfaces;
using BucketWithBolts.Controller.Tools;
using BucketWithBolts.Models;

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
                return false;

            if (FindHelper.GetUser(_db, newItem.Owner_id) == null)
                return false;
            if (newItem.Name == null || newItem.Name == "")
                return false;
            if (newItem.Price <= 0)
                return false;

            newItem.Status = 1;

            _db.Resources.Add(newItem);
            _db.SaveChanges();
            return true;
        }

        public Resource GetToId(int itemId)
        {
            if (_db == null)
                return null;

            var resource = _db.Resources.FirstOrDefault(i => i.Id == itemId);

            if (resource == null)
                return null;

            return resource;
        }

        public List<Resource> GetAll()
        {
            if (_db == null)
                return null;

            var resources = _db.Resources.ToList();

            if (resources == null)
                return null;

            return resources;
        }

        public bool Delete(int itemId)
        {
            if (_db == null)
                return false;

            var resource = _db.Resources.FirstOrDefault(i => i.Id == itemId);

            if (resource == null)
                return false;

            _db.Resources.Remove(resource);
            _db.SaveChanges();

            return true;
        }
    }
}