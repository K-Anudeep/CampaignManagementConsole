using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DatabaseLayer.Repositories;

namespace PresentationLayer
{
    class AdminMenu
    {

        public AdminMenu()
        {
            try
            {
                Console.WriteLine("Welcome ");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
