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
            if (_db == null) {
                InfoMessager.CreateErrorMessage("БД не найдена или к ней не подлючено", $"{this.GetType().Name}.Post");
                return false;
            }

            if (newItem.Login == null) {
                InfoMessager.CreateErrorMessage("Логин пустой", $"{this.GetType().Name}.Post");
                return false;
            }
            if (newItem.Password == null) {
                InfoMessager.CreateErrorMessage("Пароль пустой", $"{this.GetType().Name}.Post");
                return false;
            }

            if (_db.Admins.Any(i => i.Login == newItem.Login)) {
                InfoMessager.CreateErrorMessage("Такой логин уже существует", $"{this.GetType().Name}.Post");
                return false;
            }

            _db.Admins.Add(newItem);
            _db.SaveChanges();

            InfoMessager.CreateSuccessMessage($"{newItem.Login} добавлен", $"{this.GetType().Name}.Post");
            return true;
        }

        public Admin GetToId(int itemId)
        {
            if (_db == null) {
                InfoMessager.CreateErrorMessage("БД не найдена или к ней не подлючено", $"{this.GetType().Name}.GetToId");
                return null;
            }

            var admin = _db.Admins.FirstOrDefault(i => i.Id == itemId);

            if (admin == null) {
                InfoMessager.CreateErrorMessage("Данные по этому Id не найдено", $"{this.GetType().Name}.GetToId");
                return null;
            }

            InfoMessager.CreateSuccessMessage($"Данные найдены", $"{this.GetType().Name}.GetToId");
            return admin;
        }

        public List<Admin> GetAll()
        {
            if (_db == null) {
                InfoMessager.CreateErrorMessage("БД не найдена или к ней не подлючено", $"{this.GetType().Name}.GetAll");
                return null;
            }

            var admins = _db.Admins.ToList();

            if (admins == null) {
                InfoMessager.CreateErrorMessage("Данные не найдены", $"{this.GetType().Name}.GetAll");
                return null;
            }

            InfoMessager.CreateSuccessMessage($"Данные найдены", $"{this.GetType().Name}.GetAll");
            return admins;
        }

        public bool Delete(int itemId)
        {
            if (_db == null) {
                InfoMessager.CreateErrorMessage("БД не найдена или к ней не подлючено", $"{this.GetType().Name}.Delete");
                return false;
            }

            var admin = _db.Admins.FirstOrDefault(i => i.Id == itemId);

            if (admin == null) {
                InfoMessager.CreateErrorMessage("Данные по этому Id не найдено", $"{this.GetType().Name}.Delete");
                return false;
            }

            _db.Admins.Remove(admin);
            _db.SaveChanges();

            InfoMessager.CreateSuccessMessage($"{admin.Login} удалён", $"{this.GetType().Name}.Delete");
            return true;
        }
    }
}