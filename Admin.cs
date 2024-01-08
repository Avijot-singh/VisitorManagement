using System;
using System.Collections.Generic;
using System.Linq;
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



    }
}
