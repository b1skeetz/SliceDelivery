using SliceDelivery.Domain.Response;
using SliceDelivery.Domain.ViewModels.Order;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SliceDelivery.Service.Interfaces
{
    public interface IBasketService
    {
        Task<IBaseResponse<IEnumerable<OrderViewModel>>> GetItems(string userName);

        Task<IBaseResponse<OrderViewModel>> GetItem(string userName, long id);
    }   
}