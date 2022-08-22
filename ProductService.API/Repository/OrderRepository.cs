using Microsoft.EntityFrameworkCore;
using ProductService.API.Model;
using ProductService.API.ViewModel;
using ProductService.Model.Repository;
using ProductServices.Model;
using ProductServices.Repository.Interface;
using ProductServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProductServices.Repository
{
    public class OrderRepository:DataRepository<Orders>,IOrderRepository
    {
        public OrderRepository(ProductContext context) : base(context)
        {
        }
       public async Task<Orders> AddOrderAsync(Orders order)
        {
            try
            {
                var result= await AddAsync(order);
                return result;
            }
            catch(Exception e)
            {
                throw e;
            }

        }
        public IEnumerable<GetOrdersVM> GetOrderHistoryByIDAsync(Guid id)
        {
            var orderIds = _context.Orders.Where(o => o.UserID == id).Select(o => o.OrderID).ToList();
            
            var orderDetails = from orders in _context.Orders
                        join purchasedItems in _context.PurchasedItems on orders.OrderID equals purchasedItems.orderID
                        where orderIds.Contains(orders.OrderID)
                        select new GetOrdersVM
                        {
                            productName = purchasedItems.productName,
                            quantity= purchasedItems.quantity,
                            itemTotal=purchasedItems.itemTotal,
                            size = purchasedItems.size,

                            OrderId = orders.OrderID,
                            Order_Date = orders.Order_Date,
                            gtotal = orders.Amount,
                            orderStatus = orders.orderStatus,
                            promoCode=orders.Promocode,
                            discountPercentage=orders.discountPercentage,
                            discountedBill=orders.discountedBill,
                        };




            return orderDetails;


        }
        public async Task<List<OrderStatus>> GetOrderStatus()
        {
            var status =await _context.orderStatus.ToListAsync();
            return status;

        }
        public List<GetOrdersVM> GetCustomerOrdersAsync()
        {
            List<GetOrdersVM> a=new List<GetOrdersVM>();
            var orderDetails =from orders in _context.Orders
                               join purchasedItems in _context.PurchasedItems on orders.OrderID equals purchasedItems.orderID
                               select new GetOrdersVM
                               {
                                   productName = purchasedItems.productName,
                                   quantity = purchasedItems.quantity,
                                   itemTotal = purchasedItems.itemTotal,
                                   size=purchasedItems.size,

                                   OrderId = orders.OrderID,
                                   Order_Date = orders.Order_Date,
                                   city=orders.city,
                                   state=orders.state,
                                   gtotal = orders.Amount,
                                   discountedBill=orders.discountedBill,
                                   orderStatus = orders.orderStatus,
                                   firstName=orders.firstName,
                                   lastName=orders.lastName,
                                   email=orders.email,
                                   promoCode = orders.Promocode,
                                   discountPercentage = orders.discountPercentage,
                                  

                               };

            return orderDetails.ToList();


        }
        public async Task<int> UpdateOrderStatus(List<AddOrderVM> orders)
        {
            
            try
            {
                foreach (var o in orders)
                {
                    var order = _context.Orders.FirstOrDefault(x => x.OrderID == o.OrderId);
                    order.orderStatus = o.orderStatus;
                    
                }

                return await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                throw;
            }
        }
    }
}
