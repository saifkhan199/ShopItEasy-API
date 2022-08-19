using ProductService.API.Model;
using ProductService.API.Repository.Interface;
using ProductService.Model.Repository;
using ProductServices.Model;
using ProductServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.API.Repository
{
    public class PurchasedItemsRepository:DataRepository<PurchasedItems>,IPurchasedItemsRepository
    {
        public PurchasedItemsRepository(ProductContext context) : base(context)
        {
        }
        public Task<PurchasedItems> AddOrderAsync(PurchasedItems order)
        {
            try
            {

                return AddAsync(order);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
