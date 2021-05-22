using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using BusinessLayer.Services;
using BusinessLayer.Validations;

namespace PresentationLayer
{
    class MainMenu
    {
        public static void Menu()
        {
            try
            {
                SessionDetails session = new SessionDetails();
                AccessCheck access = new AccessCheck();
                Console.WriteLine("Enter Login ID: ");
                string loginID = Console.ReadLine();
                Console.WriteLine("Enter Password: ");
                string loginPass = Console.ReadLine();
                bool val = access.Validation(loginID, loginPass);
                if (val == true)
                {
                    bool adminCheck = access.AdminCheck();
                    if (adminCheck == true)
                    {
                        Console.WriteLine($"WELCOME {session.FullName} to your Adminitrator Panel");
                        AdminMenu adminMenu = new AdminMenu();
                    }
                    else
                    {
                        Console.WriteLine($"WELCOME {session.FullName} to your Marketing Executive Panel");
                        ExecutiveMenu execMenu = new ExecutiveMenu();
                    }
                }
                else
                {
                    Console.WriteLine("Incorret Credentials!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void Main(string[] args)
        {
            try
            {
                do
                {
                    Menu();
                } while (true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
