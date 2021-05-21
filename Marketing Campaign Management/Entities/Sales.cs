using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Sales
    {
        private int _orderID;
        public int OrderID 
        { 
            get {return _orderID; } 
            set {_orderID=value;  } 
        }

        private int _leadID; 
        public int LeadID
        {
            get {return _leadID; }
            set {_leadID=value;  }
        }

        private string _shippingAddress;
        public string ShippingAddress
        {
            get {return _shippingAddress; }
            set {_shippingAddress=value;  }
        }

        private string _billingAddress;
        public string BillingAddress
        {
            get {return _billingAddress; }
            set {_billingAddress=value;  }
        }

        private DateTime _createdON;
        public DateTime CreatedON
        {
            get {return _createdON; }
            set {_createdON=value;  }
        }

        private string _paymentMode;
        public string PaymentMode
        {
            get {return _paymentMode; }
            set {_paymentMode=value;  }
        }

    }
}
