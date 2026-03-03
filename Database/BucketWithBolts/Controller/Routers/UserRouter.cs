using BucketWithBolts.Context;
using BucketWithBolts.Controller.Interfaces;
using BucketWithBolts.Models;
using BucketWithBolts.Services;

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
            {
                InfoMessager.CreateErrorMessage("БД не найдена или нет подключения к ней", $"{this.GetType().Name}.Post");
                return false;
            }

            if (newItem.Login == null || newItem.Login == ""){
                InfoMessager.CreateErrorMessage("Логин пустой", $"{this.GetType().Name}.Post");
                return false;
            }
            if (newItem.Mail == null || newItem.Mail == ""){
                InfoMessager.CreateErrorMessage("Почта пустая", $"{this.GetType().Name}.Post");
                return false;
            }
            if (newItem.Password == null || newItem.Password == "")
            {
                InfoMessager.CreateErrorMessage("Пароль пустой", $"{this.GetType().Name}.Post");
                return false;
            }
            if (newItem.Balance < 0)
            {
                InfoMessager.CreateErrorMessage("Баланс не может быть отрицательным", $"{this.GetType().Name}.Post");
                return false;
            }

            if (_db.Users.Any(i => i.Login == newItem.Login))
            {
                InfoMessager.CreateErrorMessage("Такой логин уже существует", $"{this.GetType().Name}.Post");
                return false;
            }
            if (_db.Users.Any(i => i.Mail == newItem.Mail))
            {
                InfoMessager.CreateErrorMessage("Такая почту уже существует.", $"{this.GetType().Name}.Post");
                return false;
            }

            _db.Users.Add(newItem);
            _db.SaveChanges();

            InfoMessager.CreateSuccessMessage("Добавление в базу данных произошло успешно", $"{this.GetType().Name}.Post");
            return true;
        }

        public User? GetToId(int itemId)
        {
            if (_db == null)
            {
                InfoMessager.CreateErrorMessage("БД не найдена или нет подключения к ней", $"{this.GetType().Name}.GetToId");
                return null;
            }

            var user = _db.Users.FirstOrDefault(i => i.Id == itemId);

            if (user == null)
            {
                InfoMessager.CreateErrorMessage("Данные по этому Id не найдены", $"{this.GetType().Name}.GetToId");
                return null;
            }

            InfoMessager.CreateSuccessMessage($"Данные найдены", $"{this.GetType().Name}.GetToId");
            return user;
        }

        public List<User>? GetAll()
        {
            if (_db == null)
            {
                InfoMessager.CreateErrorMessage("БД не найдена или нет подключения к ней", $"{this.GetType().Name}.GetAll");
                return null;
            }

            var users = _db.Users.ToList();

            if (users == null)
            {
                InfoMessager.CreateErrorMessage("Данные не найдены", $"{this.GetType().Name}.GetAll");
                return null;
            }

            InfoMessager.CreateSuccessMessage($"Данные найдены", $"{this.GetType().Name}.GetAll");
            return users;
        }

        public bool Delete(int itemId)
        {
            if (_db == null)
            {
                InfoMessager.CreateErrorMessage("БД не найдена или нет подключения к ней", $"{this.GetType().Name}.Delete");
                return false;
            }

            var user = _db.Users.FirstOrDefault(i => i.Id == itemId);

            if (user == null)
            {
                InfoMessager.CreateErrorMessage("Данные по этому Id не найдены", $"{this.GetType().Name}.Delete");
                return false;
            }

            _db.Users.Remove(user);
            _db.SaveChanges();

            InfoMessager.CreateSuccessMessage("Данные удалены", $"{this.GetType().Name}.Delete");
            return true;
        }
    }
}