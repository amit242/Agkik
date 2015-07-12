using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MedInventus.DAL;

namespace DALTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("wasssa");
            
            MedInventus.user usr = UserDAL.getUserByUserId("ab");
            Console.WriteLine("{0} | {1} | {2}", usr.FirstName, usr.UserName, usr.Password); 
            Console.ReadLine();
        }
    }
}
