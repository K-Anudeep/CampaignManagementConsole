using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Products
    {
       private int _productid
            public int ProductID
        {
            get
            {
                return _productid;
            }
            set 
            {
                _productid = value;
            }
        }
            
        private string _productname
                public string ProductName
        {
            get
            {
                return _productname;
            }
            set 
            {
                _productname = value;
            }
        }
        private string _description
                public string Description
        {
            get
            {
                return _description;
            }
            set 
            {
                _description = value;
            }
        }
        private decimal _unitprice
            public decimal UnitPrice
        {
            get
            {
                return _unitprice;
            }
            set 
            {
                _unitprice = value;
            }
        }
    }
}
