using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    class Sweepstakes
    {

        public Dictionary<int, Contestant> contestants;
        Random random;
        string name;

        public Sweepstakes(string name)
        {
            contestants = new Dictionary<int, Contestant>();
            name = this.name;
        }

        private void RegisterContestant(Contestant contestant)
        {
            contestant.registrationNumber = contestants.Count + 1;
            contestants.Add(contestant.registrationNumber, contestant);
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

        private string PickWinner()
        {
            int numberPicked = random.Next(1, contestants.Count + 1);
            string nameOfWinner = $"{contestants[numberPicked].firstName} + {contestants[numberPicked].lastName}";
            return nameOfWinner;
        }

        
    }
}
