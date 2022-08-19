using Microsoft.AspNetCore.Mvc;
using ProductService.API.Model;
using ProductService.API.ViewModel;
using ProductServices.Services;
using ProductServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;

        }
        [HttpGet("{UserID}")]
        public IEnumerable<GetOrdersVM> GetOrderHistoryByID(Guid UserID)
        {
            try
            {

                var response = _orderService.GetOrderHistoryByIDAsync(UserID);

                if (response == null)
                {
                    return null;
                }
                else
                    return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet("GetCustomerOrders")]
        public async Task<List<GetOrdersVM>> GetCustomerOrders()
        {
            try
            {

                var response = _orderService.GetCustomerOrdersAsync();

                if (response == null)
                {
                    return null;
                }
                else
                    return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpPost("UpdateOrderStatus")]
        public async Task<int>UpdateOrderStatus(List<AddOrderVM> orders)
        {
            try
            {
                var response = await _orderService.UpdateOrderStatus(orders);
                return response;
            }
            catch(Exception e)
            {
                throw;
            }
        }
        [HttpGet("GetOrderStatus")]
        public async Task<List<OrderStatus>> GetOrderStatus()
        {
            try
            {

                var response =await _orderService.GetOrderStatus();

                if (response == null)
                {
                    return null;
                }
                else
                    return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost("AddOrder")]
        public async Task<ActionResult<AddOrderVM>> AddOrder([FromBody] AddOrderVM order)
        {

            if (order == null)
            {
                return BadRequest("Order is null.");
            }
            else
            {
                var result= await _orderService.AddOrderAsync(order);
                return result;
            }


        }
       
    }
}
