using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DatabaseLayer.Interfaces
{
    public interface IProductsRepo
    {
        bool AddProducts(Products products);

        List<Products> DisplayProducts();

        Products OneProduct(int pId);

        bool DeleteProduct(int pId);
    }
}
