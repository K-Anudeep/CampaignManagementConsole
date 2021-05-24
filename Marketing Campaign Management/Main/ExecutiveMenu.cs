using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using BusinessLayer.Services;
using DatabaseLayer.Repositories;

namespace PresentationLayer
{
    class ExecutiveMenu
    {
        ExecutiveService execService = null;
        public ExecutiveMenu()
        {
            try
            {
                bool keepLoop;
                do
                {
                    keepLoop = true;
                    Console.WriteLine("Select the option that you want to follow with:");
                    Console.WriteLine("1.LEADS");
                    Console.WriteLine("2.SALES");
                    Console.WriteLine("3.VIEW CAMPAIGN");
                    Console.WriteLine("4.LOGOUT");
                    Console.WriteLine("");
                    Console.WriteLine("Enter your option");
                    int Options = int.Parse(Console.ReadLine());
                    switch (Options)
                    {
                        case 1:
                            Leads();
                            break;
                        case 2:
                            Sales();
                            break;
                        case 3:
                            Campaign();
                            break;
                        case 4:
                            Console.WriteLine("Successfully Logged Out!");
                            keepLoop = false;
                            break;
                        default:
                            Console.WriteLine("--------------------------------------------------------------------------");
                            Console.WriteLine("Invalid Choice");
                            Console.WriteLine("--------------------------------------------------------------------------");
                            break;
                    }
                } while (keepLoop == true);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Sales()
        {
            try
            {
                Console.WriteLine("Choose: ");
                Console.WriteLine("1. Create a sales order");
                Console.WriteLine("2. View sales orders");
                Console.WriteLine("3. Go Back");
                int sales = int.Parse(Console.ReadLine());
                switch (sales)
                {
                    case 1:
                        Sales salesData = new Sales();
                        Console.WriteLine("Enter the LeadID to create Sales Order for: ");
                        int leadCheck = Convert.ToInt32(Console.ReadLine());
                        execService = new ExecutiveService();
                        bool statusCheck = execService.CheckLead(leadCheck);
                        if (statusCheck == true)
                        {
                            salesData.LeadID = leadCheck;
                            Console.WriteLine("Enter the Shipping Address: ");
                            salesData.ShippingAddress = Console.ReadLine();
                            Console.WriteLine("Is your billing address the same as shipping address? 1.Yes 2. No");
                            int same = Convert.ToInt32(Console.ReadLine());
                            if(same == 1)
                            {
                                salesData.BillingAddress = salesData.ShippingAddress;
                            }
                            else if(same == 2)
                            {
                                Console.WriteLine("Enter the Billing Address: ");
                                salesData.BillingAddress = Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("--------------------------------------------------------------------------");
                                Console.WriteLine("Choose the correct option!");
                                Console.WriteLine("--------------------------------------------------------------------------");
                            }
                            Console.WriteLine("Enter your Payment Mode: 1. Prepaid 2. COD(Cash on Delivery)");
                            int payment = Int32.Parse(Console.ReadLine());
                            if (payment == 1)
                            {
                                salesData.PaymentMode = "Prepaid";
                            }
                            else if (payment == 2)
                            {
                                salesData.PaymentMode = "COD";
                            }
                            else
                            {
                                Console.WriteLine("--------------------------------------------------------------------------");
                                Console.WriteLine("Choose the correct option!");
                                Console.WriteLine("--------------------------------------------------------------------------");
                            }

                            bool addSales = execService.AddSales(salesData);
                            if (addSales == true)
                            {
                                Console.WriteLine("Added!");
                            }
                            else
                            {
                                Console.WriteLine("--------------------------------------------------------------------------");
                                Console.WriteLine("Adding Failed");
                                Console.WriteLine("--------------------------------------------------------------------------");
                            }
                        }
                        else
                        {
                            Console.WriteLine("--------------------------------------------------------------------------");
                            Console.WriteLine("Status of the given Lead is New or Lost, cannot proceed with Sales Order");
                            Console.WriteLine("--------------------------------------------------------------------------");
                        }
                        break;
                    case 2:
                        List<Sales> viewSales = new List<Sales>();
                        execService = new ExecutiveService();
                        viewSales = execService.ViewSales();
                        if (viewSales != null)
                        {
                            foreach (Sales s in viewSales)
                            {
                                Console.WriteLine($"Order ID: {s.OrderID}, Lead ID: {s.LeadID}, Shipping Address: {s.ShippingAddress}, Billing Address: {s.BillingAddress}, Created Sales On: {s.CreatedON}, Payment Mode: {s.PaymentMode} ");
                                Console.WriteLine("--------------------------------------------------------------------------");
                            }
                        }
                        else
                        {
                            Console.WriteLine("--------------------------------------------------------------------------");
                            Console.WriteLine("No Sales to display!");
                            Console.WriteLine("--------------------------------------------------------------------------");
                        }
                        break;
                    case 3:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Leads()
        {
            Leads leads = new Leads();
            CampaignsRepo campaignsRepo = new CampaignsRepo();
            try
            {
                Console.WriteLine("Manage your Leads");
                Console.WriteLine("1. Create Leads: ");
                Console.WriteLine("2. Follow leads: ");
                Console.WriteLine("3. View Leads based on your assigned Campaigns: ");
                Console.WriteLine("4. Back to Main Menu");
                int Leads = int.Parse(Console.ReadLine());
                switch (Leads)
                {
                    case 1:
                        Console.WriteLine("Enter the CampaignID: ");
                        leads.CampaignID = Convert.ToInt32(Console.ReadLine());
                        bool campCheck = campaignsRepo.CampaignStatusCheck(leads.CampaignID);
                        if (campCheck == true)
                        {
                            Console.WriteLine("Enter the Consumer Name: ");
                            leads.ConsumerName = Console.ReadLine();
                            Console.WriteLine("Enter Email Address: ");
                            leads.EmailAddress = Console.ReadLine();
                            Console.WriteLine("Enter Phone Number: ");
                            leads.PhoneNo = Console.ReadLine();
                            Console.WriteLine("Enter your preffered Mode of Contact: 1. Email 2. Phone ");
                            int moc = Convert.ToInt32(Console.ReadLine());
                            if (moc == 1)
                            {
                                leads.PreferredMoC = "Email";
                            }
                            else if (moc == 2)
                            {
                                leads.PreferredMoC = "Phone";
                            }
                            else
                            {
                                leads.PreferredMoC = "Email";
                                Console.WriteLine("Wrong Option: Defaulted to Email as the primary Mode of Contact.");
                            }
                            Console.WriteLine("Enter Date Approached by Consumer(YYYY-MM-DD): ");
                            leads.DateApproached = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("Enter Product ID: ");
                            leads.ProductID = Int32.Parse(Console.ReadLine());
                            execService = new ExecutiveService();
                            bool addLeads = execService.AddLeads(leads);
                            if (addLeads == true)
                            {
                                Console.WriteLine("Added new Lead!");
                            }
                            else
                            {
                                Console.WriteLine("--------------------------------------------------------------------------");
                                Console.WriteLine("Failed to add new lead");
                                Console.WriteLine("--------------------------------------------------------------------------");

                            }
                        }
                        else
                        {
                            Console.WriteLine("--------------------------------------------------------------------------");
                            throw new Exception("Error Campaign Not Assigned to you or Campaign is Closed!");
                            Console.WriteLine("--------------------------------------------------------------------------");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter a LeadID: ");
                        int leadId = Convert.ToInt32(Console.ReadLine());
                        execService = new ExecutiveService();
                        bool leadCheck = execService.CheckLead(leadId);
                        if(leadCheck == true)
                        {
                            Console.WriteLine("How do you want to follow up with this Lead? 1. Won 2. Lost");
                            int followUp = Convert.ToInt32(Console.ReadLine());
                            if(followUp == 1)
                            {
                                string newStatus = "Won";
                                bool follow = execService.FollowLead(leadId, newStatus);
                                if (follow == true)
                                {
                                    Console.WriteLine("Status Updated!");
                                }
                                else
                                    Console.WriteLine("Status update failed!");
                            }
                            else if(followUp == 2)
                            {
                                string newStatus = "Lost";
                                bool follow = execService.FollowLead(leadId, newStatus);
                                if (follow == true)
                                {
                                    Console.WriteLine("Status Updated!");
                                }
                                else
                                    Console.WriteLine("Status update failed!");
                            }
                            else
                            {
                                Console.WriteLine("Wrong option.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("--------------------------------------------------------------------------");
                            Console.WriteLine("Specified Lead ID does not exist!");
                            Console.WriteLine("--------------------------------------------------------------------------");
                        }
                        break;
                    case 3:
                        List<Leads> viewLeads = new List<Leads>();
                        execService = new ExecutiveService();
                        viewLeads = execService.ViewLeads();
                        if (viewLeads != null)
                        {
                            foreach (Leads l in viewLeads)
                            {
                                Console.WriteLine($"Lead ID: {l.LeadID}, Campaign ID: {l.CampaignID}, Consumer Name: {l.ConsumerName}, Email Address: {l.EmailAddress}, PhoneNo: {l.PhoneNo}");
                                Console.WriteLine($"Preferred Mode if Contact: {l.PreferredMoC}, Date Approached: {l.DateApproached}, Product ID: {l.ProductID}, Status: {l.Status}");
                                Console.WriteLine("--------------------------------------------------------------------------");
                            }
                        }
                        else
                        {
                            Console.WriteLine("--------------------------------------------------------------------------");
                            Console.WriteLine("No leads to display!");
                            Console.WriteLine("--------------------------------------------------------------------------");
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Campaign()
        {
            try
            {
                Console.WriteLine("Campaigns");
                Console.WriteLine("1. View assigned Campaigns");
                Console.WriteLine("2. Back to the previous menu.");
                Console.WriteLine();
                int Campaign = int.Parse(Console.ReadLine());
                switch (Campaign)
                {
                    case 1:
                        List<Campaigns> viewCampaigns = new List<Campaigns>();
                        execService = new ExecutiveService();
                        viewCampaigns = execService.ViewCampaignsAssigned();
                        if (viewCampaigns != null)
                        {
                            foreach (Campaigns c in viewCampaigns)
                            {
                                    Console.WriteLine($"Campaign ID: {c.CampaignID}, Name: {c.Name}, Venue: {c.Venue}, AssignedTo: {c.AssignedTo}, " +
                                    $"Started ON: {c.StartedOn}, Completed ON: TBD, Status: {c.IsOpen}");
                                Console.WriteLine("--------------------------------------------------------------------------");
                            }
                        }                        
                        else
                        {
                            Console.WriteLine("--------------------------------------------------------------------------");
                            Console.WriteLine("No Campaigns to display!");
                            Console.WriteLine("--------------------------------------------------------------------------");
                        }

                        break;
                    case 2:
                        break;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
