using BucketWithBolts.Context;
using BucketWithBolts.Controller.Interfaces;
using BucketWithBolts.Controller.Tools;
using BucketWithBolts.Models;

namespace BucketWithBolts.Controller.Routers
{
    /// <summary>
    /// Роутер таблицы Orders
    /// </summary>
    public class OrderRouter : IRouter<Order>
    {
        /// <summary>
        /// Ссылка на бд
        /// </summary>
        private DatabaseContext _db;


        public OrderRouter(DatabaseContext db)
        {
            _db = db;
        }


        public bool Post(Order newItem)
        {
            if (_db == null)
                return false;

            if (FindHelper.GetResource(_db, newItem.Resource_id) == null) 
                return false;
            if (FindHelper.GetUser(_db, newItem.Customer_id) == null)
                return false;

            newItem.Status = 1;

            _db.Orders.Add(newItem);
            _db.SaveChanges();
            return true;
        }

        public Order GetToId(int itemId)
        {
            if (_db == null)
                return null;

            var order = _db.Orders.FirstOrDefault(i => i.Id == itemId);

            if (order == null)
                return null;

            return order;
        } 

        public List<Order> GetAll()
        {
            if (_db == null)
                return null;

            var orders = _db.Orders.ToList();

            if (orders == null)
                return null;

            return orders;
        }

        public bool Delete(int itemId)
        {
            if (_db == null)
                return false;

            var order = _db.Orders.FirstOrDefault(i => i.Id == itemId);

            if (order == null)
                return false;

            _db.Orders.Remove(order);
            _db.SaveChanges();

            return true;
        }
    }
}