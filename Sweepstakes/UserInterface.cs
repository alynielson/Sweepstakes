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
                Console.WriteLine($"Enter {typeOfString}:");
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

        public static void InitialDisplay()
        {
            Console.WriteLine("Welcome to your sweepstakes manager!");
        }

        public static string GetManagerChoice()
        {
            string managerChoice;
            Console.WriteLine("Will your sweepstakes be maintained in a stack or a queue?");
            do
            {
                managerChoice = GetString("(S) for stack or (Q) for queue");
                Console.Clear();
                managerChoice = managerChoice.ToLower();
                if (managerChoice != "q" && managerChoice != "s")
                {
                    Console.WriteLine("Didn't type Q or S! Try again.");
                }
            }
            while (managerChoice != "q" && managerChoice != "s");
            return managerChoice;
        }


    }
}
