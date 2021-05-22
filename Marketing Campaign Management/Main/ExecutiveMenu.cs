using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using BusinessLayer.Services;

namespace PresentationLayer
{
    class ExecutiveMenu
    {
        ExecutiveService execService = null;
        public ExecutiveMenu()
        {
            bool keepLoop;
            do
            {
                keepLoop = true;
                Console.WriteLine("Select the option that you want to follow with:");
                Console.WriteLine("1.LEADS ");
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
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (keepLoop == true);
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
                        Console.WriteLine("Enter the LeadID to create Sales Order for: ");
                        int leadCheck = Convert.ToInt32(Console.ReadLine());
                        execService = new ExecutiveService();
                        bool statusCheck = execService.CheckLeadStatus(leadCheck);
                        if (statusCheck == true)
                        {
                            //Do it later
                        }
                        break;
                    case 2:
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
            try
            {
                Console.WriteLine("Manage your Leads");
                Console.WriteLine("1. Create Leads: ");
                Console.WriteLine("2. Follow leads: ");
                Console.WriteLine("3. View Leads based on your assigned Campaigns: ");
                Console.WriteLine("3. Back to Main Menu");
                int Leads = int.Parse(Console.ReadLine());
                switch (Leads)
                {
                    case 1:
                        Console.WriteLine("Enter the CampaignID: ");
                        leads.CampaignID = Convert.ToInt32(Console.ReadLine());
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
                        break;
                    case 2:
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
        public void Campaign()
        {
            Campaigns campaign = null;
            try
            {
                Console.WriteLine("choose view campagin options");
                Console.WriteLine("1. view campaign");
                Console.WriteLine("2. go back to main menu");
                Console.WriteLine();
                int Campaign = int.Parse(Console.ReadLine());
                switch (Campaign)
                {
                    case 1:
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
