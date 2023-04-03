using ShopProject.Data;
using Microsoft.AspNetCore.Mvc;
using ShopProject.Models;

namespace ShopProject.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext db;

        public CarsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [Route("Cars/ListCars")]
        [Route("Cars/ListCars/{category}")]
        public IActionResult ListCars(string category)
        {
            IEnumerable<Car> cars = null;
            if(string.IsNullOrEmpty(category)) 
            {
                cars = db.Cars.OrderBy(x => x.Id);
            }
            else 
            {
                if (string.Equals("electric", category, StringComparison.OrdinalIgnoreCase))
                    cars = db.Cars.Where(c => c.Category.Name.Equals("Электрокар")).OrderBy(c => c.Id);
                else if (string.Equals("int_comb_engine", category, StringComparison.OrdinalIgnoreCase))
                    cars = db.Cars.Where(c => c.Category.Name.Equals("Машина с ДВС")).OrderBy(c => c.Id);
            }
            List<Car> carObjList = cars.ToList();
            return View(carObjList);
        }
    }
}
