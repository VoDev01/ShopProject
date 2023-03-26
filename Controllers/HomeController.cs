using Microsoft.AspNetCore.Mvc;
using ShopProject.Data;
using ShopProject.Models;
using System.Diagnostics;

namespace ShopProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            this.logger = logger;
            this.db = db;
        }

        public IActionResult Index()
        {
            List<Car> carObjList = db.Cars.ToList();
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