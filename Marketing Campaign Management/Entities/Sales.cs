using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Sales
    {
        private int _OrderID;
        public int OrderID 
        { 
            get {return _OrderID; } 
            set {_OrderID=value;  } 
        }

        private int _LeadID; 
        public int LeadID
        {
            get {return _LeadID; }
            set {_LeadID=value;  }
        }

        private string _ShippingAddress;
        public string ShippingAddress
        {
            get {return _ShippingAddress; }
            set {_ShippingAddress=value;  }
        }

        private string _BillingAddress;
        public string BillingAddress
        {
            get {return _BillingAddress; }
            set {_BillingAddress=value;  }
        }

        private DateTime _CreaterON;
        public DateTime CreaterON
        {
            get {return _CreaterON; }
            set {_CreaterON=value;  }
        }

        private string _PaymentMode;
        public string PaymentMode
        {
            get {return _PaymentMode; }
            set {_PaymentMode=value;  }
        }

    }
}
