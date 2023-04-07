using ShopProject.Data;
using Microsoft.AspNetCore.Mvc;
using ShopProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopProject.ViewModels;

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
        [Route("Cars/Index")]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Car> cars = await db.Cars.Include(c => c.Category).ToListAsync();
            return View(cars);
        }
        public async Task<IActionResult> Create()
        {
            var carViewModel = new CarViewModel { Car = new Car() };
            var categories = await db.Categories.ToListAsync();
            ViewBag.Categories =  new SelectList(categories, "Id", "Name");
            return View(carViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarViewModel carVM) 
        {
            Car car = carVM.Car;
            var catList = await db.Categories.ToListAsync();
            car.Category = catList[carVM.CategoryID-1];
            db.Cars.Add(car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var carVM = new CarViewModel { Car = db.Cars.Find(id) };
            var categories = db.Categories.ToList();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View(carVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CarViewModel carVM)
        {
            Car car = carVM.Car;
            var catList = db.Categories.ToList();
            car.Category = catList[carVM.CategoryID - 1];
            db.Cars.Update(car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Car car = db.Cars.Include(c => c.Category).AsEnumerable().ElementAt(id-1);
            CarViewModel carVM = new CarViewModel { Car = car, CategoryID = car.Category.Id };
            return View(carVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(CarViewModel carViewModel)
        {
            db.Cars.Remove(carViewModel.Car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id) 
        {
            Car car = db.Cars.Include(c => c.Category).AsEnumerable().ElementAt(id-1);
            CarViewModel carVM = new CarViewModel { Car = car, CategoryID = car.Category.Id };
            return View(carVM);
        }
    }
}
