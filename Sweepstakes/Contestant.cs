using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class Contestant
    {
        public string firstName;
        public string lastName;
        public string emailAddress;
        public int registrationNumber;

       

        public Contestant()
        {
            firstName = UserInterface.GetString("first name");
            lastName = UserInterface.GetString("last name");
            emailAddress = UserInterface.GetEmailAddress();
        }

        public string GetContestantFullName()
        {
            string fullName = $"{firstName} {lastName}";
            return fullName;
        }
    }
}
