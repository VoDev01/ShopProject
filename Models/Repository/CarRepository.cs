using ShopProject.Data;
using ShopProject.Models.Interfaces;

namespace ShopProject.Models.Repository
{
    public class CarRepository : RepositoryBase<Car>, IAllCars
    {
        public CarRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
