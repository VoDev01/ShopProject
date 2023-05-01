using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopProject.Data;
using ShopProject.Models;
using ShopProject.Models.Interfaces;
using ShopProject.ViewModels;

namespace ShopProject.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllCars allCars;
        private readonly IPeople people;
        private readonly IAllOrders allOrders;

        public OrderController(IAllCars allCars, IPeople people, IAllOrders allOrders)
        {
            this.allCars = allCars;
            this.people = people;
            this.allOrders = allOrders;
        }

        [AllowAnonymous]
        public IActionResult CheckEmail(PeopleViewModel peopleVM)
        {
            var userEmail = people.GetAllWith(p => p.Email == peopleVM.People.Email);
            return Json(userEmail.Count() == 0);
        }

        public IActionResult DisplayOrderInfo(int orderId, int carId)
        {
            var order = allOrders.GetAll().ElementAt(orderId - 1);
            if (order != null)
            {
                var car = allCars.GetAll().ElementAt(carId - 1);
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
            //if (CheckEmail(peopleVM.People.Email) != Json(true))
            //   return View();
            if (ModelState.IsValid)
            {
                var car = allCars.GetAll().ElementAt(peopleVM.CarId - 1);
                Order order = new Order() { People = peopleVM.People };
                order.OrderDetails.Add(new OrderDetails() { Orders = order, Cars = car, Amount = 1, Price = car.Price });
                order.People.Orders.Add(order);
                people.Create(order.People);
                people.Save();
                return RedirectToAction("DisplayOrderInfo", "Order", new { orderId = order.Id, peopleVM.CarId });
            }
            else
                return View();
        }
    }
}
