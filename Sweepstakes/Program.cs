using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInterface.InitialDisplay();
            string stackOrQueue = UserInterface.GetManagerChoice();
            MarketingFirm newFirm = new MarketingFirm(stackOrQueue);
            bool stillWorking = true;
            while (stillWorking == true)
            {
                int action = UserInterface.FirmSearchOrAddMenu();
                newFirm.ConvertUserChoiceToAction(action);
                newFirm.FindASweepstakes();
            }
        }
    }
}
