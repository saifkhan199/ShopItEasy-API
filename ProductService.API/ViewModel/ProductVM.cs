using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductServices.ViewModel
{
    public class ProductVM
    {
        [Key]
        public Guid ProductID { get; set; }

    
        [Required(ErrorMessage = "This Field is Required !")]
        [DataType(DataType.Text)]
        public Guid CategoryID { get; set; }

        [DataType(DataType.Text)]
        public string homePageSection { get; set; }

        [Required(ErrorMessage = "This Field is Required !")]
        [DataType(DataType.Text)]
        public string ProductName { get; set; }


        [Required(ErrorMessage = "This Field is Required !")]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required(ErrorMessage = "This Field is Required !")]
        [DataType(DataType.Text)]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "This Field is Required !")]
        public string productImage { get; set; }

        [Required(ErrorMessage = "This Field is Required !")]
        [DataType(DataType.Text)]
        public long price { get; set; }

        public Boolean isActive { get; set; }
        public Boolean isDelete { get; set; }

        public string sizes { get; set; }
    }
   
}
