using Microsoft.AspNetCore.Mvc;
using ShopProject.Data;
using ShopProject.Models;
using ShopProject.Models.Interfaces;
using System.Diagnostics;

namespace ShopProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllCars allCars;
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> logger, IAllCars allCars)
        {
            this.logger = logger;
            this.allCars = allCars;
        }

        public IActionResult Index()
        {
            List<Car> carObjList = allCars.GetAll().ToList();
            return View(carObjList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}