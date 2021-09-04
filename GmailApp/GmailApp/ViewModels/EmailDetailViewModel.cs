using GmailApp.Models;
using GmailApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GmailApp.ViewModels
{
    class EmailDetailViewModel : BaseViewModel
    {
        public Email Email { get; set; } = new Email();

        public EmailDetailViewModel(INavigationService navigationService, Email email) : base(navigationService)
        {
            Email = email;
        }

       
    }
}
