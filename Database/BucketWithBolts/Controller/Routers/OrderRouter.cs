using BucketWithBolts.Context;
using BucketWithBolts.Controller.Interfaces;
using BucketWithBolts.Controller.Tools;
using BucketWithBolts.Models;
using BucketWithBolts.Services;

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
            if (_db == null) {
                InfoMessager.CreateErrorMessage("БД не найдена или к ней не подлючено", $"{this.GetType().Name}.Post");
                return false;
            }

            if (FindHelper.GetResource(_db, newItem.Resource_id) == null) {
                InfoMessager.CreateErrorMessage("Ресурса с таким Id не существует", $"{this.GetType().Name}.Post");
                return false;
            }
            if (FindHelper.GetUser(_db, newItem.Customer_id) == null) {
                InfoMessager.CreateErrorMessage("Пользователя с таким Id не существует", $"{this.GetType().Name}.Post");
                return false;
            }
            if (newItem.Quantity <= 0) {
                InfoMessager.CreateErrorMessage("Кол-во не может быть меньше 1", $"{this.GetType().Name}.Post");
                return false;
            }

            newItem.Status = 1;

            _db.Orders.Add(newItem);
            _db.SaveChanges();

            InfoMessager.CreateSuccessMessage("Добавление в базу данных произошло успешно", $"{this.GetType().Name}.Post");
            return true;
        }

        public Order? GetToId(int itemId)
        {
            if (_db == null) {
                InfoMessager.CreateErrorMessage("БД не найдена или к ней не подлючено", $"{this.GetType().Name}.GetToId");
                return null;
            }

            var order = _db.Orders.FirstOrDefault(i => i.Id == itemId);

            if (order == null) {
                InfoMessager.CreateErrorMessage("Данные по этому Id не найдено", $"{this.GetType().Name}.GetToId");
                return null;
            }

            InfoMessager.CreateSuccessMessage($"Данные найдены", $"{this.GetType().Name}.GetToId");
            return order;
        } 

        public List<Order>? GetAll()
        {
            if (_db == null) {
                InfoMessager.CreateErrorMessage("БД не найдена или к ней не подлючено", $"{this.GetType().Name}.GetAll");
                return null;
            }

            var orders = _db.Orders.ToList();

            if (orders == null) {
                InfoMessager.CreateErrorMessage("Данные не найдены", $"{this.GetType().Name}.GetAll");
                return null;
            }

            InfoMessager.CreateSuccessMessage($"Данные найдены", $"{this.GetType().Name}.GetAll");
            return orders;
        }

        public bool Delete(int itemId)
        {
            if (_db == null) {
                InfoMessager.CreateErrorMessage("БД не найдена или к ней не подлючено", $"{this.GetType().Name}.Delete");
                return false;
            }

            var order = _db.Orders.FirstOrDefault(i => i.Id == itemId);

            if (order == null) {
                InfoMessager.CreateErrorMessage("Данные по этому Id не найдены", $"{this.GetType().Name}.Delete");
                return false;
            }

            _db.Orders.Remove(order);
            _db.SaveChanges();

            InfoMessager.CreateSuccessMessage("Данные удалены", $"{this.GetType().Name}.Delete");
            return true;
        }
    }
}