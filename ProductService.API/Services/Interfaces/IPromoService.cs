using ProductServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductServices.Services
{
    public interface IPromoService
    {
        Task<Promo> GetPromoByCodeAsync(string code);
        Task<Promo> EndPromoAsync(string code, Guid id);
    }
}
