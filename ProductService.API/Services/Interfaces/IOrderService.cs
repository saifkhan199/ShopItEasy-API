using ProductService.API.Model;
using ProductService.API.ViewModel;
using ProductServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductServices.Services
{
   public interface IOrderService
    {
        Task<AddOrderVM> AddOrderAsync(AddOrderVM order);
        IEnumerable<GetOrdersVM> GetOrderHistoryByIDAsync(Guid id);
        List<GetOrdersVM> GetCustomerOrdersAsync();
        Task<List<OrderStatus>> GetOrderStatus();
        Task<int> UpdateOrderStatus(List<AddOrderVM> orders);
    }
}
