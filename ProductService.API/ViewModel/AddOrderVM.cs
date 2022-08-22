using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProductServices.Model;

namespace ProductServices.ViewModel
{
    public class AddOrderVM
    {

        public class PurchasedItem
        {
            public Guid Id { get; set; }
            public Guid orderID { get; set; }

            public string productID { get; set; }
            public string productName { get; set; }
            public int quantity { get; set; }
            public int itemTotal { get; set; }

            public string size { get; set; }
        }
        public List<PurchasedItem> purchasedItems { get; set; }
       
        public Guid OrderId { get; set; }
        public Guid UserID { get; set; }
     
        public DateTimeOffset Order_Date { get; set; }

        public int gtotal { get; set; }
        public string address { get; set; }
        public long phone { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int postalCode { get; set; }
        public string orderStatus { get; set; }
        public string promocode { get; set; }
        public string discountPercentage { get; set; }
        public int discountedBill { get; set; }

        public string email { get; set; }

        
    }
}
