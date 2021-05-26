using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Entities;
using BusinessLayer.Services;
using BusinessLayer.Validations;
using BusinessLayer.Exceptions;

namespace PresentationLayer
{
    class MainMenu
    {
        public static void Menu()
        {
            ExceptionLogging exceptionLogging = null;
            try
            {                
                SessionDetails session = new SessionDetails();
                AccessCheck access = new AccessCheck();
                Console.WriteLine("Enter Login ID: ");
                string loginID = Console.ReadLine();
                if (loginID != "")
                {
                    Console.WriteLine("Enter Password: ");
                    string loginPass = Console.ReadLine();
                    if (loginPass != "")
                    {
                        bool val = access.Validation(loginID, loginPass);
                        if (val == true)
                        {
                            bool adminCheck = access.AdminCheck();
                            if (adminCheck == true)
                            {
                                Console.WriteLine("--------------------------------------------------------------------------");
                                Console.WriteLine($"Welcome {session.FullName.ToUpper()} to your Administrator Panel");
                                AdminMenu adminMenu = new AdminMenu();
                            }
                            else
                            {
                                Console.WriteLine("--------------------------------------------------------------------------");
                                Console.WriteLine($"Welcome {session.FullName.ToUpper()} to your Marketing Executive Panel");
                                ExecutiveMenu execMenu = new ExecutiveMenu();
                            }
                        }
                        else
                        {
                            Console.WriteLine("--------------------------------------------------------------------------");
                            Console.WriteLine("Please check the credentials and try again.");
                            Console.WriteLine("--------------------------------------------------------------------------");
                            throw new ExceptionLogging("Incorrect Credentials given");
                        }
                    }
                    else
                    {
                        Console.WriteLine("--------------------------------------------------------------------------");
                        Console.WriteLine("Password Should not be empty");
                        Console.WriteLine("--------------------------------------------------------------------------");
                        throw new ExceptionLogging("Empty Password Field");
                    }
                }
                else
                {
                    Console.WriteLine("--------------------------------------------------------------------------");
                    Console.WriteLine("Login ID should not be empty!");
                    Console.WriteLine("--------------------------------------------------------------------------");
                    throw new ExceptionLogging("Empty Login Field");
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.WriteLog(ex);
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
                Console.WriteLine("An Error Occured: Please contact the Administrator");
                ExceptionLogging.WriteLog(ex);
            }
        }
    }
}
