using ProductServices.Model;
using ProductServices.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductServices.Services
{
    public class PromoService:IPromoService
    {
        private readonly IPromoRepository _promoRepository;

        public PromoService(IPromoRepository promoRepository)
        {
            _promoRepository = promoRepository;
        }

       
        public async Task<Promo> GetPromoByCodeAsync(string code)
        {
            return await _promoRepository.GetPromoByCodeAsync(code);
        }

        public async Task<Promo> EndPromoAsync(string code, Guid id)
        {
            return await _promoRepository.EndPromoAsync(code, id);


        }
    }
}
