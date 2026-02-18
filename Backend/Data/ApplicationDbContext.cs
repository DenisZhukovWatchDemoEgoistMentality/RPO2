using Microsoft.EntityFrameworkCore;
using TopitoAPI.Models;

namespace TopitoAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<ResourceStatus> ResourceStatuses { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Users
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<User>()
                .Property(u => u.Login)
                .IsRequired()
                .HasMaxLength(20);
            modelBuilder.Entity<User>()
                .Property(u => u.Mail)
                .IsRequired()
                .HasMaxLength(20);
            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.Balance)
                .HasDefaultValue(0);

            // Admins
            modelBuilder.Entity<Admin>()
                .HasKey(a => a.Id);
            modelBuilder.Entity<Admin>()
                .Property(a => a.Login)
                .IsRequired()
                .HasMaxLength(20);
            modelBuilder.Entity<Admin>()
                .Property(a => a.Password)
                .IsRequired();

            // ResourceStatus
            modelBuilder.Entity<ResourceStatus>()
                .HasKey(rs => rs.Id);
            modelBuilder.Entity<ResourceStatus>()
                .Property(rs => rs.Name)
                .IsRequired()
                .HasMaxLength(20);

            // Condition
            modelBuilder.Entity<Condition>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Condition>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(20);

            // Resources
            modelBuilder.Entity<Resource>()
                .HasKey(r => r.Id);
            modelBuilder.Entity<Resource>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(80);
            modelBuilder.Entity<Resource>()
                .Property(r => r.Price)
                .IsRequired();
            modelBuilder.Entity<Resource>()
                .HasOne(r => r.Owner)
                .WithMany(u => u.Resources)
                .HasForeignKey(r => r.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Resource>()
                .HasOne(r => r.Condition)
                .WithMany(c => c.Resources)
                .HasForeignKey(r => r.ConditionId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Resource>()
                .HasOne(r => r.Status)
                .WithMany(rs => rs.Resources)
                .HasForeignKey(r => r.StatusId)
                .OnDelete(DeleteBehavior.Cascade);

            // OrderStatus
            modelBuilder.Entity<OrderStatus>()
                .HasKey(os => os.Id);
            modelBuilder.Entity<OrderStatus>()
                .Property(os => os.Name)
                .IsRequired()
                .HasMaxLength(20);

            // Orders
            modelBuilder.Entity<Order>()
                .HasKey(o => o.Id);
            modelBuilder.Entity<Order>()
                .Property(o => o.Quantity)
                .IsRequired();
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Resource)
                .WithMany(r => r.Orders)
                .HasForeignKey(o => o.ResourceId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Status)
                .WithMany(os => os.Orders)
                .HasForeignKey(o => o.StatusId)
                .OnDelete(DeleteBehavior.Cascade);

            // Feedbacks
            modelBuilder.Entity<Feedback>()
                .HasKey(f => f.Id);
            modelBuilder.Entity<Feedback>()
                .Property(f => f.Stars)
                .IsRequired();
            modelBuilder.Entity<Feedback>()
                .Property(f => f.Description)
                .HasMaxLength(255);
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Order)
                .WithMany(o => o.Feedbacks)
                .HasForeignKey(f => f.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}