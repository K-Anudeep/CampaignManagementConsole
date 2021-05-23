using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DatabaseLayer.Repositories;

namespace PresentationLayer
{
    class AdminMenu
    {
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
                Console.WriteLine("choose options to Add,display,delete and getoneproduct ");
                Console.WriteLine("1.To Add Product");
                Console.WriteLine("2. To Display Product");
                Console.WriteLine("3. To Delete Product");
                Console.WriteLine("4. To GetOne Product");
                Console.WriteLine("4. Back to Main menu");
                int Products = int.Parse(Console.ReadLine());
                switch (Products)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
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
                Console.WriteLine("chose options to view, Add and Close a Campaign ");
                Console.WriteLine("1. View Campaigns");
                Console.WriteLine("2. Add Campaigns");
                Console.WriteLine("3. Close Campaigns");
                Console.WriteLine("4. back to Main menu");
                int Campaigns = int.Parse(Console.ReadLine());
                switch (Campaigns)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        
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
                Console.WriteLine("chose options to Add,Display,Discontinue or Get a user ");
                Console.WriteLine("1. Add Users");
                Console.WriteLine("2. Display Users");
                Console.WriteLine("3. Discontinue User");
                Console.WriteLine("4. GetOne User");
                Console.WriteLine("5. Back to Main menu");
                int Users = int.Parse(Console.ReadLine());
                switch (Users)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
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
                Console.WriteLine("Choose options to ViewLeads by Campaign or Executives");
                Console.WriteLine("1. To View Leads by Campaign");
                Console.WriteLine("2. To View Campaigns by Executives");
                Console.WriteLine("3. Back to Main menu");
                int Reports = int.Parse(Console.ReadLine());
                switch (Reports)
                {
                    case 1:
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
    }
}
