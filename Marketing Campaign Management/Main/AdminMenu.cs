using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DatabaseLayer.Repositories;
using BusinessLayer.Services;

namespace PresentationLayer
{
    class AdminMenu
    {
        AdminServices adminServices = null;
        public AdminMenu()
        {

            
            try
            {
                bool keepLoop;
                do
                {
                    keepLoop = true;
                    Console.WriteLine("ADMINISTRATOR");
                    Console.WriteLine("select the option that you want to follow with");
                    Console.WriteLine("1.MANAGE PRODUCTS ");
                    Console.WriteLine("2.MANAGE CAMPAIGNS ");
                    Console.WriteLine("3.MANAGE USERS ");
                    Console.WriteLine("4.MANAGE REPORTS ");
                    Console.WriteLine("5.LOGOUT");
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
                            foreach (Products p in DisplayProduct)
                            {
                                Console.WriteLine($"ProductID:{p.ProductID}, Productname:{p.ProductName},Description:{p.Description},UnitPrice:{p.UnitPrice}");
                                Console.WriteLine(".........................................................");

                            }
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
                        if (product != null)
                        {
                            Console.WriteLine($"ProductID:{product.ProductID}, Productname:{product.ProductName},Description:{product.Description},UnitPrice:{product.UnitPrice}");

                        }
                        else
                        {
                            Console.WriteLine("NO products to Display");
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
            try
            {
                adminServices = new AdminServices();
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add Campaigns");
                Console.WriteLine("2. Close Campaigns");
                Console.WriteLine("3. back to Main menu");
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
                            Console.WriteLine("Enter Campaign ID:");
                            campaign.CampaignID = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Campaign Name:");
                            campaign.Name = Console.ReadLine();
                            Console.WriteLine("Enter Venue:");
                            campaign.Venue = Console.ReadLine();
                            Console.WriteLine("AssignedTo:");
                            campaign.AssignedTo = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("StartedOn:");
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

                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Users()
        {
            try
            {
                adminServices = new AdminServices();
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
                                foreach (Users c in user)
                                {
                                    Console.WriteLine($"User ID: {c.UserID}, Name: {c.FullName}, Login ID: {c.LoginID}, Password: {c.Password}, Date of Joining: {c.DateOfJoin}");
                                    Console.WriteLine($"Address: {c.Address}, Discountinued: {c.Discontinued}, Admin: {c.IsAdmin}");
                                    Console.WriteLine("--------------------------------------------------------------------------");
                                }
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
                            Console.WriteLine("Are you sure you want to continue yes/no:");
                            string choice = Console.ReadLine();

                            if (choice.ToLower().Equals("yes"))
                            {
                                Console.WriteLine("Enter UserID:");
                                int userId = Convert.ToInt32(Console.ReadLine());
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
                            if (user != null)
                            {
                                Console.WriteLine($"User ID: {user.UserID}, Name: {user.FullName}, Login ID: {user.LoginID}, Password: {user.Password}, Date of Joining: {user.DateOfJoin}");
                                Console.WriteLine($"Address: {user.Address}, Discountinued: {user.Discontinued}, Admin: {user.IsAdmin}");
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
                Console.WriteLine("2. To View Campaigns by Executives");
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
                            foreach(Leads l in leads)
                            {
                                Console.WriteLine($"Lead ID: {l.LeadID}, Campaign ID: {l.CampaignID}, Consumer Name: {l.ConsumerName}, Email Address: {l.EmailAddress}, PhoneNo: {l.PhoneNo}");
                                Console.WriteLine($"Preferred Mode if Contact: {l.PreferredMoC}, Date Approached: {l.DateApproached}, Product ID: {l.ProductID}, Status: {l.Status}");
                                Console.WriteLine("--------------------------------------------------------------------------");
                            }
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

                            Console.ReadLine();
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
