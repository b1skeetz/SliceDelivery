using SliceDelivery.DAL.Interfaces;
using SliceDelivery.Domain.Models;
using SliceDelivery.Domain.Enum;
using SliceDelivery.Domain.Extentions;
using SliceDelivery.Domain.Response;
using SliceDelivery.Domain.ViewModels.Order;
using SliceDelivery.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SliceDelivery.Service.Implementations
{

    public class BasketService : IBasketService
    {
        private readonly IBaseRepository<User> _userRepository;
        private readonly IBaseRepository<Product> _productRepository;

        public BasketService(IBaseRepository<User> userRepository, IBaseRepository<Product> productRepository)
        {
            _userRepository = userRepository;
            _productRepository = productRepository;
        }

        public async Task<IBaseResponse<IEnumerable<OrderViewModel>>> GetItems(string userName)
        {
            try
            {
                var user = await _userRepository.GetAll()
                    .Include(x => x.Basket)
                    .ThenInclude(x => x.Orders)
                    .FirstOrDefaultAsync(x => x.Name == userName);

                if (user == null)
                {
                    return new BaseResponse<IEnumerable<OrderViewModel>>()
                    {
                        Description = "Пользователь не найден",
                        StatusCode = StatusCode.UserNotFound
                    };
                }

                var orders = user.Basket?.Orders;
                var response = from p in orders
                               join c in _productRepository.GetAll() on p.ProductId equals c.Id
                               select new OrderViewModel()
                               {
                                   Id = p.Id,
                                   ProductName = c.Name,
                                   ProductType = c.Category.GetDisplayName(),
                                   Image = c.Avatar,
                                   Description = c.Description,
                                   CurrentPrice = c.CurrentPrice
                               };

                return new BaseResponse<IEnumerable<OrderViewModel>>()
                {
                    Data = response,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<OrderViewModel>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<OrderViewModel>> GetItem(string userName, long id)
        {
            try
            {
                var user = await _userRepository.GetAll()
                    .Include(x => x.Basket)
                    .ThenInclude(x => x.Orders)
                    .FirstOrDefaultAsync(x => x.Name == userName);

                if (user == null)
                {
                    return new BaseResponse<OrderViewModel>()
                    {
                        Description = "Пользователь не найден",
                        StatusCode = StatusCode.UserNotFound
                    };
                }

                var orders = user.Basket?.Orders.Where(x => x.Id == id).ToList();
                if (orders == null || orders.Count == 0)
                {
                    return new BaseResponse<OrderViewModel>()
                    {
                        Description = "Заказов нет",
                        StatusCode = StatusCode.OrderNotFound
                    };
                }

                var response = (from p in orders
                                join c in _productRepository.GetAll() on p.ProductId equals c.Id
                                select new OrderViewModel()
                                {
                                    Id = p.Id,
                                    ProductName = c.Name,
                                    Description = c.Description,
                                    ProductType = c.Category.GetDisplayName(),
                                    Address = p.Address,
                                    FirstName = p.FirstName,
                                    LastName = p.LastName,
                                    MiddleName = p.MiddleName,
                                    DateCreate = p.DateCreated.ToLongDateString(),
                                    Image = c.Avatar
                                }).FirstOrDefault();

                return new BaseResponse<OrderViewModel>()
                {
                    Data = response,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<OrderViewModel>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}