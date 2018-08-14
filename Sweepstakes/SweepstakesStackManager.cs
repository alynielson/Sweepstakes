using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    class SweepstakesStackManager : ISweepstakesManager
    {
        Stack<Sweepstakes> stack;
        public SweepstakesStackManager()
        {
            stack = new Stack<Sweepstakes>();
        }
        public void InsertSweepstakes(Sweepstakes sweepstakes)
        {
            stack.Push(sweepstakes);
        }

        public Sweepstakes GetSweepstakes()
        {
            string userEnteredSweepstakes = UserInterface.GetString("the sweepstakes to search for");
            foreach (Sweepstakes sweepstakes in stack)
            {
                if (userEnteredSweepstakes.ToLower().Trim() == sweepstakes.name)
                {
                    return sweepstakes;
                }
            }
            return null;
        }
    }
}
