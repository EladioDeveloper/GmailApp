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
        private Email _email;

        public EmailDetailViewModel(INavigationService navigationService, Email email) : base(navigationService)
        {
            _email = email;
        }

       
    }
}
