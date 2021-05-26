using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class FieldChecks
    {
        public bool StringCheck(string input, out string result)
        {
            if(string.IsNullOrWhiteSpace(input))
            {
                result = null;
                return false;
            }
            else
            {
                result = input;
                return true;
            }
        }
    }
}
