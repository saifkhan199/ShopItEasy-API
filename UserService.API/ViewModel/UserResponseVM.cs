using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.API.ViewModel
{
    public class UserResponseVM
    {
        public string name {get;set;}
        public string email { get; set; }
        public string subject { get; set; }
        public int phone { get; set; }
        public string message { get; set; }

        public List<string> recipients { get; set; }

    }
}
