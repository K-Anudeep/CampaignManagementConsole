﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Entities;
using BusinessLayer.Services;
using BusinessLayer.Validations;
using ConsoleTables;
using System.IO;
using BusinessLayer.Exceptions;

namespace PresentationLayer
{
    class ExecutiveMenu
    {
        ExecutiveService execService = null;
        DataChecks dataChecks = null;
        ExceptionLogging exceptionLogging = null;

        public ExecutiveMenu()
        {
            ExecMenu:
            try
            {
                bool keepLoop;
                do
                {
                    keepLoop = true;
                    Console.WriteLine("--------------------------------------------------------------------------");
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
                            throw new Exception("IncorrectOptionError");
                    }
                } while (keepLoop == true);
            }
            catch (Exception ex) when (ex.Message == "IncorrectOptionError")
            {
                using (StreamWriter w = File.AppendText("log.txt"))
                {
                    exceptionLogging = new ExceptionLogging(ex.Message, w, ex.ToString());
                }
                goto ExecMenu;
            }
            catch (Exception ex)
            {
                using (StreamWriter w = File.AppendText("log.txt"))
                {
                    exceptionLogging = new ExceptionLogging(ex.Message, w, ex.ToString());
                }
                goto ExecMenu;
            }
        }

        public void Sales()
        {
            SalesMenu:
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
                        bool statusCheck = dataChecks.CheckLead(leadCheck);
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
                            var salesTable = new ConsoleTable("Order ID", "Lead ID ", "Shipping Address ", "Billing Address", " Created Sales On","Payment Mode");
                            foreach (Sales s in viewSales)
                            {
                                salesTable.AddRow(s.OrderID, s.LeadID, s.ShippingAddress, s.BillingAddress, s.CreatedON.ToString("d"), s.PaymentMode);
                            }
                            salesTable.Write(Format.Alternative);
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
                    default:
                        Console.WriteLine("--------------------------------------------------------------------------");
                        Console.WriteLine("Please enter from the given options.");
                        Console.WriteLine("--------------------------------------------------------------------------");
                        throw new Exception("IncorrectOptionError");
                }
            }
            catch (Exception ex) when (ex.Message == "IncorrectOptionError")
            {
                using (StreamWriter w = File.AppendText("log.txt"))
                {
                    exceptionLogging = new ExceptionLogging(ex.Message, w, ex.ToString());
                }
                goto SalesMenu;
            }
            catch (Exception ex)
            {
                using (StreamWriter w = File.AppendText("log.txt"))
                {
                    exceptionLogging = new ExceptionLogging(ex.Message, w, ex.ToString());
                }
                goto SalesMenu;
            }
        }
        public void Leads()
        {
            LeadsMenu:
            Leads leads = new Leads();
            dataChecks = new DataChecks();
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
                        bool campCheck = dataChecks.CampaignStatusCheck(leads.CampaignID);
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
                            Console.WriteLine("Enter Date Approached by Consumer(dd-MM-YYYY): ");
                            string dateLine = Console.ReadLine();
                            DateTime date;
                            while(!DateTime.TryParseExact(dateLine,"dd-MM-yyyy",null,DateTimeStyles.None, out date))
                            {
                                Console.WriteLine("Please enter a valid date in the given format.");
                                Console.WriteLine("Enter Date: ");
                                dateLine = Console.ReadLine();
                            }
                            leads.DateApproached = date;
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
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter a LeadID: ");
                        int leadId = Convert.ToInt32(Console.ReadLine());
                        execService = new ExecutiveService();
                        bool leadCheck = dataChecks.CheckLead(leadId);
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
                            var leadsTable = new ConsoleTable("Lead ID ", "Campaign ID  ", "Consumer Name ", "  Email Address", "PhoneNo", "Preferred Mode if Contact", " Date Approached", "Product ID","Status");
                            foreach (Leads l in viewLeads)
                            {
                                leadsTable.AddRow( l.LeadID, l.CampaignID, l.ConsumerName, l.EmailAddress, l.PhoneNo, l.PreferredMoC,l.DateApproached.ToString("d"), l.ProductID, l.Status);
                            }
                            leadsTable.Write(Format.Alternative);
                        }
                        else
                        {
                            Console.WriteLine("--------------------------------------------------------------------------");
                            Console.WriteLine("No leads to display!");
                            Console.WriteLine("--------------------------------------------------------------------------");
                        }
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("--------------------------------------------------------------------------");
                        Console.WriteLine("Please enter from the given options.");
                        Console.WriteLine("--------------------------------------------------------------------------");
                        throw new Exception("IncorrectOptionError");
                }
            }
            catch (Exception ex) when (ex.Message == "IncorrectOptionError")
            {
                using (StreamWriter w = File.AppendText("log.txt"))
                {
                    exceptionLogging = new ExceptionLogging(ex.Message, w, ex.ToString());
                }
                goto LeadsMenu;
            }
            catch (Exception ex)
            {
                using (StreamWriter w = File.AppendText("log.txt"))
                {
                    exceptionLogging = new ExceptionLogging(ex.Message, w, ex.ToString());
                }
                goto LeadsMenu;
            }
        }
        public void Campaign()
        {
            CampaignMenu:
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
                            var campaignTable = new ConsoleTable("Assigned Executives", "Campaign ID", "Name", "Venue", "Started On", "Completed On", "Status");
                            foreach (Campaigns c in viewCampaigns)
                            {
                                campaignTable.AddRow(c.AssignedTo, c.CampaignID, c.Name, c.Venue, c.StartedOn.ToString("d"),c.CompletedOn.ToString("d"), c.IsOpen);
                            }
                            campaignTable.Write(Format.Alternative);
                            Console.WriteLine("");
                            Console.WriteLine("Note: Campaign Default duration is set to 7 days. Date gets updated upon closing the campaign.");
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
                    default:
                        Console.WriteLine("--------------------------------------------------------------------------");
                        Console.WriteLine("Please enter from the given options.");
                        Console.WriteLine("--------------------------------------------------------------------------");
                        throw new Exception("IncorrectOptionError");
                }

            }
            catch (Exception ex) when (ex.Message == "IncorrectOptionError")
            {
                using (StreamWriter w = File.AppendText("log.txt"))
                {
                    exceptionLogging = new ExceptionLogging(ex.Message, w, ex.ToString());
                }
                goto CampaignMenu;
            }
            catch (Exception ex)
            {
                using (StreamWriter w = File.AppendText("log.txt"))
                {
                    exceptionLogging = new ExceptionLogging(ex.Message, w, ex.ToString());
                }
                goto CampaignMenu;
            }
        }
    }
}
