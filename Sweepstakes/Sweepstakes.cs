using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    class Sweepstakes
    {
        
        public Dictionary<int, string> contestants = new Dictionary<int, string>();

        private void RegisterContestant(Contestant contestant)
        {
            string fullName = contestant.GetContestantFullName();
            contestant.registrationNumber = contestants.Count + 1;
            contestants.Add(contestant.registrationNumber, fullName);
        }

        private void PrintContestantInfo(Contestant contestant)
        {
            Console.WriteLine($"First name: {contestant.firstName}");
            Console.WriteLine($"Last name: {contestant.lastName}");
            Console.WriteLine($"Email: {contestant.emailAddress}");
            Console.WriteLine($"Registration number: {contestant.registrationNumber}");
            Console.WriteLine("Press Enter to go back.");
            Console.ReadLine();
        }

        
    }
}
