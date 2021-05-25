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
    }
}
