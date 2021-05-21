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

        private string _ProductName;
        public string ProductName
        {
            get{return _ProductName;}
            set{ _ProductName = value; }
           
        }

        private string _Description;
        public string Description
        {
            get{return _Description; }
            set{ _Description = value;}
        }

        private decimal _UnitPrice;
        public decimal UnitPrice
        {
            get{return _UnitPrice;}
            set{_UnitPrice = value;}
        }
    }
}
