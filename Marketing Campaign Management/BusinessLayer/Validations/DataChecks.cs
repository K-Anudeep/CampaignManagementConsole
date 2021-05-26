using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer.Repositories;
using Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BusinessLayer.Validations
{
    public class DataChecks
    {
        CampaignsRepo campaignsRepo = new CampaignsRepo();
        UserRepo userRepo = new UserRepo();
        LeadsRepo leadsRepo = new LeadsRepo();
        ProductRepo productRepo = new ProductRepo();

        public bool CampaignStatusCheck(int cId)
        {
            if (campaignsRepo.OneCampaign(cId) != null)
            {
                if(campaignsRepo.CampaignStatusCheck(cId))
                {
                    return true;
                }    
                else
                {
                    return false;
                }
            }
            else
            {
                throw new Exception("Error: No Campaign with that ID found.");
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
            Leads check = leadsRepo.GetALead(leadID);
            if (check != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SalesLead(int leadID)
        {
            Leads check = leadsRepo.GetALead(leadID);
            if (check != null)
            {
                bool check1 = leadsRepo.CheckLead(leadID);
                if (check1 == true)
                {
                    return true;
                }
                else
                    return false;
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

        //public bool EmailCheck(string email)
        //{
        //    var check = new EmailAddressAttribute();
        //    if (check.IsValid(email))
        //    {
        //        return true;
        //    }
        //    else
        //        return false;
        //}
        public bool EmailCheck(string email)
        {
            string regexEmail = @"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,63}$";
            if (Regex.IsMatch(email.ToString(), regexEmail))
            {
                return true;
            }
            else
                return false;
        }

        public bool PhoneNoCheck(string phone)
        {
            if(Regex.IsMatch(phone.ToString(), @"^(?:(?:\+|0{0,2})91(\s*[\-]\s*)?|[0]?)?[6789]\d{9}$"))
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
