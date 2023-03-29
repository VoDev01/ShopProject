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
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasDiscriminator<string>("CarEngine")
                .HasValue<ICECategory>("Internal Combustion Engine")
                .HasValue<ElectricCategory>("Electric Engine");

            modelBuilder.Entity<Order>()
                .HasOne<People>(p => p.People)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.CustomerID);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.Cars)
                .WithMany(c => c.Orders)
                .UsingEntity<OrderDetails>(
                    j => j
                    .HasOne(od => od.Cars)
                    .WithMany(o => o.OrderDetails)
                    .HasForeignKey(od => od.CarsID),
                    j => j
                     .HasOne(od => od.Orders)
                     .WithMany(c => c.OrderDetails)
                     .HasForeignKey(od => od.OrdersID),
                    j =>
                    {
                        j.Property(od => od.Amount).HasDefaultValue(1);
                        j.HasKey(k => new { k.OrdersID, k.CarsID });
                        j.ToTable("OrderDetails");
                    });

            base.OnModelCreating(modelBuilder);
        }
    }
}
