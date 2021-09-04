using GmailApp.Models;
using GmailApp.Services;
using Plugin.LocalNotifications;
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
        public ICommand AttachCommand { get; }
        public ComposeViewModel(INavigationService navigationService, ObservableCollection<Email> Emails) : base(navigationService)
        {
            _emails = Emails;
            SendCommand = new Command<Email>(SendEmail);
            AttachCommand = new Command<Email>(Attach);
        }

        private async void Attach(Email email)
        {
            var result = await Xamarin.Essentials.MediaPicker.PickPhotoAsync(new Xamarin.Essentials.MediaPickerOptions
            {
                Title = "Please pick a photo"
            });
        }

        private async void SendEmail(Email email)
        {
            email = Email;
            _emails.Add(new Email(email.From, email.Subject, email.Body, DateTime.Now.ToString("h:mm tt")));
            Xamarin.Essentials.Preferences.Set($"Email#{_emails.Count}", $"{email.From}, {email.Subject}, {email.Body}, {email.Time}");
            Xamarin.Essentials.Preferences.Set("Counter", _emails.Count);

            var message = new Xamarin.Essentials.EmailMessage
            {
                Subject = email.Subject,
                Body = email.Body,
                To = new List<string> { "eladiodeveloper@gmail.com"},
            };

            await Xamarin.Essentials.Email.ComposeAsync(message);
            CrossLocalNotifications.Current.Show("GMAIL REPLICATE APP", "Email Sent", 0, DateTime.Now.AddSeconds(7));
            await NavigationService.NavigateBackAsync();
        }
    }
}
