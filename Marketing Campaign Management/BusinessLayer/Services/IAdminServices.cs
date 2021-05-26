using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DatabaseLayer.Repositories;

namespace BusinessLayer.Services
{
    public interface IAdminServices
    {
        //PRODUCTS
        bool AddProducts(Products products);

        List<Products> ViewProducts();

        Products OneProduct(int pId);

        bool DeleteProduct(int pId);

        //CAMPAIGN

        bool AddCampaign(Campaigns campaigns);

        bool CloseCampagin(int cId);

        Campaigns OneCampaign(int cId);

        //USERS

        bool AddUser(Users users);

        List<Users> DisplayUsers();

        bool DiscontinueUser();

        Users OneUser();

        //Reports

        List<Leads> ViewLeadByCampaign(int cId);

        List<Campaigns> ViewCampaingByExecutive();

    }
}
