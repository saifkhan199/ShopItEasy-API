using ProductService.API.Model;
using ProductService.Model.Repository;
using ProductServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.API.Repository.Interface
{
    public interface IPurchasedItemsRepository:IGenericRepository<PurchasedItems>
    {
        public Task<PurchasedItems> AddOrderAsync(PurchasedItems order);
    }
}
