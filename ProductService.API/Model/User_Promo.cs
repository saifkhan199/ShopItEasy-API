using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.API.Model
{
    public class User_Promo
    {
        public Guid Id { get; set; }
        public Guid UserID { get; set; }
        public Guid OrderId { get; set; }
        public string PromoCode { get; set; }

    }
}
