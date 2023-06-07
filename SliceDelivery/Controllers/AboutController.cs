using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SliceDelivery.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SliceDelivery.Controllers
{
    public class AboutController : Controller
    {
    

      
        public IActionResult Index()
        {
            return View("About");
        }

     
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
