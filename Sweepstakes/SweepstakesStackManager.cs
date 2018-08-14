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
                if (userEnteredSweepstakes.ToLower().Trim() == sweepstakes.name.ToLower().Trim())
                {
                    return sweepstakes;
                }
            }
            return null;
        }

        public void DisplayAllSweepstakes()
        {
            int itemNumber = 1;
            foreach (Sweepstakes sweepstakes in stack)
            {
                Console.WriteLine($"({itemNumber}) {sweepstakes.name}");
                itemNumber++;
            }
            if (stack.Count == 0)
            {
                Console.WriteLine("No sweepstakes have been created!");
            }
        }
    }
}
