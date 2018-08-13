using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    class Contestant
    {
        string firstName;
        string lastName;
        string emailAddress;
        int registrationNumber;

        public Contestant()
        {
            firstName = UserInterface.GetString("first name");
            lastName = UserInterface.GetString("last name");
            emailAddress = UserInterface.GetEmailAddress();
        }
    }
}
