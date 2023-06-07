﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SliceDelivery.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SliceDelivery.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Menu()
        {
            return View();
        }
        public IActionResult Products()
        {
            return View();
        }
        public IActionResult Review()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Blog()
        {
            return View();
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
