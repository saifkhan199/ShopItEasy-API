using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductServices.Model
{
    public class Category
    {
        [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }

        public Boolean isActive { get; set; }
        
    }
}
