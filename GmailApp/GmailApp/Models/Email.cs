﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GmailApp.Models
{
    public class Email
    {
        public Email(string name, string subject, string time)
        {
            Name = name;
            Subject = subject;
            Time = time;
        }

        public string Name { get; set; }
        public string Subject { get; set; }
        public string Time { get; set; }
        
    }
}