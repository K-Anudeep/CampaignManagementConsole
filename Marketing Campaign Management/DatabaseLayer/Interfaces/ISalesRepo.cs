using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DatabaseLayer.Interfaces
{
    public interface ISalesRepo
    {
        bool CreateSales(Sales sales);

        List<Sales> ViewSales();
    }
}
