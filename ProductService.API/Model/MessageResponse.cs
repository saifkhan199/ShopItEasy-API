using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.API.Model
{
    public class MessageResponse <T>
    {
        public string message { get; set; }
        public string information { get; set; }
        public T Data { get; set; }
    }
}
