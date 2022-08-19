
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProductServices.Model;
using ProductServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class PromoController
    {

        private readonly IPromoService _promoService;

        public PromoController(IPromoService promoService)

        {
            _promoService = promoService;

        }

        [HttpPost("addPromo")]
        public async Task<string> AddPromo([FromBody] Promo promo)
        {
            if (promo != null)
                return await _promoService.AddPromo(promo);
            else
                return "Promo value is null";
        }

        [HttpGet("{id}")]
        public async Task<Promo> GetPromoByIdAsync(int id)
        {
            try
            {

                var response =await _promoService.GetPromoByIdAsync(id);

                if (response == null)
                {
                    return null;
                }
                else
                    return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet("getAllPromos")]
        public async Task<List<Promo>> GetAllPromos()
        {
            try
            {

                var response = await _promoService.GetAllPromos();

                if (response == null)
                {
                    return null;
                }
                else
                    return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        [HttpPut("deletePromo/{id}")]
        public async Task<int> DeletePromo(int id)
        {
               
             return await _promoService.DeletePromo(id);
         
        }

        [HttpPut("EditPromo")]
        public async Task<int> EditPromo(Promo promo)
        {

            return await _promoService.EditPromo(promo);

        }
    }
}
