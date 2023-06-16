using SliceDelivery.Domain.Models;
using SliceDelivery.Domain.Response;
using SliceDelivery.Domain.ViewModels.Order;
using System.Threading.Tasks;

namespace SliceDelivery.Service.Interfaces
{
    public interface IOrderService
    {
        Task<IBaseResponse<Order>> Create(CreateOrderViewModel model);

        Task<IBaseResponse<bool>> Delete(long id);
    }
}