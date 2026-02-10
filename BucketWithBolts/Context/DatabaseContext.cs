using BucketWithBolts.Models;
using Microsoft.EntityFrameworkCore;

namespace BucketWithBolts.Context
{
    /// <summary>
    /// Модель Базы данных
    /// </summary>
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// Пользователи
        /// </summary>
        public DbSet<User> Users => Set<User>();
        /// <summary>
        /// Статусы ресурса
        /// </summary>
        public DbSet<ResourseStatus> Resourse_Status => Set<ResourseStatus>();
        /// <summary>
        /// Ресурсы
        /// </summary>
        public DbSet<Resourse> Resourses => Set<Resourse>();
        /// <summary>
        /// Статусы заказа
        /// </summary>
        public DbSet<OrderStatus> Order_Status => Set<OrderStatus>();
        /// <summary>
        /// Заказы
        /// </summary>
        public DbSet<Order> Orders => Set<Order>();


        public DatabaseContext() => Database.EnsureCreated();


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
        }
    }
}