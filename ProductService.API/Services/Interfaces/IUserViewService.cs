using ProductServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductServices.Services
{
    public interface IUserViewService
    {
        IEnumerable<ClothingProduct> searchQueryAsync(string keyword);
        IEnumerable<Object> cityWiseStatsAsync();
        IEnumerable<Object> salesStatsAsync();
        IQueryable pendingOrdersAsync();
    }
}
