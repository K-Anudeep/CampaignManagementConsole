using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer.Repositories;
using Entities;

namespace BusinessLayer.Validations
{
    public class DataChecks
    {
        CampaignsRepo campaignsRepo = new CampaignsRepo();
        UserRepo userRepo = new UserRepo();
        LeadsRepo leadsRepo = new LeadsRepo();
        ProductRepo productRepo = new ProductRepo();

        public bool CampaignStatusCheck(int leadID)
        {
            bool check = campaignsRepo.CampaignStatusCheck(leadID);
            if(check == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckCampaign(int cId)
        {
            if (campaignsRepo.OneCampaign(cId) != null)
            {
                return true;
            }
            else
                return false;
        }

        public bool CheckUser(int userID)
        {
            Users check = userRepo.OneUser(userID);
            if (check != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckLead(int leadID)
        {
            bool check = leadsRepo.CheckLead(leadID);
            if (check == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckProduct(int productID)
        {
            Products check = productRepo.OneProduct(productID);
            if (check != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AdminCheck(int userID)
        {
            //To check if user is Admin
            Users check = userRepo.OneUser(userID);
            if (check.IsAdmin == 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
