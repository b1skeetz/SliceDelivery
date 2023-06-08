using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SliceDelivery.DAL.Interfaces;
using SliceDelivery.Domain.Models;
using SliceDelivery.Domain.ViewModels.Product;
using SliceDelivery.Service.Interfaces;
using System.IO;
using System.Threading.Tasks;

namespace SliceDelivery.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService ProductService)
        {
            _productService = ProductService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var response = await _productService.GetProducts();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return View("Error", $"{response.Description}");
        }
        [HttpGet]
        public async Task<IActionResult> GetProduct(int id)
        {
            var response = await _productService.GetProduct(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return View("Error", $"{response.Description}");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _productService.DeleteProduct(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetProducts");
            }
            return View("Error", $"{response.Description}");
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Save(int id)
        {
            if(id == 0)
            {
                return View();
            }
            var response = await _productService.GetProduct(id);
            if(response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return View("Error", $"{response.Description}");
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Save(ProductViewModel model)
        {
            if (ModelState.IsValid) 
            {
                if(model.Id == 0)
                {
                    await _productService.CreateProduct(model);
                } 
                else
                {
                    await _productService.Edit(model.Id, model);
                }
            }
            return RedirectToAction("GetProduct");
        }
    }
}
