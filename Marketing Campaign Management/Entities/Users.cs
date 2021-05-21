using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Users
    {
        private int _UserID;
        public int UserID 
        { 
            get {return _UserID; } 
            set {_UserID=value;  } 
        }

        private string _FullName; 
        public string FullName
        {
            get {return _FullName; }
            set {_FullName=value;  }
        }

        private string _LoginID;
        public string LoginID
        {
            get {return _LoginID; }
            set {_LoginID=value;  }
        }

        private string _Password;
        public string Password
        {
            get {return _Password; }
            set {_Password=value;  }
        }

        private DateTime _DateOfJoin;
        public DateTime DateOfJoin
        {
            get {return _DateOfJoin; }
            set {_DateOfJoin=value;  }
        }

        private string _Address;
        public string Address
        {
            get {return _Address; }
            set {_Address=value;  }
        }

        private byte _Discontinued;
        public byte Discontinued
        {
            get {return _Discontinued; }
            set {_Discontinued=value;  }
        }

        private byte _IsAdmin;
        public byte IsAdmin
        {
            get {return _IsAdmin; }
            set {_IsAdmin=value;  }
        }

    }
}
