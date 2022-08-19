using ProductService.Model.Repository;
using ProductServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductServices.Repository.Interface
{
    public interface IUserViewRepository:IGenericRepository<ClothingProduct>
    {
        IEnumerable<ClothingProduct> searchQueryAsync(string keyword);
        IEnumerable<Object> cityWiseStatsAsync();
        IEnumerable<Object> salesStatsAsync();
        IQueryable pendingOrdersAsync();
    }
}
