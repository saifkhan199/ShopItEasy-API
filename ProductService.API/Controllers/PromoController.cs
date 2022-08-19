
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


        [HttpGet("{code}")]
        public async Task<Promo> GetPromoByCodeAsync(string code)
        {
            try
            {

                var response =await _promoService.GetPromoByCodeAsync(code);

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

        [HttpPut("endPromo/{code}/{id}")]
        public async Task<Promo> endPromo(string code, Guid id)
        {
            if (code== null)
            {
                return null;
            }
            else
            {
               
                return await _promoService.EndPromoAsync(code, id);
            }
        }
    }
}
