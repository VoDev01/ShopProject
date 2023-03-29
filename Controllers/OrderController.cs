using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<JsonResult> CheckEmail(string email)
        {
            var result = await db.Peoples.FirstOrDefaultAsync(m => m.Email == email);
            if (result == null)
               return Json(true);
            else
                return Json(false);
        }

        public IActionResult DisplayOrderInfo(int orderId, int carId)
        {
            var order = db.Orders.AsEnumerable().ElementAt(orderId - 1);
            if (order != null)
            {
                var car = db.Cars.AsEnumerable().ElementAt(carId - 1);
                var od = new OrderDetails { Orders = order, Cars = car, Price = car.Price };
                return View(od);
            }
            return View(); 
        }

        //GET
        public IActionResult AddPersonInfoToOrder()
        {
            return View();
        }

        //POST
        [HttpPost("Order/AddPersonInfoToOrder/{carId:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult AddPersonInfoToOrder(People people, int carId)
        {
            if (ModelState.IsValid)
            {
                var car = db.Cars.AsEnumerable().ElementAt(carId-1);
                var order = new Order { People = people };
                order.Cars.Add(car);
                order.OrderDetails.Add(new OrderDetails() { Orders = order, Cars = car, Amount = 1, Price = car.Price });
                people.Orders.Add(order);
                db.Peoples.Add(people);
                db.SaveChanges();
                return RedirectToAction("DisplayOrderInfo", "Order", new { orderId = order.Id, carId });
            }
            else
                return View();
        }
    }
}
