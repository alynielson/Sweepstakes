using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public static class UserInterface
    {
        public static string GetString(string typeOfString)
        {
            string response = "";
            do
            {
                Console.WriteLine($"Enter your {typeOfString}:");
                response = Console.ReadLine();
                Console.Clear();
                if (response == "")
                {
                    Console.WriteLine("You didn't enter anything! Try again.");
                }
            }
            while (response == "");
            return response;
        }

        public static string GetEmailAddress()
        {
            string emailAddress;
            do
            {
                emailAddress = GetString("email address");
                Console.Clear();
                if (emailAddress.Contains("@") == false || emailAddress.Contains(".") == false)
                {
                    Console.WriteLine("Not a valid email address! Try again.");
                }
            }
            while (emailAddress.Contains("@") == false || emailAddress.Contains(".") == false);
            return emailAddress;
        } 
    }
}
