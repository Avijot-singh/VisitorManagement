using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace VisitorManagement
{
    public class Login
    {
        public  void RegisterUser()
        {
            User newusers = new User();
           
            Console.WriteLine("--------REGISTRATION PAGE--------------");
            Console.Write("Enter Your Full Name: ");
            newusers.FullName= Console.ReadLine();
            Console.Write("Please Enter Your Password: ");
            newusers.Password = Console.ReadLine();

            User.RegisterUser(newusers);
            Console.WriteLine("User registered successfully");


        }



        public void AuthenticateUser()
        {
            Console.WriteLine("---------LOGIN PAGE-------");
            Console.Write("Please Enter Your Username: ");
            string username = Console.ReadLine();

            bool isUsernameCorrect = false;

            Console.Write("Please Enter Your Password: ");
            string password = Console.ReadLine();

            foreach (var i in User.GetUsers())
            {
                if (i.FullName == username)
                {
                    isUsernameCorrect = true;

                    if (i.Password == password)
                    {
                        Console.WriteLine("------ Login is Successful ! ------");
                        Permissions profile = new Permissions();
                        profile.Profile(i);
                        
                    }
                    else
                    {
                        Console.WriteLine("Incorrect password");
                        AuthenticateUser();
                        
                    }
                }
            }

            
            if (!isUsernameCorrect)
            {
                Console.WriteLine("Incorrect Username");
                AuthenticateUser();
            }
        }


    }

    public class Permissions
    {
        public void Profile(User user)
        {
           
            Console.WriteLine("Your profile details :");
            Console.WriteLine($"Your Name is : {user.FullName}");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("To view home menu, please type exit or select 1 to reset your password");
            string ProfileInput = Console.ReadLine().ToLower();
            if (ProfileInput == "exit")
            {
                WelcomeMenu menu = new WelcomeMenu();
                Console.Clear();
                menu.OGMenu();
            }

            else if (ProfileInput == "1")
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

        }















    }
}


/*string reset = Console.ReadLine();
if (reset == "yes" || reset == "y")
{
    Console.WriteLine("-----Forgot Password--------");
    Console.WriteLine("Admin User Only");

}*/