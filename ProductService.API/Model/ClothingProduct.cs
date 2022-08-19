using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProductServices.ViewModel;

namespace ProductServices.Model
{
    public class ClothingProduct
    {
        [Key]
      //  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProductID { get; set; }
        public string productName { get; set; }
        public int Quantity { get; set; }
        
        public Guid categoryID { get; set; }
        public string homePageSection { get; set; }
  
        public string description { get; set; }
        
        public string productImage { get; set; }
        public Boolean isDeleted { get; set; }
        public long price { get; set; }

        public string sizes { get; set; }


    }
}
