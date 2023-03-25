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

        public IActionResult List()
        {
            List<Car> objCarList = db.Cars.ToList();
            return View(objCarList);
        }
    }
}
