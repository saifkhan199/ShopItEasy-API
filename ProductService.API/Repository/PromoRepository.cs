using Microsoft.EntityFrameworkCore;
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
    }

    
}
