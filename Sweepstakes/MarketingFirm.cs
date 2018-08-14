using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    class MarketingFirm
    {
        private readonly ISweepstakesManager _sweepstakesManager;
        public bool stillWorking;
        

        public MarketingFirm(string stackOrQueue)
        {
            _sweepstakesManager = ManagerFactory.GetSweepstakesManager(stackOrQueue);
            
        }

        private void AddSweepstakes()
        {
            string name = UserInterface.GetString("the name of your sweepstakes");
            Sweepstakes newSweepstakes = new Sweepstakes(name);
            _sweepstakesManager.InsertSweepstakes(newSweepstakes);
            UserInterface.ShowAddSuccessMessage("sweepstakes");
        }

        public void FirmMenu()
        {
            UserInterface.FirmSearchOrAddMenu();
            int action = UserInterface.GetNumberResponse(1, 4);
            DecideFirmMenuAction(action);
               
        }

        

        
        public void DecideFirmMenuAction(int userChoice)
        {
            switch (userChoice)
            {
                case 1:
                    AddSweepstakes();
                    break;
                case 2:
                    Sweepstakes foundSweepstakes = FindASweepstakes();
                    foundSweepstakes.isStillEditing = true;
                    while (foundSweepstakes != null && foundSweepstakes.isStillEditing == true)
                    {
                        UserInterface.SweepstakesFoundMenu(foundSweepstakes.name);
                        int action = UserInterface.GetNumberResponse(1, 6);
                        foundSweepstakes.ConvertUserChoiceToAction(action);
                    }
                    break;
                case 3:
                    Console.Clear();
                    _sweepstakesManager.DisplayAllSweepstakes();
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                default:
                    stillWorking = false;
                    break;
                    
                    
            }
        }

        private Sweepstakes FindASweepstakes()
        {
            Sweepstakes foundSweepstakes = _sweepstakesManager.GetSweepstakes();
            if (foundSweepstakes == null)
            {
                UserInterface.NotFoundMessage("Sweepstakes");
            }
            else
            {
                UserInterface.FoundMessage($"Sweepstake {foundSweepstakes.name}");
            }
            return foundSweepstakes;
        }

        
    }
}
