using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.ViewModel
{
    public class LoginUserViewModel
    {
        public Guid UserID { get; set; }

        [Required(ErrorMessage = "This Field is Required !")]
        [DataType(DataType.Text)]
        public string Email { get; set; }
        public string User_Name { get; set; }
       
        [Required(ErrorMessage = "This Field is Required !")]
        [DataType(DataType.Password)]
        public string pass { get; set; }

        public Boolean isAdmin { get; set; }
    }
}
