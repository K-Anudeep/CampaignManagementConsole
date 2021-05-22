using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DatabaseLayer;

namespace BusinessLayer.Validations
{
    public class LoginCheck
    {
        public bool Validation()
        { 
            try
            {
                throw new NotImplementedException();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
