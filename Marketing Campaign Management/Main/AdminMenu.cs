using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using BusinessLayer.Services;
using BusinessLayer.Validations;
using ConsoleTables;
using System.IO;
using BusinessLayer.Exceptions;

namespace PresentationLayer
{
    class AdminMenu
    {
        AdminServices adminServices = null;
        DataChecks dataChecks = null;
        ExceptionLogging exceptionLogging = null;
        public AdminMenu()
        {   
            AdminMenu:
            try
            {
                bool keepLoop;
                do
                {
                    keepLoop = true;
                    Console.WriteLine("--------------------------------------------------------------------------");
                    Console.WriteLine("1.Manage Products");
                    Console.WriteLine("2.Manage Campaigns");
                    Console.WriteLine("3.Manage Users");
                    Console.WriteLine("4.Manage Reports");
                    Console.WriteLine("5.Logout");
                    Console.WriteLine("");
                    Console.WriteLine("Enter your option");
                    int Options = 0;
                    while (!int.TryParse(Console.ReadLine(), out Options))
                    {
                        Console.WriteLine("Please Enter a valid numerical value!");
                        Console.WriteLine("Enter your option: ");
                    }
                    switch (Options)
                    {
                        case 1:
                            Products();
                            break;
                        case 2:
                            Campaigns();
                            break;
                        case 3:
                            Users();
                            break;
                        case 4:
                            Reports();
                            break;
                        case 5:
                            Console.WriteLine("Successfully Logged Out!");
                            keepLoop = false;
                            break;
                        default:
                            Console.WriteLine("--------------------------------------------------------------------------");
                            Console.WriteLine("Please enter from the given options.");
                            Console.WriteLine("--------------------------------------------------------------------------");
                            throw new Exception("IncorrectOptionError");
                    }
                } while (keepLoop == true);


            }
            catch(Exception ex) when (ex.Message == "IncorrectOptionError")
            {
                using (StreamWriter w = File.AppendText("log.txt"))
                {
                    exceptionLogging = new ExceptionLogging(ex.Message, w, ex.ToString());
                }
                goto AdminMenu;
            }
            catch (Exception ex)
            {
                using (StreamWriter w = File.AppendText("log.txt"))
                {
                    exceptionLogging = new ExceptionLogging(ex.Message, w, ex.ToString());
                }
                goto AdminMenu;
            }            
        }
        public void Products()
        {
            ProductMenu:
            try
            {
                adminServices = new AdminServices();
                dataChecks = new DataChecks();
                Console.WriteLine("Choose fromt he following: ");
                Console.WriteLine("1.To Add Product");
                Console.WriteLine("2.To Display Product");
                Console.WriteLine("3.To Display a specific Product");
                Console.WriteLine("4.To Delete a Product");
                Console.WriteLine("5. Back to Main menu");
                int Products = 0;
                while (!int.TryParse(Console.ReadLine(), out Products))
                {
                    Console.WriteLine("Please Enter a valid numerical value!");
                    Console.WriteLine("Enter your option: ");
                }
                switch (Products)
                {
                    case 1:
                        Products Product = new Products();
                        Console.WriteLine("Enter Product Name:");
                        string ProName = Console.ReadLine();
                        Console.WriteLine("Give Product Description:");
                        string ProDesc = Console.ReadLine();
                        Console.WriteLine("Enter Unit Price of the Product:");
                        decimal ProUnitPrice = 0;
                        while (!decimal.TryParse(Console.ReadLine(), out ProUnitPrice))
                        {
                            Console.WriteLine("Please Enter a valid numerical value!");
                            Console.WriteLine("Enter Unit Price of the Product:");
                        }
                        Product.ProductName = ProName;
                        Product.Description = ProDesc;
                        Product.UnitPrice = ProUnitPrice;
                        bool add = adminServices.AddProducts(Product);
                        if(add == true)
                        {
                            Console.WriteLine("Added!");
                        }
                        else
                        {
                            Console.WriteLine("--------------------------------------------------------------------------");
                            Console.WriteLine("Error in Adding!");
                            Console.WriteLine("--------------------------------------------------------------------------");
                        }
                        break;
                    case 2:
                        List<Products> DisplayProduct = new List<Products>();
                        DisplayProduct = adminServices.ViewProducts();
                        if (DisplayProduct != null)
                        {
                            var productTable = new ConsoleTable("ProductID", "Productname ", "Description ", "UnitPrice");
                            foreach (Products p in DisplayProduct)
                            {
                                productTable.AddRow(p.ProductID, p.ProductName, p.Description, p.UnitPrice);
                            }
                            productTable.Write(Format.Alternative);
                        }
                        else
                        {
                            Console.WriteLine("--------------------------------------------------------------------------");
                            Console.WriteLine("No Products to display!");
                            Console.WriteLine("--------------------------------------------------------------------------");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter Product ID to get the product details");
                        int productId = int.Parse(Console.ReadLine());
                        Products product = adminServices.OneProduct(productId);
                        var oneTable = new ConsoleTable("ProductID", "Productname ", "Description ", "UnitPrice");

                        if (product != null)
                        {
                            oneTable.AddRow(product.ProductID, product.ProductName, product.Description, product.UnitPrice);
                            oneTable.Write(Format.Alternative);
                        }
                        else
                        {
                            Console.WriteLine("No products to Display");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter Product ID to delete");
                        int productID = 0;
                        while (!int.TryParse(Console.ReadLine(), out productID))
                        {
                            Console.WriteLine("Please Enter a valid ID!");
                            Console.WriteLine("Enter Product ID to delete");
                        }
                        bool checkProduct = dataChecks.CheckProduct(productID);
                        if (checkProduct == true)
                        {
                            Console.WriteLine("Deleting a product also delete all Campaigns and Leads associated to that Product. Do you still want to continue? yes/no");
                            string confirm = Console.ReadLine();
                            if (confirm == "yes")
                            {
                                bool delete = adminServices.DeleteProduct(productID);
                                if (delete == true)
                                {
                                    Console.WriteLine("Deleted!");
                                }
                                else
                                {
                                    Console.WriteLine("--------------------------------------------------------------------------");
                                    Console.WriteLine("Error in Deleting!");
                                    Console.WriteLine("--------------------------------------------------------------------------");
                                }
                            }
                            else if (confirm == "no")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("--------------------------------------------------------------------------");
                                Console.WriteLine("Please enter from the given options.");
                                Console.WriteLine("--------------------------------------------------------------------------");
                                throw new Exception("IncorrectOptionError");
                            }
                        }
                        else
                        {
                            Console.WriteLine("--------------------------------------------------------------------------");
                            Console.WriteLine("Cannot Find Product!");
                            Console.WriteLine("--------------------------------------------------------------------------");
                        }                        
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("--------------------------------------------------------------------------");
                        Console.WriteLine("Please enter from the given options.");
                        Console.WriteLine("Deletion Aborted. Returning to previous Menu.");
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
                goto ProductMenu;
            }
            catch (Exception ex)
            {
                using (StreamWriter w = File.AppendText("log.txt"))
                {
                    exceptionLogging = new ExceptionLogging(ex.Message, w, ex.ToString());
                }
                goto ProductMenu;
            }
        }
        public void Campaigns()
        {
            CampaignMenu:
            try
            {
                adminServices = new AdminServices();
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add Campaigns");
                Console.WriteLine("2. Close Campaigns");
                Console.WriteLine("3. Show a specific Campaign");
                Console.WriteLine("4. back to Main menu");
                int Campaigns = 0;
                while (!int.TryParse(Console.ReadLine(), out Campaigns))
                {
                    Console.WriteLine("Please Enter a valid numerical value!");
                    Console.WriteLine("Enter your option: ");
                }
                switch (Campaigns)
                {
                    case 1:
                        {
                            dataChecks = new DataChecks();
                            Campaigns campaign = new Campaigns();
                            AccessCheck accessCheck = new AccessCheck();
                            Console.WriteLine("Enter Campaign Name:");
                            campaign.Name = Console.ReadLine();
                            Console.WriteLine("Enter Venue:");
                            campaign.Venue = Console.ReadLine();
                            Console.WriteLine("Marketing Executive assigned to this:");
                            int userID = 0;
                            while (!int.TryParse(Console.ReadLine(), out userID))
                            {
                                Console.WriteLine("Please Enter a valid numerical ID value!");
                                Console.WriteLine("Marketing Executive assigned to this:");
                            }
                            campaign.AssignedTo = userID;
                            if (dataChecks.CheckUser(campaign.AssignedTo) == true)
                            {
                                if (dataChecks.AdminCheck(campaign.AssignedTo))
                                {
                                    Console.WriteLine("Start date of Campaign(dd-MM-yyyy):");
                                    string dateLine = Console.ReadLine();
                                    DateTime date;
                                    while (!DateTime.TryParseExact(dateLine, "dd-MM-yyyy", null, DateTimeStyles.None, out date))
                                    {
                                        Console.WriteLine("Please enter a valid date in the given format.");
                                        Console.WriteLine("Enter Date: ");
                                        dateLine = Console.ReadLine();
                                    }
                                    campaign.StartedOn = date;
                                    bool add = adminServices.AddCampaigns(campaign);
                                    if (add == true)
                                    {
                                        Console.WriteLine("Added!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("--------------------------------------------------------------------------");
                                        Console.WriteLine("Error in Adding!");
                                        Console.WriteLine("--------------------------------------------------------------------------");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("--------------------------------------------------------------------------");
                                    Console.WriteLine("Assigned user is an Admin, please assign a Marketing Executive!");
                                    Console.WriteLine("--------------------------------------------------------------------------");
                                }
                            }
                            else
                            {
                                Console.WriteLine("--------------------------------------------------------------------------");
                                Console.WriteLine("No user with that ID found!");
                                Console.WriteLine("--------------------------------------------------------------------------");
                            }
                            break;
                        }
                       
                    case 2:
                        adminServices = new AdminServices();
                        Console.WriteLine("Enter Campign ID to be closed:");
                        int cId = 0;
                        while (!int.TryParse(Console.ReadLine(), out cId))
                        {
                            Console.WriteLine("Please Enter a valid numerical ID value!");
                            Console.WriteLine("Enter Campign ID to be closed:");
                        }
                        if (dataChecks.CheckCampaign(cId))
                        {
                            Console.WriteLine("Campaign is Closed");
                            Console.WriteLine("--------------------------------------------------------------------------");

                        }
                        else
                        {
                            Console.WriteLine("--------------------------------------------------------------------------");
                            Console.WriteLine("Failed to Close Campaign");
                            Console.WriteLine("--------------------------------------------------------------------------");

                        }

                        break;
                    case 3:
                        Console.WriteLine("Enter the Campaign ID to view it's details");
                        int cId2 = 0;
                        while (!int.TryParse(Console.ReadLine(), out cId2))
                        {
                            Console.WriteLine("Please Enter a valid numerical ID value!");
                            Console.WriteLine("Enter Campign ID to be view:");
                        }
                        Campaigns campaigns = adminServices.OneCampaign(cId2);
                        var campaignTable = new ConsoleTable("Campaign ID", "Campaign Name", "Assigned Executives", "Venue", "Started On", "Completed On", "Status");
                        if (campaigns != null)
                        {
                            campaignTable.AddRow(cId2, campaigns.Name, campaigns.AssignedTo, campaigns.Venue, campaigns.StartedOn.ToString("d"), campaigns.CompletedOn.ToString("d"), campaigns.IsOpen);
                            campaignTable.Write(Format.Alternative);
                        }
                        else
                        {
                            Console.WriteLine("--------------------------------------------------------------------------");
                            Console.WriteLine("No data with that Executive ID");
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
        public void Users()
        {
            UserMenu:
            try
            {
                adminServices = new AdminServices();
                dataChecks = new DataChecks();
                Console.WriteLine("Chose and Option:");
                Console.WriteLine("1. Add Users");
                Console.WriteLine("2. Display Users");
                Console.WriteLine("3. Discontinue a User");
                Console.WriteLine("4. Get a specific User");
                Console.WriteLine("5. Back to Main menu");
                int Users = 0;
                while (!int.TryParse(Console.ReadLine(), out Users))
                {
                    Console.WriteLine("Please Enter a valid numerical value!");
                    Console.WriteLine("Enter your option: ");
                }
                switch (Users)
                {
                    case 1:
                        {
                            Users user = new Users();
                            Console.WriteLine("Enter Full Name:");
                            user.FullName = Console.ReadLine();
                            Console.WriteLine("Enter a Login ID for the user:");
                            user.LoginID = Console.ReadLine();
                            Console.WriteLine("Enter Password for the user:");
                            user.Password = Console.ReadLine();
                            Console.WriteLine("Enter Date Of Join(dd-MM-yyyy):");
                            string dateLine = Console.ReadLine();
                            DateTime date;
                            while (!DateTime.TryParseExact(dateLine, "dd-MM-yyyy", null, DateTimeStyles.None, out date))
                            {
                                Console.WriteLine("Please enter a valid date in the given format.");
                                Console.WriteLine("Enter Date: ");
                                dateLine = Console.ReadLine();
                            }
                            user.DateOfJoin = date;
                            Console.WriteLine("Enter Address:");
                            user.Address = Console.ReadLine();
                            Console.WriteLine("Access Level of the User: 1. Administrator 2. Marketing Executive");
                            int access = Convert.ToInt32(Console.ReadLine());
                            if(access == 1)
                            {
                                user.IsAdmin = 1;
                            }
                            else if(access == 2)
                            {
                                user.IsAdmin = 0;
                            }
                            else
                            {
                                Console.WriteLine("--------------------------------------------------------------------------");
                                Console.WriteLine("Pick a correct option.");
                                Console.WriteLine("--------------------------------------------------------------------------");
                            }
                            bool check = adminServices.AddUser(user);
                            if (check)
                            {
                                Console.WriteLine("Added Successfully");
                            }
                            else
                            {
                                Console.WriteLine("Addition of User Failed");
                            }
                        }

                        break;

                    case 2:
                        {
                            List<Users> user = adminServices.DisplayUsers();
                            if (user != null)
                            {
                                var usersTable = new ConsoleTable("User ID", "Name ", "Login ID", "Password", "Date of Joining", "Address", "Discountinued", "Admin");
                                foreach (Users c in user)
                                {
                                    usersTable.AddRow(c.UserID, c.FullName, c.LoginID, c.Password, c.DateOfJoin.ToString("d"), c.Address, c.Discontinued, c.IsAdmin);
                                }

                                usersTable.Write(Format.Alternative);
                            }
                            else
                            {
                                Console.WriteLine("--------------------------------------------------------------------------");
                                Console.WriteLine("No Users to Display");
                                Console.WriteLine("--------------------------------------------------------------------------");
                            }

                        }
                        break;

                    case 3:
                        {
                            Console.WriteLine("Are you sure you want to continue? yes/no:");
                            string choice = Console.ReadLine();

                            if (choice.ToLower().Equals("yes"))
                            {
                                Console.WriteLine("Enter UserID:");
                                int userId = Convert.ToInt32(Console.ReadLine());
                                bool userValid = dataChecks.CheckUser(userId);
                                bool check = adminServices.DiscontinueUser(userId);

                                if (check == true)
                                {
                                    Console.WriteLine("User is successfully discontinued");
                                }
                                else
                                {
                                    Console.WriteLine("--------------------------------------------------------------------------");
                                    Console.WriteLine("No records found");
                                    Console.WriteLine("--------------------------------------------------------------------------");
                                }
                            }
                            else
                            {
                                Console.WriteLine("--------------------------------------------------------------------------");
                                Console.WriteLine("Pick the correct option.");
                                Console.WriteLine("--------------------------------------------------------------------------");
                            }
                        }
                        break;

                    case 4:
                        {
                            Console.WriteLine("Enter User ID:");
                            int userId = 0;
                            while (!int.TryParse(Console.ReadLine(), out userId))
                            {
                                Console.WriteLine("Please Enter a valid numerical value!");
                                Console.WriteLine("Try again: ");
                            }
                            Users user = adminServices.OneUser(userId);
                            var userTable = new ConsoleTable("User ID", "Name ", "Login ID", "Password", "Date of Joining", "Address", "Discountinued", "Admin");
                            if (user != null)
                            {
                                userTable.AddRow(user.UserID, user.FullName, user.LoginID, user.Password, user.DateOfJoin.ToString("d"), user.Address, user.Discontinued, user.IsAdmin);
                                userTable.Write(Format.Alternative);
                            }
                            else
                            {
                                Console.WriteLine("--------------------------------------------------------------------------");
                                Console.WriteLine("No record found");
                                Console.WriteLine("--------------------------------------------------------------------------");
                            }
                        }
                        break;

                    case 5:                        
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
                goto UserMenu;
            }
            catch (Exception ex)
            {
                using (StreamWriter w = File.AppendText("log.txt"))
                {
                    exceptionLogging = new ExceptionLogging(ex.Message, w, ex.ToString());
                }
                goto UserMenu;
            }
            
        }
        public void Reports()
        {
            ReportMenu:
            try
            {
                adminServices = new AdminServices();
                dataChecks = new DataChecks();
                Console.WriteLine("Choose one of the options:");
                Console.WriteLine("1. To View Leads by Campaign");
                Console.WriteLine("2. To View Campaigns by Executives and Number of Leads for it");
                Console.WriteLine("3. Back to Main menu");
                int Reports = 0;
                while (!int.TryParse(Console.ReadLine(), out Reports))
                {
                    Console.WriteLine("Please Enter a valid numerical value!");
                    Console.WriteLine("Enter your option: ");
                }
                switch (Reports)
                {
                    case 1:
                        Console.WriteLine("Enter CampaignID to see all it's Leads: ");
                        int campID = 0;
                        while (!int.TryParse(Console.ReadLine(), out campID))
                        {
                            Console.WriteLine("Please Enter a valid numerical value!");
                            Console.WriteLine("Enter your option: ");
                        }
                        if (dataChecks.CheckCampaign(campID))
                        {
                            List<Leads> leads = adminServices.ViewLeadByCampaign(campID);
                            if (leads != null)
                            {
                                var reportTable = new ConsoleTable("Lead ID", "Campaign ID", "Consumer Name", "Email Address", "Phone", "Preferred Mode of Contact", "Date Approached", "Product ID", "Status");
                                foreach (Leads l in leads)
                                {
                                    reportTable.AddRow(l.LeadID, l.CampaignID, l.ConsumerName, l.EmailAddress, l.PhoneNo, l.PreferredMoC, l.DateApproached.ToString("d"), l.ProductID, l.Status);
                                }
                                reportTable.Write(Format.Alternative);
                            }
                            else
                            {
                                Console.WriteLine("--------------------------------------------------------------------------");
                                Console.WriteLine("Leads for the given CampaignID does not exist.");
                                Console.WriteLine("--------------------------------------------------------------------------");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Given Campaign ID does not exist");
                            throw new Exception("NoDataExists");
                        }
                        break;
                    case 2:
                        List<Campaigns> campaigns = adminServices.ViewCampaingByExecutive();
                        if (campaigns != null)
                        {
                            var exeTable = new ConsoleTable("Assigned Executives","Campaign ID", "Name", "Venue", "Started On", "Completed On", "Status", "Number of Leads");
                            foreach (Campaigns c in campaigns)
                            {
                                exeTable.AddRow(c.AssignedTo,c.CampaignID,c.Name,c.Venue,c.StartedOn.ToString("d"),c.CompletedOn.ToString("d"),c.IsOpen,c.Leads);
                            }
                            exeTable.Write(Format.Alternative);
                            Console.WriteLine("");
                            Console.WriteLine("Note: Campaign Default duration is set to 7 days. Date gets updated upon closing the campaign.");
                            
                        }
                        else
                        {

                            Console.WriteLine("Wrong Executive Name");
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
                goto ReportMenu;
            }
            catch (Exception ex)
            {
                using (StreamWriter w = File.AppendText("log.txt"))
                {
                    exceptionLogging = new ExceptionLogging(ex.Message, w, ex.ToString());
                }
                goto ReportMenu;
            }
        }
    }
}
