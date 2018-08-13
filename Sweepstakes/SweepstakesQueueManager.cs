using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    class SweepstakesQueueManager : ISweepstakesManager
    {
        Queue<Sweepstakes> queue;
        public SweepstakesQueueManager()
        {
            queue = new Queue<Sweepstakes>();
        }
        public void InsertSweepstakes(Sweepstakes sweepstakes)
        {
            queue.Enqueue(sweepstakes);
            
        }

        public Sweepstakes GetSweepstakes()
        {
            string userEnteredSweepstakes = UserInterface.GetString("the sweepstakes to search for");
            foreach (Sweepstakes sweepstakes in queue)
            {
                if (userEnteredSweepstakes.ToLower().Trim() == sweepstakes.name.ToLower().Trim())
                {
                    return sweepstakes;
                }
            }
            return null;   
        }

       

        
    }
}
