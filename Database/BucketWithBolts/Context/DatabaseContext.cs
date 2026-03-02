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
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true)
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
        /// Изображения
        /// </summary>
        public DbSet<Image> Images => Set<Image>();
        /// <summary>
        /// Ссылки к ресурсу и его изображениям
        /// </summary>
        public DbSet<Resource_Image> Resource_Images => Set<Resource_Image>();
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


        public DatabaseContext() { }
        public DatabaseContext(IConfiguration configuration) : base()
        {
            _config = configuration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            bool useSqlServer = bool.Parse(_config["DbSettings:UseSqlServer"]);

            if (useSqlServer)
            {
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

            modelBuilder.Entity<Correspondence>()
                .HasOne(c => c.Sender)
                .WithMany() 
                .HasForeignKey("Sender_Id")
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Correspondence>()
                .HasOne(c => c.Recipient)
                .WithMany()
                .HasForeignKey("Recipient_Id")
                .OnDelete(DeleteBehavior.NoAction);

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