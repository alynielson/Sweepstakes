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

        
    }
}
