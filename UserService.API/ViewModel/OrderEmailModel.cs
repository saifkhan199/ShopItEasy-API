using System;
using System.Collections.Generic;


namespace UserService.ViewModel
{
    public class OrderEmailModel
    {
       
        public Guid OrderId { get; set; }
        public Guid UserID { get; set; }
        public string subject { get; set; }

        public List<string> emailRecipients { get; set; }

        public DateTime Order_Date { get; set; }

        public int gtotal { get; set; }
        public string address { get; set; }
        public long phone { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int postalCode { get; set; }
        public bool isApproved { get; set; }
        public string promocode { get; set; }
        public int discountPercentage { get; set; }
        public int discountedBill { get; set; }

        
    }
}
