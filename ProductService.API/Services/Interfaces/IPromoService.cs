using ProductService.API.Model;
using ProductServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductServices.Services
{
    public interface IPromoService
    {
        Task<string> AddPromo(Promo promo);
        Task<Promo> GetPromoByIdAsync(int id);
        Task<int> DeletePromo(int id);
        Task<MessageResponse<User_Promo>> CheckPromo(string code, Guid userId);
        Task<int> UpdateUserPromo(User_Promo userPromo);
        Task<int> EditPromo(Promo promo);
        Task<List<Promo>> GetAllPromos();

        
    }
}
