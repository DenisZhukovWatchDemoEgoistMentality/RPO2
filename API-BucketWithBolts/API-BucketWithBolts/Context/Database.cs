using Api_Topito.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace API_BucketWithBolts.Context
{
    public class Database : DbContext
    {
        public Database(DbContextOptions<Database> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<ResourseStatus> ResourseStatus { get; set; }
        public DbSet<Resourse> Resourses { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
