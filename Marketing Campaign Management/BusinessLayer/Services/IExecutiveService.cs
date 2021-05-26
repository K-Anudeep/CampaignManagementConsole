using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DatabaseLayer.Repositories;

namespace BusinessLayer.Services
{
    public interface IExecutiveService
    {
        bool AddSales(Sales sales);

        List<Sales> ViewSales();

        bool AddLeads(Leads leads);

        bool CheckLead(int leadID);

        bool CampaignStatusCheck(int cID);

        bool FollowLead(int lID, string newStatus);

        List<Leads> ViewLeads();

        List<Campaigns> ViewCampaignsAssigned();

    }
}
