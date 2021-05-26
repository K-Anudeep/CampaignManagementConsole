using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DatabaseLayer.Repositories;
using BusinessLayer.Exceptions;

namespace BusinessLayer.Services
{
    public class AdminServices
    {
        ProductRepo productRepo = null;
        CampaignsRepo campaignsRepo = null;
        UserRepo userRepo = null;

        //PRODUCTS
        public bool AddProducts(Products products)
        {
            try
            {
                productRepo = new ProductRepo();
                bool add = productRepo.AddProducts(products);
                if (add == true)
                {
                    return true;
                }
                else
                    return false;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionLogging.WriteLog(ex);
                return false;
            }
        }

        public List<Products> ViewProducts()
        {
            try
            {
                productRepo = new ProductRepo();
                return productRepo.DisplayProducts();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionLogging.WriteLog(ex);
                return null;
            }
        }

        public Products OneProduct(int pId)
        {
            try
            {
                productRepo = new ProductRepo();
                return productRepo.OneProduct(pId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionLogging.WriteLog(ex);
                return null;
            }
        }

        public bool DeleteProduct(int pId)
        {
            try
            {
                productRepo = new ProductRepo();
                bool add = productRepo.DeleteProduct(pId);
                if (add == true)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionLogging.WriteLog(ex);
                return false;
            }
        }

        //CAMPAIGNS

        public bool AddCampaigns(Campaigns campaigns)
        {
            try
            {
                campaignsRepo = new CampaignsRepo();
                bool add = campaignsRepo.AddCampaign(campaigns);
                if (add == true)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionLogging.WriteLog(ex);
                return false;
            }
        }

        public bool CloseCampaigns(int cId)
        {
            try
            {
                campaignsRepo = new CampaignsRepo();
                bool close = campaignsRepo.CloseCampaign(cId);
                if (close == true)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionLogging.WriteLog(ex);
                return false;
            }
        }

        public Campaigns OneCampaign(int cId)
        {
            try
            {
                CampaignsRepo campaignsRepo= new CampaignsRepo();
                return campaignsRepo.OneCampaign(cId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionLogging.WriteLog(ex);
                return null;
            }
        }
        //Users

        public bool AddUser(Users users)
        {
            try
            {
                userRepo = new UserRepo();
                bool add = userRepo.AddUsers(users);
                if (add == true)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionLogging.WriteLog(ex);
                return false;
            }
        }

        public List<Users> DisplayUsers()
        {
            try
            {
                userRepo = new UserRepo();
                return userRepo.DisplayUsers();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionLogging.WriteLog(ex);
                return null;
            }
        }

        public bool DiscontinueUser(int uId)
        {
            try
            {
                userRepo = new UserRepo();
                bool add = userRepo.DiscontinueUser(uId);
                if (add == true)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionLogging.WriteLog(ex);
                return false;
            }
        }

        public Users OneUser(int uId)
        {
            try
            {
                userRepo = new UserRepo();
                return userRepo.OneUser(uId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionLogging.WriteLog(ex);
                return null;
            }
        }

        //REPORTS

        public List<Leads> ViewLeadByCampaign(int cId)
        {
            try
            {
                LeadsRepo leadsRepo = new LeadsRepo();
                return leadsRepo.ViewLeadsByCampaign(cId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionLogging.WriteLog(ex);
                return null;
            }
        }

        public List<Campaigns> ViewCampaingByExecutive()
        {
            try
            {
                CampaignsRepo campaignsRepo = new CampaignsRepo();
                return campaignsRepo.ViewCampaignsByExec();
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
