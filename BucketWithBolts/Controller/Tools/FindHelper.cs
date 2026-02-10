using BucketWithBolts.Context;
using BucketWithBolts.Models;

namespace BucketWithBolts.Controller.Tools
{
    /// <summary>
    /// Помощник для поиска предметов в таблицах
    /// </summary>
    public static class FindHelper
    {
        /// <summary>
        /// Получение пользователя из Users
        /// </summary>
        /// <param name="db">Ссылка на бд</param>
        /// <param name="id">ID пользователя</param>
        /// <returns>Пользователь, при условии что он существует</returns>
        public static User GetUser(DatabaseContext db, int id)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
                return null;

            return user;
        }

        /// <summary>
        /// Получение ресурса из Users
        /// </summary>
        /// <param name="db">Ссылка на бд</param>
        /// <param name="id">ID ресурса</param>
        /// <returns>Ресурс, при условии что он существует</returns>
        public static Resourse GetResourse(DatabaseContext db, int id)
        {
            var resourse = db.Resourses.FirstOrDefault(u => u.Id == id);

            if (resourse == null)
                return null;

            return resourse;
        }

        /// <summary>
        /// Получение заказа из Users
        /// </summary>
        /// <param name="db">Ссылка на бд</param>
        /// <param name="id">ID заказа</param>
        /// <returns>Заказ, при условии что он существует</returns>
        public static Order GetOrder(DatabaseContext db, int id)
        {
            var order = db.Orders.FirstOrDefault(u => u.Id == id);

            if (order == null)
                return null;

            return order;
        }
    }
}