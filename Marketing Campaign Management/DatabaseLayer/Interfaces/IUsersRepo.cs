using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DatabaseLayer.Interfaces
{
    public interface IUsersRepo
    {
        bool AddUsers(Users user);

        List<Users> DisplayUsers();

        Users OneUser(int uId);

        bool DiscontinueUser(int uId);
    }
}
