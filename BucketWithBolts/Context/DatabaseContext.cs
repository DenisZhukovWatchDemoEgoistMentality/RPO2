using BucketWithBolts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BucketWithBolts.Context
{
    /// <summary>
    /// Модель Базы данных
    /// </summary>
    public class DatabaseContext : DbContext
    {
        private static IConfiguration _config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) // Ищет там, где лежит скомпилированная DLL
            .AddJsonFile("appsettings.json", optional: true)    // Сделаем необязательным для этапа дизайна
            .Build();

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
        /// <summary>
        /// Переписки
        /// </summary>
        public DbSet<Correspondence> Correspondences => Set<Correspondence>();


        public DatabaseContext()
        {
            bool useSqlServer = bool.Parse(_config["DbSettings:UseSqlServer"]);

            if (useSqlServer)
            {
                // Проверяем, есть ли миграции, которые еще не применены к базе в SSMS
                if (Database.GetPendingMigrations().Any())
                {
                    Console.WriteLine("1");
                    Database.Migrate();
                }
            }
            else
                Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            bool useSqlServer = bool.Parse(_config["DbSettings:UseSqlServer"]);

            if (useSqlServer)
            {
                Console.WriteLine("2");
                optionsBuilder.UseSqlServer(
                    _config.GetConnectionString("MsSqlConnection"),
                    x => x.MigrationsAssembly("BucketWithBolts")
                );
            }
            else
                optionsBuilder.UseSqlite(_config.GetConnectionString("SqliteConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
            .HasOne(o => o.Customer)
            .WithMany()              
            .HasForeignKey("Customer_id")
            .OnDelete(DeleteBehavior.Restrict);

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