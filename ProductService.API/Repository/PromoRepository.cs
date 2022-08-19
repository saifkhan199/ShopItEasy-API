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
        public async Task<Promo> GetPromoByCodeAsync(string code)
        {
            
            var a =await _context.Promos.FirstOrDefaultAsync(x => x.code==code && x.isActive==true);
            return a;
        }

        public async Task<Promo>EndPromoAsync(string code, Guid id)
        {
            if (code == "" )
            {
                throw new ArgumentNullException("Promo Code must not be null");
            }
            else
            {
                var promo = _context.Set<Promo>().FirstOrDefault(a => a.code == code);
                promo.isActive = false;
               
                await _context.SaveChangesAsync();

                return promo;
            }
        }
    }

    
}
