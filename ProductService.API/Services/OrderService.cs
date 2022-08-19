using ProductService.API.Model;
using ProductService.API.Repository.Interface;
using ProductService.API.ViewModel;
using ProductServices.Model;
using ProductServices.Repository.Interface;
using ProductServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductServices.Services
{
    public class OrderService:IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductService _productService;
        private readonly IPurchasedItemsRepository _purchasedItemRepository;
        
        public OrderService(IOrderRepository orderRepository, IPurchasedItemsRepository purchasedItemRepository, IProductService productService)
        {
            _orderRepository = orderRepository;
            _purchasedItemRepository= purchasedItemRepository;
            _productService = productService;
        }

        public async Task<AddOrderVM> AddOrderAsync(AddOrderVM orderDetails)
        {
            Guid OrderID = Guid.NewGuid();
            var order = new Orders();
            var purchasedItem = new PurchasedItems();

            order.OrderID = OrderID;
            order.UserID = orderDetails.UserID;
            order.Order_Date = orderDetails.Order_Date;
            order.address = orderDetails.address;
            order.creditCardNo = null;
            order.city = orderDetails.city;
            order.state = orderDetails.state;
            order.Promocode = orderDetails.promocode;
            order.firstName = orderDetails.firstName;
            order.lastName = orderDetails.lastName;
            order.postalCode = orderDetails.postalCode;
            order.discountPercentage = orderDetails.discountPercentage;
            order.discountedBill = orderDetails.discountedBill;
            order.Amount = orderDetails.gtotal;
            order.orderStatus = orderDetails.orderStatus;
            order.contactNumber = orderDetails.phone.ToString();
            order.email = orderDetails.email;

            try
            {
                var result = await _orderRepository.AddOrderAsync(order);

                for (int i = 0; i < orderDetails.purchasedItems.Count; i++)
                {
                    purchasedItem.Id = Guid.NewGuid();
                    purchasedItem.orderID = OrderID;
                    orderDetails.purchasedItems[i].orderID = OrderID;
                    purchasedItem.productID = orderDetails.purchasedItems[i].productID;
                    purchasedItem.productName = orderDetails.purchasedItems[i].productName;
                    purchasedItem.quantity = orderDetails.purchasedItems[i].quantity;
                    purchasedItem.itemTotal = orderDetails.purchasedItems[i].itemTotal;
                    purchasedItem.size = orderDetails.purchasedItems[i].size;

                    try
                    {
                        var Secondresult = await _purchasedItemRepository.AddAsync(purchasedItem);
                    }
                    catch(Exception e)
                    {
                        throw e;
                    }
                    
                }
                orderDetails.OrderId = OrderID;
                _productService.UpdateInventory(orderDetails);

            }
            catch(Exception e)
            {
                throw;
            }
            
            

            return orderDetails;
        }

        public IEnumerable<GetOrdersVM> GetOrderHistoryByIDAsync(Guid id)
        {
            return _orderRepository.GetOrderHistoryByIDAsync(id);
        }
        public Task<List<OrderStatus>> GetOrderStatus()
        {
            return _orderRepository.GetOrderStatus();
        }

        public async Task<int> UpdateOrderStatus(List<AddOrderVM> orders)
        {
            try
            {
                var result =await _orderRepository.UpdateOrderStatus(orders);
                return result;
            }
            catch(Exception e)
            {
                throw;
            }

        }
       

        public List<GetOrdersVM> GetCustomerOrdersAsync()
        {
            return  _orderRepository.GetCustomerOrdersAsync();
        }
    }
}
