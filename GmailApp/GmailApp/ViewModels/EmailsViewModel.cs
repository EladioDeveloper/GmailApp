using GmailApp.Models;
using GmailApp.Services;
using GmailApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GmailApp.ViewModels
{
    public class EmailsViewModel : BaseViewModel
    {
        private Email _email;

        public Email SelectedEmail
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                if(_email != null)
                {
                    SelectedEmailCommand.Execute(_email);
                }
            }
        }

        private ICommand SelectedEmailCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand ShowCommand { get; }

        public ObservableCollection<Email> Emails { get; set; } = new ObservableCollection<Email>(){};

        public EmailsViewModel(INavigationService navigationService) : base(navigationService)
        {
            SelectedEmailCommand = new Command<Email>(OnPlaceSelected);
            AddCommand = new Command<Email>(AddEmail);
            DeleteCommand = new Command<Email>(DeleteEmail);
            int counter = Xamarin.Essentials.Preferences.Get("Counter", 0);
            for (int i = 1; i <= counter; i++)
            {
                var getEmail = Xamarin.Essentials.Preferences.Get($"Email#{i}", "").Split(',');
                Emails.Add(new Email(getEmail[0], getEmail[1], getEmail[2], getEmail[3]));
            }
        }
        private void DeleteEmail(Email email)
        {
            Emails.Remove(email);
            Xamarin.Essentials.Preferences.Clear();
            int counter = 1;
            foreach (var emailItem in Emails)
            {
                Xamarin.Essentials.Preferences.Set($"Email#{counter}", $"{emailItem.From}, {emailItem.Subject}, {emailItem.Body}, {emailItem.Time}");
                Xamarin.Essentials.Preferences.Set("Counter", counter);
                counter++;
            }
        }

        private async void AddEmail(Email email)
        {
            await NavigationService.NavigateAsync(new ComposePage(Emails));
        }

        private async void OnPlaceSelected(Email email)
        {
            await NavigationService.NavigateAsync(new EmailDetailPage(email));
        }
    }
}
