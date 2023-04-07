using ShopProject.Models;
using ShopProject.Models.CarsCategories;
namespace ShopProject.ViewModels
{
    public class CarViewModel
    {
        public Car Car { get; set; }
        public int CategoryID { get; set; }
        //public IEnumerable<Category> Categoriesdb { get; set; }
    }
}
