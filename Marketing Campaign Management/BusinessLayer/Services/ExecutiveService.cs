using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer.Repositories;
using BusinessLayer.Exceptions;
using Entities;

namespace BusinessLayer.Services
{
    public class ExecutiveService
    {
        LeadsRepo leadsRepo = null;
        CampaignsRepo campaignsRepo = null;
        SalesRepo salesRepo = null;

        //LEADS

        public bool AddLeads(Leads leads)
        {
            try
            {
                leadsRepo = new LeadsRepo();
                bool addleads = leadsRepo.AddLeads(leads);
                if (addleads == true)
                    return true;
                else
                    return false;
            }
            catch(Exception ex)
            {
                ExceptionLogging.WriteLog(ex);
                throw ex;
            }
        }

        public bool FollowLead(int lID, string newStatus)
        {
            try
            {
                leadsRepo = new LeadsRepo();
                bool follow = leadsRepo.FollowLead(lID, newStatus);
                if (follow == true)
                {
                    return true;
                }
                else
                    return false;
            }
            catch(Exception ex)
            {
                ExceptionLogging.WriteLog(ex);
                throw ex;
            }
        }

        public bool CheckLead(int leadID)
        {
            try
            {
                leadsRepo = new LeadsRepo();
                Leads check = leadsRepo.GetALead(leadID);
                if (check != null)
                {
                    return true;
                }
                else
                    return false;
            }
            catch(Exception ex)
            {
                ExceptionLogging.WriteLog(ex);
                throw ex;
            }
        }

        public List<Leads> ViewLeads()
        {
            try
            {
                leadsRepo = new LeadsRepo();
                return leadsRepo.ViewLeadsToExec();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionLogging.WriteLog(ex);
                return null;
            }
        }


        //CAMPAIGNS
        

        public List<Campaigns> ViewCampaignsAssigned()
        {
            try
            {
                campaignsRepo = new CampaignsRepo();
                return campaignsRepo.ViewCampaignsByAssigned();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionLogging.WriteLog(ex);
                return null;
            }

        }


        //SALES

        public bool AddSales(Sales sales)
        {
            try
            {
                salesRepo = new SalesRepo();
                bool add = salesRepo.CreateSales(sales);
                if(add == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionLogging.WriteLog(ex);
                return false;
            }
        }

        public List<Sales> ViewSales()
        {
            try
            {
                salesRepo = new SalesRepo();
                return salesRepo.ViewSales();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionLogging.WriteLog(ex);
                return null;
            }

        }

    }
}
