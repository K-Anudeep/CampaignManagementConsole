using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product    // creating product class
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
