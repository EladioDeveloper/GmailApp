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

        public ObservableCollection<Email> Emails { get; set; } = new ObservableCollection<Email>(){ };

        public EmailsViewModel(INavigationService navigationService) : base(navigationService)
        {
            SelectedEmailCommand = new Command<Email>(OnPlaceSelected);
            AddCommand = new Command<Email>(AddEmail);
            DeleteCommand = new Command<Email>(DeleteEmail);
            ShowCommand = new Command<Email>(ShowEmail);
        }

        private void ShowEmail(Email obj)
        {
            throw new NotImplementedException();
        }

        private void DeleteEmail(Email email)
        {
            Emails.Remove(email);
        }

        private async void AddEmail(Email obj)
        {
            await NavigationService.NavigateAsync(new ComposePage(Emails));
        }

        private async void OnPlaceSelected(Email email)
        {
            await App.Current.MainPage.DisplayAlert(email.From, email.Subject, "OK");
        }
    }
}
