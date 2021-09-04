using System;
using System.Collections.Generic;
using System.Text;

namespace GmailApp.Models
{
    public class Email
    {
        public Email()
        {

        }
        public Email(string from, string subject,  string body, string time)
        {
            From    = from;
            Subject = subject;
            Body = body;
            Time    = time;
        }

        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Time { get; set; }
        
    }
}
