using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductServices.Model
{
    public class CartProduct
    {

       public Guid UserID { get; set; }
        public User User { get; set; }

        public Guid ProductID { get; set; }

       
        public ClothingProduct Product { get; set; }

    }
}
