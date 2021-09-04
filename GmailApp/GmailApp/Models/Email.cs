using System;
using System.Collections.Generic;
using System.Text;

namespace GmailApp.Models
{
    public class Email
    {
        public Email(string name, string subject,  string content, string time)
        {
            Name    = name;
            Subject = subject;
            Content = content;
            Time    = time;
        }

        public string Name { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string Time { get; set; }
        
    }
}
