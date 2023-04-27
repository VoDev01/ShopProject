using ShopProject.Data;
using Microsoft.AspNetCore.Mvc;
using ShopProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopProject.ViewModels;
using ShopProject.Models.Interfaces;

namespace ShopProject.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars allCars;
        private readonly ICarCategory carCategory;

        public CarsController(IAllCars allCars, ICarCategory carCategory)
        {
            this.allCars = allCars;
            this.carCategory = carCategory;
        }

        [Route("Cars/ListCars")]
        [Route("Cars/ListCars/{category}")]
        public IActionResult ListCars(string category)
        {
            IEnumerable<Car> cars = null;
            if(string.IsNullOrEmpty(category)) 
            {
                cars = allCars.GetAll().OrderBy(x => x.Id);
            }
            else 
            {
                if (string.Equals("electric", category, StringComparison.OrdinalIgnoreCase))
                    cars = allCars.GetAllWith(c => c.Category.Name.Equals("Электрокар")).OrderBy(c => c.Id);
                else if (string.Equals("int_comb_engine", category, StringComparison.OrdinalIgnoreCase))
                    cars = allCars.GetAllWith(c => c.Category.Name.Equals("Машина с ДВС")).OrderBy(c => c.Id);
            }
            List<Car> carObjList = cars.ToList();
            return View(carObjList);
        }
        [Route("Cars/Index")]
        public IActionResult Index()
        {
            IEnumerable<Car> cars = allCars.GetAllWith("Category");
            return View(cars);
        }
        public IActionResult Create()
        {
            var carViewModel = new CarViewModel { Car = new Car() };
            var categories = carCategory.GetAll();
            ViewBag.Categories =  new SelectList(categories, "Id", "Name");
            return View(carViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CarViewModel carVM) 
        {
            //if (ModelState.IsValid)
            //{
                Car car = carVM.Car;
                var catList = carCategory.GetAll();
                car.Category = catList.ElementAt(carVM.CategoryID - 1);
                allCars.Create(car);
                allCars.Save();
                TempData["success"] = $"Машина была успешно создана!";
                return RedirectToAction("Index");
            //}
            //return View(carVM);
        }
        public IActionResult Edit(int id)
        {
            var carVM = new CarViewModel { Car = allCars.GetByID(id) };
            var categories = carCategory.GetAll();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View(carVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CarViewModel carVM)
        {
            //if (ModelState.IsValid)
            //{
                Car car = carVM.Car;
                var catList = carCategory.GetAll();
                car.Category = catList.ElementAt(carVM.CategoryID - 1);
                allCars.Update(car);
                allCars.Save();
                TempData["success"] = $"Машина была успешно изменена!";
                return RedirectToAction("Index");
            //}
            //return View(carVM);
        }
        public IActionResult Delete(int id)
        {
            Car car = allCars.GetAllWith("Category").AsEnumerable().ElementAt(id - 1);
            CarViewModel carVM = new CarViewModel { Car = car, CategoryID = car.Category.Id };
            return View(carVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(CarViewModel carVM)
        {
            allCars.Delete(carVM.Car);
            allCars.Save();
            TempData["success"] = $"Машина была успешно удалена!";
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id) 
        {
            Car car = allCars.GetAllWith("Category").AsEnumerable().ElementAt(id-1);
            CarViewModel carVM = new CarViewModel { Car = car, CategoryID = car.Category.Id };
            return View(carVM);
        }
    }
}
