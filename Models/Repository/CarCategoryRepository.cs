using ShopProject.Data;
using ShopProject.Models.CarsCategories;
using ShopProject.Models.Interfaces;

namespace ShopProject.Models.Repository
{
    public class CarCategoryRepository : RepositoryBase<Category>, ICarCategory
    {
        public CarCategoryRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
