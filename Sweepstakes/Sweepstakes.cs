﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes 
{
    public class Sweepstakes : Subject
    {

        public Dictionary<int, Contestant> contestants;
        
        public string name;
        private string status;
        private Contestant winner;
        public bool isStillEditing;

       

        public Sweepstakes(string name)
        {
            contestants = new Dictionary<int, Contestant>();
            this.name = name;
            status = "Registering contestants";
        }

        public void Attach(Observer observer)
        {
            Register(observer);
        }

        public override void Notify()
        {
            string subject = $"{name} winner announcement";
            string winnerBody = $"Hello {winner.firstName},\n\nYou've been chosen as the winner for {name}! Call 555-555-5555 to claim your prize.\n\nRegards,\nThe Marketing Firm";
            foreach (Contestant contestant in observers)
            {
                if (contestant.Equals(winner))
                {
                    contestant.Update(contestant.emailAddress, subject, winnerBody);
                }
                else
                {
                    string nonWinnerBody = $"Hello {contestant.firstName},\n\nThe winner of {name} has been chosen and notified. Thanks for your participation! Register for more of our sweepstakes!\n\nRegards,\nThe Marketing Firm";
                    contestant.Update(contestant.emailAddress, subject, nonWinnerBody);
                }
            }
        }

       
        private void RegisterContestant(Contestant contestant)
        {
            contestant.registrationNumber = contestants.Count + 1;
            contestants.Add(contestant.registrationNumber, contestant);
            Attach(contestant);
            Console.WriteLine("Contestant successfully registered! Press Enter to continue.");
            Console.ReadLine();
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
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
                return null;
            }
        }

        private Contestant SearchForContestant()
        {
            string nameOrRegistrationNumber = UserInterface.GetString("a name (first, last, or full) or registration number to search");
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
            if (possibleContestants.Count == 0)
            {
                return null;
            }
            else
            {
                Console.WriteLine("Enter a number to view a contestant.");
                int response = UserInterface.GetNumberResponse(1, possibleContestants.Count + 1);
                Contestant contestantFromSearch = possibleContestants[response - 1];
                return contestantFromSearch;
            }
        }

        private List<Contestant> FindContestantByName(string possibleName)
        {
            possibleName = possibleName.ToLower().Trim();
            List<Contestant> contestantMatches = new List<Contestant>();
            Console.WriteLine("Matching contestants found:");
            int listNumber = 1;
            foreach (KeyValuePair<int, Contestant> item in contestants)
            {
                if (possibleName == item.Value.firstName.ToLower().Trim() || possibleName == item.Value.lastName.ToLower().Trim() || possibleName == $"{item.Value.firstName.ToLower().Trim()} {item.Value.lastName.ToLower().Trim()}")
                {
                    Console.WriteLine($"({listNumber}) {item.Value.firstName} {item.Value.lastName}, Registration Number: {item.Value.registrationNumber}");
                    contestantMatches.Add(item.Value);
                    listNumber++;
                }
            }
            if (contestantMatches.Count == 0)
            {
                Console.WriteLine("No matching person was found.");
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
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
            Random random = new Random();
            if (contestants.Count == 0)
            {
                Console.WriteLine("No winner chosen. No contestants are registered.");
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
                return null;
            }
            else if (status == "Winner chosen")
            {
                Console.WriteLine("Winner was already chosen.");
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
                return null;
            }
            else
            {
                int numberPicked = random.Next(1, contestants.Count + 1);
                string nameOfWinner = $"{contestants[numberPicked].firstName} {contestants[numberPicked].lastName}";
                status = "Winner chosen";
                winner = contestants[numberPicked];
                Notify();
                return nameOfWinner;
            }
        }

        public void ConvertUserChoiceToAction(int action)
        {
            switch (action)
            {
                case 1:
                    Console.Clear();
                    Contestant newContestant = new Contestant();
                    RegisterContestant(newContestant);
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    Contestant contestant = SearchForContestant();
                    if (contestant != null)
                    {
                        PrintContestantInfo(contestant);
                        Console.Clear();
                        break;
                    }
                    Console.Clear();
                    break;
                case 3:
                    Console.Clear();
                    GetDetails();
                    Console.Clear();
                    break;
                case 4:
                    Console.Clear();
                    string winner = PickWinner();
                    if (winner != null)
                    {
                        UserInterface.DisplayWinner(winner);
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                    }
                    Console.Clear();
                    break;
                case 5:
                    Console.Clear();
                    DisplayAllContestants();
                    break;
                default:
                    isStillEditing = false;
                    Console.Clear();
                    break;
            }
        }

        private void DisplayAllContestants()
        {
            int itemNumber = 1;
            foreach (KeyValuePair<int,Contestant> item in contestants)
            {
                Console.WriteLine($"({itemNumber}) {item.Value.firstName} {item.Value.lastName}");
                itemNumber++;
            }
            if (contestants.Count == 0)
            {
                Console.WriteLine("No contestants are entered in this sweepstake");
            }
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
            Console.Clear();
        }

        private void GetDetails()
        {
            Console.WriteLine($"Sweepstake {name}");
            Console.WriteLine($"Number of contestants registered: {contestants.Count}");
            Console.WriteLine($"Status: {status}");
            if (status == "Winner chosen")
            {
                Console.WriteLine($"Winner: {winner.firstName} {winner.lastName}");
            }
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }

        
    }
}
