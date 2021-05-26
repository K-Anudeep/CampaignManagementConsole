using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DatabaseLayer.Repositories;
using BusinessLayer.Exceptions;

namespace BusinessLayer.Validations
{
    public class AccessCheck
    {
        public bool Validation(string loginID, string password)
        {
            try
            {
                Sessions validation = new Sessions();
                bool valid = validation.DbValidation(loginID,password);
                if (valid == true)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionLogging.WriteLog(ex);
                return false;
            }
        }

        public bool AdminCheck()
        {
            try
            {
                SessionDetails session = new SessionDetails();
                Sessions adminCheck = new Sessions();
                bool check = adminCheck.DbAdminCheck(session);
                if (check == true)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionLogging.WriteLog(ex);
                return false;
            }
        }
    }
}
