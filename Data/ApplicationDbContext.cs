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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasDiscriminator<string>("CarEngine")
                .HasValue<ICECategory>("Internal Combustion Engine")
                .HasValue<ElectricCategory>("Electric Engine");
            base.OnModelCreating(modelBuilder);
        }
    }
}
