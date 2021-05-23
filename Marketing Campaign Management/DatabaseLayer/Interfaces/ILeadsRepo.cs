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
        bool AddLeads(Leads leads);

        List<Leads> ViewLeadsToExec();

        List<Leads> ViewLeadsByCampaign(int cId);

        Leads GetALead(int leadID);

        bool FollowLead(int leadID, string newStatus);
    }
}
