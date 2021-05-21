using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Products
    {
        private int _productID;
        public int ProductID
        {
            get{return _productID; }
            set{ _productID = value; }
        }

        private string _productName;
        public string ProductName
        {
            get{return _productName;}
            set{ _productName = value; }
           
        }

        private string _description;
        public string Description
        {
            get{return _description; }
            set{ _description = value;}
        }

        private decimal _unitPrice;
        public decimal UnitPrice
        {
            get{return _unitPrice;}
            set{_unitPrice = value;}
        }
    }
}
