using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.ViewModel
{
    public class UserViewModel
    {
        [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
   
        public Guid UserID { get; set; }

        [Required(ErrorMessage = "This Field is Required !")]
        [DataType(DataType.Text)]

        public string User_Name { get; set; }

        [Required(ErrorMessage = "This Field is Required !")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "This Field is Required !")]
        [DataType(DataType.Password)]
        public string pass { get; set; }

        [Required(ErrorMessage = "This Field is Required !")]
        [DataType(DataType.PhoneNumber)]
        public long Phone { get; set; }

        [Required(ErrorMessage = "This Field is Required !")]
        [DataType(DataType.Text)]
        public string Country { get; set; }

      
        public Boolean isAdmin { get; set; }





    }
}
