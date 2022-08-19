using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductServices.Model
{
    public class Cart
    {
        [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CartID { get; set; }
        public Guid UserID { get; set; }
        public User User { get; set; }
        public int NoOfItem { get; set; }



    }
}
