﻿using Microsoft.AspNetCore.Mvc;

namespace ShopProject.Controllers
{
    public class CarsController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
