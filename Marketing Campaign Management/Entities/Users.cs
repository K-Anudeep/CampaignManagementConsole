using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Users
    {
        private int _userID;
        public int UserID 
        { 
            get {return _userID; } 
            set {_userID=value;  } 
        }

        private string _fullName; 
        public string FullName
        {
            get {return _fullName; }
            set {_fullName=value;  }
        }

        private string _loginID;
        public string LoginID
        {
            get {return _loginID; }
            set {_loginID=value;  }
        }

        private string _password;
        public string Password
        {
            get {return _password; }
            set {_password=value;  }
        }

        private DateTime _dateOfJoin;
        public DateTime DateOfJoin
        {
            get {return _dateOfJoin; }
            set {_dateOfJoin=value;  }
        }

        private string _address;
        public string Address
        {
            get {return _address; }
            set {_address=value;  }
        }

        private byte _discontinued;
        public byte Discontinued
        {
            get {return _discontinued; }
            set {_discontinued=value;  }
        }

        private byte _isAdmin;
        public byte IsAdmin
        {
            get {return _isAdmin; }
            set {_isAdmin=value;  }
        }

    }
}
