using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using BusinessLayer.Services;
using BusinessLayer.Validations;
using ConsoleTables;

namespace PresentationLayer
{
    class AdminMenu
    {
        AdminServices adminServices = null;
        DataChecks dataChecks = null;
        public AdminMenu()
        {            
            try
            {
                bool keepLoop;
                do
                {
                    keepLoop = true;
                    Console.WriteLine("WELCOME TO YOUR ADMINISTRATOR PAGE");
                    Console.WriteLine("--------------------------------------------------------------------------");
                    Console.WriteLine("1.Manage Products");
                    Console.WriteLine("2.Manage Campaigns");
                    Console.WriteLine("3.Manage Users");
                    Console.WriteLine("4.Manage Reports");
                    Console.WriteLine("5.Logout");
                    Console.WriteLine("");
                    Console.WriteLine("Enter your option");
                    int Options = int.Parse(Console.ReadLine());
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
                            Console.WriteLine("Invalid Choice");
                            Console.WriteLine("--------------------------------------------------------------------------");
                            break;
                    }
                } while (keepLoop == true);


            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void Products()
        {
            try
            {
                adminServices = new AdminServices();
                Console.WriteLine("Choose fromt he following: ");
                Console.WriteLine("1.To Add Product");
                Console.WriteLine("2.To Display Product");
                Console.WriteLine("3.To Display a specific Product");
                Console.WriteLine("4.To Delete a Product");
                Console.WriteLine("5. Back to Main menu");
                int Products = int.Parse(Console.ReadLine());
                switch (Products)
                {
                    case 1:
                        Products Product = new Products();
                        Console.WriteLine("Enter Product Name:");
                        string ProName = Console.ReadLine();
                        Console.WriteLine("Give Product Description:");
                        string ProDesc = Console.ReadLine();
                        Console.WriteLine("Enter Unit Price of the Product:");
                        decimal ProUnitPrice = decimal.Parse(Console.ReadLine());
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
                            var table1 = new ConsoleTable("ProductID", "Productname ", "Description ", "UnitPrice");
                            foreach (Products p in DisplayProduct)
                            {
                                table1.AddRow(p.ProductID, p.ProductName, p.Description, p.UnitPrice);
                            }
                            table1.Write(Format.Alternative);
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
                        var table = new ConsoleTable("ProductID", "Productname ", "Description ", "UnitPrice");

                        if (product != null)
                        {
                            table.AddRow(product.ProductID, product.ProductName, product.Description, product.UnitPrice);
                            table.Write(Format.Alternative);
                        }
                        else
                        {
                            Console.WriteLine("No products to Display");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter Product ID to delete");
                        int productID = int.Parse(Console.ReadLine());
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
                        break;
                    case 5:
                        break;
                }


            }
            catch (Exception ex)
            {
                throw ex;
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
                int Campaigns = int.Parse(Console.ReadLine());
                switch (Campaigns)
                {
                    //case 1:
                    //    List<Campaigns> campaigns = AdminServices.ViewCampaignsByExec();

                    //    foreach (Campaigns c in campaigns)
                    //    {
                    //        Console.WriteLine($"Campaign ID: {c.CampaignID}, Name: {c.Name}, Venue: {c.Venue}, AssignedTo: {c.AssignedTo}, " +
                    //        $"Started ON: {c.StartedOn}, Completed ON: TBD, Status: {c.IsOpen}");
                    //        Console.WriteLine("--------------------------------------------------------------------------");
                    //    }
                        //break;
                    case 1:
                        {
                            Campaigns campaign = new Campaigns();
                            Console.WriteLine("Enter Campaign Name:");
                            campaign.Name = Console.ReadLine();
                            Console.WriteLine("Enter Venue:");
                            campaign.Venue = Console.ReadLine();
                            Console.WriteLine("Marketing Executive assigned to this:");
                            campaign.AssignedTo = Int32.Parse(Console.ReadLine());
                            if (adminServices.OneUser(campaign.AssignedTo) != null)
                            {
                                Console.WriteLine("Start date of Campaign(YYYY-MM-DD):");
                                campaign.StartedOn = Convert.ToDateTime(Console.ReadLine());
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
                                Console.WriteLine("No user with that ID found!");
                                Console.WriteLine("--------------------------------------------------------------------------");
                            }
                            break;
                        }
                       
                    case 2:
                        adminServices = new AdminServices();
                        Console.WriteLine("Enter Campign ID to be closed:");
                        int cId = int.Parse(Console.ReadLine());
                        if (adminServices.CloseCampaigns(cId))
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
                        int cId2 = Convert.ToInt32(Console.ReadLine());
                        Campaigns campaigns = adminServices.OneCampaign(cId2);
                        var table = new ConsoleTable("Campaign ID", "Campaign Name", "Assigned Executives", "Venue", "Started On", "Completed On", "Status");
                        if (campaigns != null)
                        {
                            table.AddRow(cId2, campaigns.Name, campaigns.AssignedTo, campaigns.Venue, campaigns.StartedOn,"TBD", campaigns.IsOpen);
                            table.Write(Format.Alternative);
                        }
                        else
                        {

                            Console.WriteLine("Wrong Executive Name");
                        }
                        break;

                    case 4:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("--------------------------------------------------------------------------");
                Console.WriteLine(ex.Message);
                Console.WriteLine("--------------------------------------------------------------------------");
                goto CampaignMenu;
            }
        }
        public void Users()
        {
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
                int Users = int.Parse(Console.ReadLine());
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
                            Console.WriteLine("Enter Date Of Join(YYYY-MM-DD):");
                            user.DateOfJoin = Convert.ToDateTime(Console.ReadLine());
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
                                var table = new ConsoleTable("User ID", "Name ", "Login ID", "Password", "Date of Joining", "Address", "Discountinued", "Admin");
                                foreach (Users c in user)
                                {
                                    table.AddRow(c.UserID, c.FullName, c.LoginID, c.Password, c.DateOfJoin, c.Address, c.Discontinued, c.IsAdmin);
                                }
                                table.Write(Format.Alternative);
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
                            int userId = Convert.ToInt32(Console.ReadLine());

                            Users user = adminServices.OneUser(userId);
                            var table = new ConsoleTable("User ID", "Name ", "Login ID", "Password", "Date of Joining", "Address", "Discountinued", "Admin");
                            if (user != null)
                            {
                                table.AddRow(user.UserID, user.FullName, user.LoginID, user.Password, user.DateOfJoin, user.Address, user.Discontinued, user.IsAdmin);
                                table.Write(Format.Alternative);
                                Console.WriteLine("--------------------------------------------------------------------------");
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
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Reports()
        {
            try
            {
                adminServices = new AdminServices();
                Console.WriteLine("Choose one of the options:");
                Console.WriteLine("1. To View Leads by Campaign");
                Console.WriteLine("2. To View Campaigns by Executives and Number of Leads for it");
                Console.WriteLine("3. Back to Main menu");
                int Reports = int.Parse(Console.ReadLine());
                switch (Reports)
                {
                    case 1:
                        Console.WriteLine("Enter CampaignID to see all it's Leads: ");
                        int campID = Convert.ToInt32(Console.ReadLine());
                        List<Leads> leads = adminServices.ViewLeadByCampaign(campID);
                        if (leads != null)
                        {
                            var table = new ConsoleTable("Lead ID", "Campaign ID", "Consumer Name", "Email Address", "Phone", "Preferred Mode of Contact", "Date Approached", "Product ID", "Status");
                            foreach(Leads l in leads)
                            {
                                table.AddRow(l.LeadID, l.CampaignID, l.ConsumerName, l.EmailAddress, l.PhoneNo, l.PreferredMoC, l.DateApproached, l.ProductID, l.Status);                                
                            }
                            table.Write(Format.Alternative);
                        }
                        else
                        {
                            Console.WriteLine("--------------------------------------------------------------------------");
                            Console.WriteLine("Data for given Campaign ID does not exist");
                            Console.WriteLine("--------------------------------------------------------------------------");
                        }


                        break;
                    case 2:
                        List<Campaigns> campaigns = adminServices.ViewCampaingByExecutive();
                        if (campaigns != null)
                        {
                            var table = new ConsoleTable("Assigned Executives","Campaign ID", "Name", "Venue", "Started On", "Completed On", "Status", "Number of Leads");
                            foreach (Campaigns c in campaigns)
                            {
                                table.AddRow(c.AssignedTo,c.CampaignID,c.Name,c.Venue,c.StartedOn,"TBD",c.IsOpen,c.Leads);
                            }
                            table.Write(Format.Alternative);
                        }
                        else
                        {

                            Console.WriteLine("Wrong Executive Name");
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
    }
}
