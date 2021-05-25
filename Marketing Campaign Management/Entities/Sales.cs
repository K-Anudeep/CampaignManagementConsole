using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Sales
    {
        public int OrderID { get; set; }
        public int LeadID { get; set; }
        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }
        public DateTime CreatedON { get; set; }
        public string PaymentMode { get; set; }

    }
}
