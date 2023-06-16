using Microsoft.EntityFrameworkCore;
using SliceDelivery.DAL.Interfaces;
using SliceDelivery.Domain.Enum;
using SliceDelivery.Domain.Models;
using SliceDelivery.Domain.Response;
using SliceDelivery.Domain.Extentions;
using SliceDelivery.Domain.ViewModels.Product;
using SliceDelivery.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SliceDelivery.Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IBaseRepository<Product> _productRepository;
        public ProductService(IBaseRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IBaseResponse<ProductViewModel>> GetProduct(long id)
        {
            try
            {
                var product = await _productRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (product == null)
                {
                    return new BaseResponse<ProductViewModel>()
                    {
                        Description = "Продукт не найден",
                        StatusCode = StatusCode.ProductNotFound
                    };
                }

                var data = new ProductViewModel()
                {
                    Description = product.Description,
                    Name = product.Name,
                    CurrentPrice = product.CurrentPrice,
                    OldPrice = product.OldPrice,
                    Category = product.Category.GetDisplayName(),
                    Image = product.Avatar,
                };

                return new BaseResponse<ProductViewModel>()
                {
                    StatusCode = StatusCode.OK,
                    Data = data
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<ProductViewModel>()
                {
                    Description = $"[GetProduct] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public IBaseResponse<Dictionary<int, string>> GetProduct(string term)
        {
            var baseResponse = new BaseResponse<Dictionary<int, string>>();
            try
            {
                var product = _productRepository.GetAll()
                    .Select(x => new ProductViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description,
                        CurrentPrice = x.CurrentPrice,
                        OldPrice = x.OldPrice,
                        Category = x.Category.GetDisplayName()
                    })
                    .Where(x => EF.Functions.Like(x.Name, $"%{term}%"))
                    .ToDictionary(x => x.Id, t => t.Name);

                baseResponse.Data = product;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Dictionary<int, string>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }


        public async Task<IBaseResponse<Product>> Edit(long id, ProductViewModel model)
        {
            try
            {
                var product = await _productRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (product == null)
                {
                    return new BaseResponse<Product>()
                    {
                        Description = "Car not found",
                        StatusCode = StatusCode.ProductNotFound
                    };
                }

                product.Description = model.Description;
                product.CurrentPrice = model.CurrentPrice;
                product.OldPrice = model.OldPrice;
                product.Category = (ProductType)Convert.ToInt32(model.Category);
                product.Name = model.Name;

                await _productRepository.Update(product);


                return new BaseResponse<Product>()
                {
                    Data = product,
                    StatusCode = StatusCode.OK,
                };
                // TypeCar
            }
            catch (Exception ex)
            {
                return new BaseResponse<Product>()
                {
                    Description = $"[Edit] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public IBaseResponse<List<Product>> GetProducts()
        {
            try
            {
                var products = _productRepository.GetAll().ToList();
                if (!products.Any())
                {
                    return new BaseResponse<List<Product>>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusCode = StatusCode.OK
                    };
                }

                return new BaseResponse<List<Product>>()
                {
                    Data = products,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Product>>()
                {
                    Description = $"[GetProducts] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
