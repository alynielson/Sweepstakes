using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    class Sweepstakes
    {
        
        public Dictionary<int, string> contestants = new Dictionary<int, string>();

        private void RegisterContestant(Contestant contestant)
        {
            string fullName = $"{contestant.firstName + contestant.lastName}";
            contestant.registrationNumber = contestants.Count + 1;
            contestants.Add(contestant.registrationNumber, fullName);
        }
    }
}
