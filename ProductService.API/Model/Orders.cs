using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductServices.Model
{
    public class Orders
    {
        [Key]
        public Guid OrderID { get; set; }

        [ForeignKey("UserID")]
        public Guid? UserID { get; set; }
       
        public DateTimeOffset Order_Date { get; set; }

        public string address { get; set; }
        public string contactNumber { get; set; }

        public string? creditCardNo { get; set; }

        public string? city { get; set; }

        public string? state { get; set; }

        public string? Promocode { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string email { get; set; }

        public int postalCode { get; set; }

        public string discountPercentage { get; set; }

        public int? discountedBill { get; set; }
        public string orderStatus { get; set; }

        public int Amount { get; set; }


    }
}
