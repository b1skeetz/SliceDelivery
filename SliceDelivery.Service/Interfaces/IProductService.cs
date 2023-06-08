using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SliceDelivery.Domain.Models;
using SliceDelivery.Domain.Response;
using SliceDelivery.Domain.ViewModels.Product;

namespace SliceDelivery.Service.Interfaces
{
    public interface IProductService
    {
        Task<BaseResponse<IEnumerable<Product>>> GetProducts();

        Task<BaseResponse<Product>> GetProduct(int id);

        Task<BaseResponse<ProductViewModel>> CreateProduct(ProductViewModel productViewModel);

        Task<BaseResponse<bool>> DeleteProduct(int id);
        Task<BaseResponse<Product>> GetProductByName(string name);
        Task<BaseResponse<Product>> Edit(int id, ProductViewModel model);
    }
}
