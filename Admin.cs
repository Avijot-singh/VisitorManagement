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


        public bool Authenticate(string enteredUsername, string enteredPassword)
        {
            return enteredUsername == _AdminUsername && enteredPassword == _AdminPassword;

        }


        public void Privileges(User user)
        {
            Console.WriteLine("Admin privileges");

            Console.WriteLine("Please Select the username to perform tasks :");
            Display(); // Displaying the list of users
            Console.Write("Username :");
            string AUsername = Console.ReadLine(); // storing the selected user in AUsername variable
            Console.WriteLine($"Username {AUsername}");

            User selectedUser = GetUsers().Find(u => u.FullName.Equals(AUsername, StringComparison.OrdinalIgnoreCase)); // Finding the user in the list, store the data inside the selectedUser, if not return it null




            // if not null perform the taks 
            if (selectedUser != null)
            {
                Console.WriteLine("1.   Reset Password");
                Console.WriteLine("2.   Delete user");
                Console.Write("Please enter your desired option : ");
                String PrivResponse = Console.ReadLine();




                if (PrivResponse == "1")
                {


                    Console.WriteLine(
                        $"The current password for the user {selectedUser.FullName} is {selectedUser.Password}");
                    Console.Write($"Type the new password for {selectedUser.FullName} : ");
                    string UpdatedPassword = Console.ReadLine();
                    selectedUser.Password = UpdatedPassword;
                    Console.WriteLine($"Password successfully changed for {selectedUser.FullName}:");
                    Console.WriteLine($"New password : {selectedUser.Password}");
                    Thread.Sleep(3000);
                    WelcomeMenu HomeMenu = new WelcomeMenu();
                    HomeMenu.OGMenu();

                }

                if (PrivResponse == "2")
                {
                    Console.WriteLine("----Delete User----");
                    Console.WriteLine($"Please confirm to delete user {selectedUser.FullName}");
                    string DeleteUser = Console.ReadLine().ToLower();
                    if (DeleteUser == "yes" || DeleteUser == "y" || DeleteUser == "confirm")
                    {
                        GetUsers().Remove(selectedUser);

                        Console.WriteLine($"User removed successfully");
                        Console.WriteLine("Bellow is the list:");
                        Display();
                        Thread.Sleep(5000);
                        Console.Clear();
                        WelcomeMenu HomeMenu = new WelcomeMenu();
                        HomeMenu.OGMenu();
                    }

                }
                else
                {
                    Console.WriteLine("Wrong input please select again");
                }


            }
            else
            {
                Console.WriteLine($"User with username {AUsername} is not found");
            }










        }
    }
}

