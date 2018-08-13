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

        public void ConvertUserChoiceToAction(int userChoice)
        {
            switch (userChoice)
            {
                case 1:
                    AddSweepstakes();
                    break;
                case 2:
                    FindASweepstakes();
                    break;
            }
        }

        public void FindASweepstakes()
        {
            Sweepstakes foundSweepstakes = _sweepstakesManager.GetSweepstakes();
            if (foundSweepstakes == null)
            {
                UserInterface.NotFoundMessage("Sweepstakes");
            }
            else
            {
                UserInterface.SweepstakesFoundMenu(foundSweepstakes.name);
            }
        }

        
    }
}
