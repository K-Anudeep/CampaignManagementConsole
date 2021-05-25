using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Users
    {
        public static int sessionId;

        public int UserID { get; set; }
        public string FullName { get; set; }
        public string LoginID { get; set; }
        public string Password { get; set; }
        public DateTime DateOfJoin { get; set; }
        public string Address { get; set; }
        public byte Discontinued { get; set; }
        public byte IsAdmin { get; set; }

    }
}
