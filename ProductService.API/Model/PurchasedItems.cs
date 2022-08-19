using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.API.Model
{
    public class PurchasedItems
    {
        public Guid Id { get; set; }
        public Guid orderID { get; set; }

        public string productID { get; set; }
        public string productName { get; set; }
        public int quantity { get; set; }
        public int itemTotal { get; set; }

        public string size { get; set; }
    }
}
