using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DatabaseLayer;

namespace BusinessLayer
{
    public interface IAdminMenu
    {
        bool AddProducts(Products products);

        List<Products> DisplayProducts();

        Products OneProduct(int pId);

        bool DeleteProduct(int pId);

        bool AddCampaign(Campaigns campaign);

        List<Campaigns> ViewCampaigns();

        bool CloseCampaign(int cId);

        bool AddUsers(Users user);

        List<Users> DisplayUsers();

        Users OneUser(int uId);

        bool DiscontinueUser(int uId);

        List<Leads> ViewLeads();

        Leads GetALead(int LeadID);


    }
}
