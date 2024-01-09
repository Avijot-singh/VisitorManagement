using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml;

namespace VisitorManagement
{
    public class User
    {
        
        private static List<User> users = new List<User>();

        public static List<User> GetUsers()
        {
            return users;
        }

        
        
        public string FullName { get; set; }
        public string Password { get; set; }
        

        private int _custId;
        public int getCustId()
        {
            return _custId;
        }

        public static void RegisterUser(User newusers)
        {
            users.Add(newusers);
        }

        public static void Display()
        {
            Console.WriteLine("---------------------------------------");
            foreach (var i in users)
            {
                Console.WriteLine("List of users: " + i.FullName);

            }
        }
        
    }

    

   

}





