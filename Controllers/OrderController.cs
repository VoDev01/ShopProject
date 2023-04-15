using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopProject.Data;
using ShopProject.Models;
using ShopProject.ViewModels;

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
        public IActionResult AddPersonInfoToOrder(int carId)
        {
            PeopleViewModel peopleVM = new PeopleViewModel();
            peopleVM.CarId = carId;
            return View(peopleVM);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPersonInfoToOrder(PeopleViewModel peopleVM)
        {
            if (ModelState.IsValid)
            {
                var car = db.Cars.AsEnumerable().Last();
                Order order = new Order() { People = peopleVM.People };
                order.OrderDetails.Add(new OrderDetails() { Orders = order, Cars = car, Amount = 1, Price = car.Price });
                order.People.Orders.Add(order);
                db.Peoples.Add(order.People);
                db.SaveChanges();
                return RedirectToAction("DisplayOrderInfo", "Order", new { orderId = order.Id, peopleVM.CarId });
            }
            else
                return View();
        }
    }
}
