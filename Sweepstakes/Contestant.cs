using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Configuration;

namespace Sweepstakes
{
    public class Contestant : Observer
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

        public override void Update(string emailAddressOfRecipient, string subject, string body)
        {
            MailMessage email = new MailMessage();
            MailAddress fromAddress = new MailAddress("mailmansweepstakes@gmail.com");
            email.From = fromAddress;
            email.To.Add(emailAddressOfRecipient);
            email.Subject = subject;
            email.IsBodyHtml = true;
            email.Body = body;
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("mailmansweepstakes@gmail.com", "badpassword12@");
            client.Port = 25;     
            client.EnableSsl = true;
            try
            {
                client.Send(email);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
