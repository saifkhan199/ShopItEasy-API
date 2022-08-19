using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.API.Model
{
    public class OrderStatus
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
    }
}
