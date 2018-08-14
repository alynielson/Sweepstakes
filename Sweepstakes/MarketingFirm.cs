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

        public MarketingFirm(string stackOrQueue)
        {
            _sweepstakesManager = ManagerFactory.GetSweepstakesManager(stackOrQueue);
            Random random = new Random();
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
            int action = UserInterface.GetNumberResponse(1, 3);
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
                    if (foundSweepstakes != null)
                    {
                        UserInterface.SweepstakesFoundMenu(foundSweepstakes.name);
                        int action = UserInterface.GetNumberResponse(1, 6);
                        foundSweepstakes.ConvertUserChoiceToAction(action);
                    }
                    break;
                default:
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
