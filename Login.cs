using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VisitorManagement
{
    public class Login
    {
        public void RegisterUser()
        {
            User newusers = new User();

            Console.WriteLine("--------REGISTRATION PAGE--------------");
            Console.Write("Enter Your Full Name: ");
            newusers.FullName = Console.ReadLine();
            do
            {
                Console.Write("Enter Your Email: ");
                newusers.Email = Console.ReadLine();

                if (IsValidEmail(newusers.Email))
                {

                    break;
                }
                else
                {
                    Console.WriteLine("Invalid email input");

                }



            } while (true);

            Console.Write("Please Enter Your Password: ");
            newusers.Password = Console.ReadLine();

            User.RegisterUser(newusers);
            Console.WriteLine("User registered successfully");

        }

        public static bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, emailPattern);
        }




        public void AuthenticateUser()
        {
            string retryOption = "yes";

            do
            {
                Console.WriteLine("---------LOGIN PAGE-------");
                Console.Write("Please Enter Your Username: ");
                string username = Console.ReadLine();

                Console.Write("Please Enter Your Password: ");
                string password = Console.ReadLine();

                bool isUserFound = false;

                foreach (var user in User.GetUsers())
                {
                    if (user.FullName == username && user.Password == password)
                    {
                        Console.WriteLine("------ Login is Successful ! ------");
                        Permissions profile = new Permissions();
                        profile.Profile(user);
                        isUserFound = true;
                        break;
                    }
                }

                if (!isUserFound)
                {
                    Console.WriteLine("Incorrect username or password");
                    Console.Write("Do you want to retry? (yes/no): ");
                    retryOption = Console.ReadLine().ToLower();
                }
                if(retryOption == "no")
                {
                    Console.WriteLine("Exiting to main menu");
                    Thread.Sleep(2000);
                    Console.Clear();
                    WelcomeMenu menu = new WelcomeMenu();
                    menu.OGMenu();
                    
                    
                }
                

            } while (retryOption == "yes" || retryOption == "y");
        }
    }

    public class Permissions
    {
        public void Profile(User user)
        {
           
            Console.WriteLine("Your profile details :");
            Console.WriteLine($"Your Name is : {user.FullName}");
            Console.WriteLine($"Your Email is : {user.Email}");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Type 1 to exit or 2 to reset your password");
            string ProfileInput = Console.ReadLine().ToLower();
            if (ProfileInput == "1")
            {
                WelcomeMenu menu = new WelcomeMenu();
                Console.Clear();
                menu.OGMenu();
            }

            else if (ProfileInput == "2")
            {
                Console.WriteLine("Please enter your new password");
                string newPassword = Console.ReadLine();
                user.Password = newPassword;
                Console.WriteLine("Your new password is set successfully");
                Console.WriteLine("Exiting to login screen");
                Login login = new Login();
                Thread.Sleep(3000);
                Console.Clear();
                login.AuthenticateUser();

            }
            else
            {
                Console.Clear();
                WelcomeMenu menu = new WelcomeMenu();
                menu.OGMenu();
            }

        }















    }
}


