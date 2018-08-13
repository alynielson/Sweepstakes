using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public static class UserInterface
    {
        public static string GetName(string firstOrLast)
        {
            string response = "";
            do
            {
                Console.WriteLine($"Enter your {firstOrLast} name:");
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
    }
}
