using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SliceDelivery.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SliceDelivery.DAL;
using SliceDelivery.Domain.Models;
using SliceDelivery.DAL.Interfaces;

namespace SliceDelivery.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
         
        public async Task<IActionResult> IndexAsync()
        {
             
            ViewBag.Number = 0;
            return View();
        }
        public new IActionResult User()
        {
            return View();
        }
        public IActionResult About()
        {
            ViewBag.Number = 1;
            return View();
        }
        public IActionResult Menu()
        {
            ViewBag.Number = 2;
            return View();
        }
        public IActionResult Products()
        {
            ViewBag.Number = 3;
            return View();
        }
        public IActionResult Review()
        {
            ViewBag.Number = 4;
            return View();
        }
        public IActionResult Contact()
        {
            ViewBag.Number = 5;
            return View();
        }
        public IActionResult Blog()
        {
            ViewBag.Number = 6;
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
