using ProductService.Model.Repository;
using ProductServices.Model;
using ProductServices.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ProductServices.Repository
{
    public class UserViewRepository : IUserViewRepository
    {
        protected readonly ProductContext _context;
        public UserViewRepository(ProductContext context)
        {
            _context = context;

        }

        public Task<ClothingProduct> AddAsync(ClothingProduct entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable <ClothingProduct> GetAll()
        {
            throw new NotImplementedException();
        }

       

        public IEnumerable<ClothingProduct> searchQueryAsync(string keyword)
        {
           
            try
            {
                var productList = _context.ClothingProducts.Where(c => EF.Functions.Like(c.productName, "%" + keyword + "%") || EF.Functions.Like(c.description, "%" + keyword + "%"));
                return productList;
            }
            catch (Exception e)
            {
                throw e;
            }


        }

        public IEnumerable<Object> cityWiseStatsAsync()
        {

            try
            {
                 var list = _context.Orders
                .GroupBy(n => n.city)
                .Select(n => new
                {
                    CityName = n.Key,
                    OrderCount = n.Count()
                   
                })
               .OrderBy(n => n.OrderCount);

                    return list;
                }
            catch (Exception e)
            {
                throw e;
            }


        }
        public IEnumerable<Object> salesStatsAsync()
        {

            try
            {

                var list = _context.Orders
               .GroupBy(n => new { n.Order_Date.Month})
               .Select(n => new
               {
                   orderMonth = n.Key,
                   OrderCount = n.Count(),
                   orderSum=n.Sum(o=>o.Amount),
                   
               });
                
                return list;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public IQueryable pendingOrdersAsync()
        {
            try
            {
                var list = _context.Orders.Where(o => o.orderStatus == "In-process");
               

                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        Task<ClothingProduct> IGenericRepository<ClothingProduct>.UpdateAsync(ClothingProduct entity)
        {
            throw new NotImplementedException();
        }
    }
}
