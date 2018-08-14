using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class Sweepstakes
    {

        public Dictionary<int, Contestant> contestants;
        Random random;
        public string name;
        private string status;

       

        public Sweepstakes(string name)
        {
            contestants = new Dictionary<int, Contestant>();
            this.name = name.ToLower().Trim();
            status = "Registering contestants";
        }

        private void RegisterContestant(Contestant contestant)
        {
            contestant.registrationNumber = contestants.Count + 1;
            contestants.Add(contestant.registrationNumber, contestant);
        }

        private Contestant FindContestantByRegistrationNumber(int possibleRegistrationNumber)
        {
            bool wasFoundById = contestants.TryGetValue(possibleRegistrationNumber, out Contestant foundContestant);
            if (wasFoundById)
            {
                Console.WriteLine($"A matching contestant was found:");
                Console.WriteLine($"{foundContestant.firstName} {foundContestant.lastName}, Registration Number: {foundContestant.registrationNumber}");
                return foundContestant;
            }
            else
            {
                Console.WriteLine("No matching contestant found.");
                return null;
            }
        }

        private Contestant SearchForContestant()
        {
            string nameOrRegistrationNumber = UserInterface.GetString("a name or registration number to search");
            bool isPossibleRegistrationNumber = UserInterface.CheckWhetherNumberOrNot(nameOrRegistrationNumber);
            if (isPossibleRegistrationNumber == true)
            {
                int possibleRegistrationNumber;
                Int32.TryParse(nameOrRegistrationNumber, out possibleRegistrationNumber);
                Contestant possibleContestant = FindContestantByRegistrationNumber(possibleRegistrationNumber);
                if (possibleContestant == null)
                {
                    return null;
                }
                return possibleContestant;
            }
            else
            {
                List<Contestant> possibleContestants = FindContestantByName(nameOrRegistrationNumber);
                Contestant contestant = GetContestantFromList(possibleContestants);
                if (contestant == null)
                {
                    return null;
                }
                return contestant;
            }
        }

        private Contestant GetContestantFromList(List<Contestant> possibleContestants)
        {
            Console.WriteLine("Enter a number to view a contestant.");
            int response = UserInterface.GetNumberResponse(1, possibleContestants.Count +1 );
            Contestant contestantFromSearch = possibleContestants[response - 1];
            return contestantFromSearch;
        }

        private List<Contestant> FindContestantByName(string possibleName)
        {
            possibleName = possibleName.ToLower().Trim();
            List<Contestant> contestantMatches = new List<Contestant>();
            Console.WriteLine("Matching contestants found:");
            int listNumber = 1;
            foreach (KeyValuePair<int, Contestant> item in contestants)
            {
                if (possibleName == item.Value.firstName || possibleName == item.Value.lastName || possibleName == $"{item.Value.firstName} {item.Value.lastName}")
                {
                    Console.WriteLine($"({listNumber}) {item.Value.firstName} {item.Value.lastName}, Registration Number: {item.Value.registrationNumber}");
                    contestantMatches.Add(item.Value);
                    listNumber++;
                }
            }
            if (contestantMatches.Count == 0)
            {
                Console.WriteLine("No matching person was found.");
            }
            return contestantMatches;
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
            status = "Winner chosen";
            return nameOfWinner;
        }

        public void ConvertUserChoiceToAction(int action)
        {
            switch (action)
            {
                case 1:
                    Contestant newContestant = new Contestant();
                    RegisterContestant(newContestant);
                    break;
                case 2:
                    Contestant contestant = SearchForContestant();
                    if (contestant != null)
                    {

                    }
                    break;
                case 3:
                    break;
            }
        }

        
    }
}
