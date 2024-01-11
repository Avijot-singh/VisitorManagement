using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorManagement
{
    public class WelcomeMenu
    {
        public void OGMenu()
        {
            Console.WriteLine("-------MENU-------");
            Console.WriteLine("1.   New User");
            Console.WriteLine("2.   Existing User");
            Console.WriteLine("3.   Admin User");
            Console.WriteLine("4.   Exit");

            User curretUser = new User();

            int MenuResponse = int.Parse(Console.ReadLine());

            switch (MenuResponse)
            {
                case 1:
                    Login registration = new Login();
                    registration.RegisterUser();
                  
                   Login Reg = new Login();
                    Reg.AuthenticateUser();
                    
                    break;
                case 2:
                    Login login = new Login();
                    login.AuthenticateUser();
                    break;
                case 3:
                    Admin admin = new Admin("Admin", "Acce$$Flow");
                    admin.AdminUser();
                    admin.Privileges(curretUser);
                    break;
                case 4:
                    ExitMenu();
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    OGMenu();
                    break;  


            }
        }

        public void ExitMenu()
        {
            Console.WriteLine("------Exited Application---------");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Select 1 to go back to the menu");
            int exit = int.Parse(Console.ReadLine());

            if (exit == 1)
            {
                OGMenu();
            }
            else
            {
                Console.WriteLine("Invalid output");
                ExitMenu();
            }
        }
    }
}
