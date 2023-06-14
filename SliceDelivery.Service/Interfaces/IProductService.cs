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
        IBaseResponse<List<Product>> GetProducts();

        Task<IBaseResponse<ProductViewModel>> GetProduct(long id);

        Task<BaseResponse<Dictionary<int, string>>> GetProduct(string term);

        Task<IBaseResponse<Product>> Edit(long id, ProductViewModel model);
    }
}
