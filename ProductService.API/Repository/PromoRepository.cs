using Microsoft.EntityFrameworkCore;
using ProductService.API.Model;
using ProductService.Model.Repository;
using ProductServices.Model;
using ProductServices.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductServices.Repository
{
    public class PromoRepository:DataRepository<Promo>,IPromoRepository
    {
        public PromoRepository(ProductContext context) : base(context)
        {
        }

        public async Task<string> AddPromo(Promo promo)
        {
            var promoInDb =await _context.Promos.FirstOrDefaultAsync(p => p.code == promo.code || p.discountPercentage == promo.discountPercentage);
            if (promoInDb == null)
            {
                var response=await AddAsync(promo);
                if (response!=null)
                {
                    return "Promo Added";
                }
            }
            
                return "Promo Already Exists with same Code or Discount !";
            
        }
        public async Task<Promo> GetPromoByIdAsync(int id)
        {
            
            var a =await _context.Promos.FirstOrDefaultAsync(x => x.Id==id);
            return a;
        }
        public async Task<MessageResponse<User_Promo>> CheckPromo(string code, Guid userId)
        {
            MessageResponse<User_Promo> response = new MessageResponse<User_Promo>();

            var promo = await _context.Promos.FirstOrDefaultAsync(p => p.code == code);

            if (promo != null && promo.isActive)
            {
                var data = await _context.user_promo.FirstOrDefaultAsync(p => p.PromoCode == code && p.UserID == userId);
                if (data != null)
                {
                    response.message = "Promo already used !";
                    response.Data = data;
                }
                else
                {
                    if (promo.discountPercentage == "Free-delivery")
                    {
                        response.message = promo.discountPercentage;
                    }
                    else
                    {
                        response.message = "valid";
                        response.information = promo.discountPercentage;
                    }



                }


            }
            else if (promo != null && !promo.isActive )
                response.message = "Promo is expired";
            else
                response.message = "Invalid promo";


            return response;
          
        }
        public async Task<List<Promo>> GetAllPromos()
        {

            var promos = await GetAll().ToListAsync();
            return promos;
        }

        public async Task<int> DeletePromo(int id)
        {
           
                var promo =_context.Set<Promo>().FirstOrDefault(a => a.Id == id);
                promo.isActive = false;
               
                return await _context.SaveChangesAsync();

                
            
        }

        public async Task<int> EditPromo(Promo promo)
        {

            var promoInDb =await _context.Promos.FirstOrDefaultAsync(p => p.Id == promo.Id);
            if (promoInDb!=null)
            {
                promoInDb.code = promo.code;
                promoInDb.discountPercentage = promo.discountPercentage;
                promoInDb.isActive = promo.isActive;
            }
           

            return await _context.SaveChangesAsync();


        }
        public async Task<int> UpdateUserPromo(User_Promo userPromo)
        {
             _context.user_promo.Add(userPromo);
             var result =await _context.SaveChangesAsync();

            return result;
        }
    }

    
}
