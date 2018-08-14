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

        public static void FirmSearchOrAddMenu()
        {
            Console.WriteLine("Choose an option.");
            Console.WriteLine("(1) Add a new sweepstakes.");
            Console.WriteLine("(2) Search for a sweepstakes to view or edit.");
        }

        public static void NotFoundMessage(string whatNotFound)
        {
            Console.WriteLine($"{whatNotFound} was not found.");
        }

        public static int GetNumberResponse(int min, int max)
        {
            int numberChoice = 0;
            do
            {
                string response = Console.ReadLine();
                Int32.TryParse(response, out numberChoice);
                if (numberChoice < min || numberChoice > max)
                {
                    Console.WriteLine("Not a valid choice! Try again.");
                }
            }
            while (numberChoice < min || numberChoice > max);
            return numberChoice;

        }

        public static void ShowAddSuccessMessage(string whatWasAdded)
        {
            Console.WriteLine($"New {whatWasAdded} successfully added!");
        }

        public static void FoundMessage(string whatFound)
        {
            Console.WriteLine($"{whatFound} was found");
        }

        public static void DisplayWinner(string winner)
        {
            Console.WriteLine($"{winner} has won!");
        }

        public static void SweepstakesFoundMenu(string sweepstakesName)
        {
            Console.WriteLine($"Sweepstake {sweepstakesName}");
            Console.WriteLine("(1) Add a new contestant.");
            Console.WriteLine("(2) Find a contestant.");
            Console.WriteLine("(3) View sweepstake details.");
            Console.WriteLine("(4) Choose the winner.");
            Console.WriteLine("(5) Back to search for/add new sweepstakes page.");
        }

        public static bool CheckWhetherNumberOrNot(string nameOrRegistrationNumber)
        {
            int possibleRegistrationNumber;
            bool isNumeric = Int32.TryParse(nameOrRegistrationNumber, out possibleRegistrationNumber);
            return isNumeric;
        }
    }
}
