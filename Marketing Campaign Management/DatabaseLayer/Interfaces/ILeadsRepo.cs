using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DatabaseLayer.Interfaces
{
    public interface ILeadsRepo
    {
        bool AddLeads();

        List<Leads> ViewLeads();

        Leads OneLead();
    }
}
