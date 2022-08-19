using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.ViewModel
{
    public class ChangePasswordViewModel
    {
        public string email { get; set; }
        public string? oldPassword { get; set; }
        public string newPassword { get; set; }
    }
}
