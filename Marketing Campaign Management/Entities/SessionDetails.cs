using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SessionDetails
    {

        private static string _fullName;
        public  string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }

        private static string _loginID;
        public  string LoginID
        {
            get { return _loginID; }
            set { _loginID = value; }
        }
      

        private static byte _isAdmin;
        public  byte IsAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; }
        }

    }
}
