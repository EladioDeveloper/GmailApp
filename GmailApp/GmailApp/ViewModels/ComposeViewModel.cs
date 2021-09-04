using GmailApp.Models;
using GmailApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GmailApp.ViewModels
{
    public class ComposeViewModel : BaseViewModel
    {
        private ObservableCollection<Email> _emails;
        public Email Email { get; set; } = new Email();
        public ICommand SendCommand { get; }
        public ComposeViewModel(INavigationService navigationService, ObservableCollection<Email> Emails) : base(navigationService)
        {
            _emails = Emails;
            SendCommand = new Command<Email>(SendEmail);
        }

        private void SendEmail(Email email)
        {
            email = Email;
            _emails.Add(new Email(email.From, email.Subject, email.Body, DateTime.Now.ToString("h:mm tt")));
            NavigationService.NavigateBackAsync();
        }
    }
}
