﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
            Console.Write("Please Enter Your Password: ");
            string password = Console.ReadLine();
            foreach (var i in User.GetUsers())
            {
                if (i.FullName == username)
                {
                    if (i.Password == password)

                    {
                        Console.WriteLine("------ Login is Successful ! ------");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect password");
                        return;
                    }
                }
                else 
                {
                    Console.WriteLine("Incorrect Username");
                }

            }
        }
    }
}
