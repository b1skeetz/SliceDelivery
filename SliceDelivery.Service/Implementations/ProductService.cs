using SliceDelivery.DAL.Interfaces;
using SliceDelivery.Domain.Enum;
using SliceDelivery.Domain.Models;
using SliceDelivery.Domain.Response;
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
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<BaseResponse<IEnumerable<Product>>> GetProducts()
        {
            var baseResponse = new BaseResponse<IEnumerable<Product>>();
            try
            {
                var products = await _productRepository.Select();
                if (products.Count == 0)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = products;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Product>>()
                {
                    Description = $"[GetProducts] : {ex.Message}"
                };
            }
        }
        public async Task<BaseResponse<Product>> GetProduct(int id)
        {
            var baseResponse = new BaseResponse<Product>();
            try
            {
                var product = await _productRepository.Get(id);
                if (product == null)
                {
                    baseResponse.Description = "Пользователь не найден!";
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    return baseResponse;
                }
                baseResponse.Data = product;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Product>()
                {
                    Description = $"[GetProduct] : {ex.Message}"
                };
            }
        }
        public async Task<BaseResponse<Product>> GetProductByName(string name)
        {
            var baseResponse = new BaseResponse<Product>();
            try
            {
                var product = await _productRepository.GetByName(name);
                if (product == null)
                {
                    baseResponse.Description = "Пользователь не найден!";
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    return baseResponse;
                }
                baseResponse.Data = product;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Product>()
                {
                    Description = $"[GetProductByName] : {ex.Message}"
                };
            }
        }
        public async Task<BaseResponse<bool>> DeleteProduct(int id)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var product = await _productRepository.Get(id);
                if (product == null)
                {
                    baseResponse.Description = "Пользователь не найден!";
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    return baseResponse;
                }
                await _productRepository.Delete(product);
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteProduct] : {ex.Message}"
                };
            }
        }
        public async Task<BaseResponse<ProductViewModel>> CreateProduct(ProductViewModel productViewModel)
        {
            var baseResponse = new BaseResponse<ProductViewModel>();
            try
            {
                var product = new Product
                {
                    Description = productViewModel.Description,
                    Name = productViewModel.Name,
                    CurrentPrice = productViewModel.CurrentPrice,
                    OldPrice = productViewModel.OldPrice,
                    Category = (ProductType)Convert.ToInt32(productViewModel.Category),
                    Image = productViewModel.Image,
                };
                baseResponse.StatusCode = StatusCode.OK;
                baseResponse.Description = "Продукт " + product.Name + " успешно добавлен!";
                await _productRepository.Create(product);
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<ProductViewModel>()
                {
                    Description = $"[CreateProduct] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }

        }
        public async Task<BaseResponse<Product>> Edit(int id, ProductViewModel model)
        {
            var baseResponse = new BaseResponse<Product>();
            try
            {
                var product = await _productRepository.Get(id);
                if (product == null)
                {
                    baseResponse.StatusCode = StatusCode.ProductNotFound;
                    baseResponse.Description = "Продукт не найден!";
                    return baseResponse;
                }
                product.Description = model.Description;
                product.Category = (ProductType)Convert.ToInt32(model.Category);
                product.CurrentPrice = model.CurrentPrice;
                product.OldPrice = model.OldPrice;
                product.Image = model.Image;
                product.Name = model.Name;

                await _productRepository.Update(product);
                return baseResponse;
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
    }
}
