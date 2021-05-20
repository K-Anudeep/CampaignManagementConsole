using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Users
    {
       public int UserID { get; set; }
       public String FullName { get; set; }
       public String LoginID { get; set; }
       public String Password { get; set; }
       public DateTime DateOfJoin { get; set; }
       public String Address { get; set; }
       public Byte Discontinued { get; set; }
       public Byte IsAdmin { get; set; }
   
    }
}
