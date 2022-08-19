using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductServices.ViewModel
{
    public class CategoryVM
    {
        [Key]
       
        public Guid CategoryID { get; set; }
        [Required(ErrorMessage = "This Field is Required !")]
        [DataType(DataType.Text)]
        public string Category_Name { get; set; }

        public Boolean isActive { get; set; }
        public Boolean isDelete { get; set; }
    }
}
