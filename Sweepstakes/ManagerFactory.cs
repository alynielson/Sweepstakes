using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public static class ManagerFactory 
    {
        public static ISweepstakesManager GetSweepstakesManager(string managerChoice)
        {
            ISweepstakesManager sweepstakesManager;
            switch (managerChoice)
            {
                case "q":
                    return sweepstakesManager = new SweepstakesQueueManager();
                   
                case "s":
                    return sweepstakesManager = new SweepstakesStackManager();
                default:
                    Exception exception = new ArgumentException();
                    throw exception;
            }

        }
    }
}
