using ProductService.API.Model;
using ProductServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductServices.Repository.Interface
{
    public interface IPromoRepository
    {
        Task<string> AddPromo(Promo promo);
        Task<Promo> GetPromoByIdAsync(int id);
        Task<int> DeletePromo(int id);
        Task<int> EditPromo(Promo promo);

        Task<MessageResponse<User_Promo>> CheckPromo(string code, Guid userId);
        Task<int> UpdateUserPromo(User_Promo userPromo);
        Task<List<Promo>> GetAllPromos();
    }
}
