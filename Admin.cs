using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace VisitorManagement
{
    public class Admin : User
    {
        private string _AdminUsername;
        private string _AdminPassword;

        public Admin(string AdminUsername, string AdminPassword)
        {
            _AdminUsername = AdminUsername;
            _AdminPassword = AdminPassword;
        }

        public void AdminUser()
        {
            Console.WriteLine("---------ADMIN ACCOUNT ONLY---------");
            Console.Write("Please Enter Admin Username: ");
            string enteredUsername = Console.ReadLine();

            Console.Write("Please Enter Admin Password: ");
            string enteredPassword = Console.ReadLine();

            if (Authenticate(enteredUsername, enteredPassword))
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("Authentication Successful!, Welcome Admin User");
                User.Display();
            }
            else
            {
                Console.WriteLine("Authentication Failed");
                WelcomeMenu HomeMenu = new WelcomeMenu();
                HomeMenu.OGMenu();
            }

          
        }

      
        public bool Authenticate( string enteredUsername, string enteredPassword)
        {
            return enteredUsername == _AdminUsername && enteredPassword == _AdminPassword;

        }


        public void Privileges(User user)
        {
            Console.WriteLine("Admin privileges");
            // Getting the username for tasks
            Console.WriteLine("Please Select the username to perform tasks :");
            Display();
            Console.Write("Username :");
            string AUsername = Console.ReadLine();
            Console.WriteLine($"Username {AUsername}");

            User selectedUser = GetUsers().Find(u => u.FullName.Equals(AUsername, StringComparison.OrdinalIgnoreCase));



            // Getting the selected User from the registered list

            if (selectedUser != null)
            {
                Console.WriteLine("1.   Reset Password");
                Console.WriteLine("2.   Delete user");
                Console.Write("Please enter your desired option : ");
                String PrivResponse = Console.ReadLine();




                if (PrivResponse == "1")
                {

                    {
                        Console.WriteLine($"The current password for the user {selectedUser.FullName} is {selectedUser.Password}");
                        Console.Write($"Type the new password for {selectedUser.FullName} : ");
                        string UpdatedPassword = Console.ReadLine();
                        selectedUser.Password = UpdatedPassword;
                        Console.WriteLine($"Password successfully changed for {selectedUser.FullName}:");
                        Console.WriteLine($"New password : {selectedUser.Password}");
                        Thread.Sleep(3000);
                        WelcomeMenu HomeMenu = new WelcomeMenu();
                        HomeMenu.OGMenu();
                    }
                }


            }
            else
            {
                Console.WriteLine($"User with username {AUsername} is not found");
            }










        }
}
