using ProductService.API.Model;
using ProductService.API.ViewModel;
using ProductServices.Model;
using ProductServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductServices.Repository.Interface
{
    public interface IOrderRepository
    {
        Task<Orders> AddOrderAsync(Orders order);
        IEnumerable<GetOrdersVM> GetOrderHistoryByIDAsync(Guid id);
        List<GetOrdersVM> GetCustomerOrdersAsync();
        Task<int> UpdateOrderStatus(List<AddOrderVM> orders);
        Task<List<OrderStatus>> GetOrderStatus();
    }
}
