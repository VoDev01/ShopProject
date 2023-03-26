using Microsoft.AspNetCore.Mvc;
using ShopProject.Data;
using ShopProject.Models;

namespace ShopProject.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext db;

        public OrderController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult DisplayOrderInfo()
        {
            return View(); 
        }

        //GET
        public IActionResult AddPersonInfoToOrder()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPersonInfoToOrder(Order obj, int carId)
        {
            db.Orders.Add(obj);
            db.SaveChanges();
            return RedirectToAction("DisplayOrderInfo");
        }
    }
}
