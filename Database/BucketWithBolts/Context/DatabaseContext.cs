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
        /// Админы
        /// </summary>
        public DbSet<Admin> Admins => Set<Admin>();
        /// <summary>
        /// Состояние товара
        /// </summary>
        public DbSet<Condition> Conditions => Set<Condition>();
        /// <summary>
        /// Статусы ресурса
        /// </summary>
        public DbSet<ResourceStatus> Resource_Status => Set<ResourceStatus>();
        /// <summary>
        /// Ресурсы
        /// </summary>
        public DbSet<Resource> Resources => Set<Resource>();
        /// <summary>
        /// Статусы заказа
        /// </summary>
        public DbSet<OrderStatus> Order_Status => Set<OrderStatus>();
        /// <summary>
        /// Заказы
        /// </summary>
        public DbSet<Order> Orders => Set<Order>();
        /// <summary>
        /// Отзывы
        /// </summary>
        public DbSet<Feedback> Feedbacks => Set<Feedback>();


        public DatabaseContext() => Database.EnsureCreated();


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Topito_DB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Начальные данные для таблицы Conditions
            modelBuilder.Entity<Condition>().HasData(
                new Condition { Id = 1, Name = "Новый" },
                new Condition { Id = 2, Name = "Б/У" }
            );

            // Начальные данные для таблицы ResourceStatus
            modelBuilder.Entity<ResourceStatus>().HasData(
                new ResourceStatus { Id = 1, Name = "Выставлен" },
                new ResourceStatus { Id = 2, Name = "Продан" }
            );

            // Начальные данные для таблицы OrderStatus
            modelBuilder.Entity<OrderStatus>().HasData(
                new OrderStatus { Id = 1, Name = "Ожидание" },
                new OrderStatus { Id = 2, Name = "Продан" },
                new OrderStatus { Id = 3, Name = "Отменён" }
            );
        }
    }
}