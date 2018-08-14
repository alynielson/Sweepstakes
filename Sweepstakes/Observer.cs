using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Sweepstakes
{
    public abstract class Observer
    {

        public abstract void Update(string emailAddressOfRecipient, string subject, string body);
        
    }
}
