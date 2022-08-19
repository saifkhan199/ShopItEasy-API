using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductServices.ViewModel
{
    public class Promo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string code { get; set; }
        public Boolean isActive { get; set; }
        //public Guid? usedBy { get; set; }

        public string discountPercentage { get; set; }
    }
}
