using Microsoft.EntityFrameworkCore;
using ShopProject.Models;
using ShopProject.Models.CarsCategories;

namespace ShopProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ICECategory> ICECategories { get; set; }
        public DbSet<ElectricCategory> ElectricCategories { get; set; }
        public DbSet<People> Peoples { get; set; }
        public DbSet<Orders> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasDiscriminator<string>("CarEngine")
                .HasValue<ICECategory>("Internal Combustion Engine")
                .HasValue<ElectricCategory>("Electric Engine");

            modelBuilder.Entity<Orders>()
                .HasOne<People>(p => p.People)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.CustomerID);

            modelBuilder.Entity<OrderDetails>().HasKey(od => new { od.OrdersID, od.CarsID });
            modelBuilder.Entity<OrderDetails>()
                .HasOne<Orders>(od => od.Orders)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrdersID);
            modelBuilder.Entity<OrderDetails>()
                .HasOne<Car>(od => od.Cars)
                .WithMany(c => c.OrderDetails)
                .HasForeignKey(od => od.CarsID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
