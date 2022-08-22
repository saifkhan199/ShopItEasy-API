using ProductService.API.Model;
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

        public async Task<string> AddPromo(Promo promo)
        {
            return await _promoRepository.AddPromo(promo);
        }
       
        public async Task<Promo> GetPromoByIdAsync(int id)
        {
            return await _promoRepository.GetPromoByIdAsync(id);
        }

        public async Task<List<Promo>> GetAllPromos()
        {
            return await _promoRepository.GetAllPromos();
        }

        public async Task<int> DeletePromo(int id)
        {
            return await _promoRepository.DeletePromo( id);


        }

        public async Task<int> EditPromo(Promo promo)
        {
            return await _promoRepository.EditPromo(promo);


        }

        public async Task<MessageResponse<User_Promo>> CheckPromo(string code, Guid userId)
        {
            return await _promoRepository.CheckPromo(code, userId);
        }

        public async Task<int> UpdateUserPromo(User_Promo userPromo)
        {
            return await _promoRepository.UpdateUserPromo(userPromo);
        }
    }
}
