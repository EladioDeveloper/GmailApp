﻿using GmailApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GmailApp.ViewModels
{
    public class EmailsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
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

        public ObservableCollection<Email> Emails { get; set; } = new ObservableCollection<Email>()
        {
            new Email("Uber eats", "¡Tienes 35% de descuento!", DateTime.Now.ToString("h:mm tt")),
            new Email("Uber eats", "¡Tienes 35% de descuento!", DateTime.Now.ToString("h:mm tt")),
            new Email("Uber eats", "¡Tienes 35% de descuento!", DateTime.Now.ToString("h:mm tt")),
            new Email("Uber eats", "¡Tienes 35% de descuento!", DateTime.Now.ToString("h:mm tt")),
            new Email("Uber eats", "¡Tienes 35% de descuento!", DateTime.Now.ToString("h:mm tt")),
            new Email("Uber eats", "¡Tienes 35% de descuento!", DateTime.Now.ToString("h:mm tt"))
        };

        public EmailsViewModel()
        {
            SelectedEmailCommand    = new Command<Email>(OnPlaceSelected);
            AddCommand              = new Command<Email>(AddEmail);
            DeleteCommand           = new Command<Email>(DeleteEmail);
            ShowCommand             = new Command<Email>(ShowEmail);
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
            var name = await App.Current.MainPage.DisplayPromptAsync("Especifique", "Nombre");
            var subject = await App.Current.MainPage.DisplayPromptAsync("Especifique", "Subject");

            Emails = new ObservableCollection<Email>()
            {

                new Email("Uber eats", "¡Tienes 35% de descuento!", DateTime.Now.ToString("h:mm tt")),
                new Email("Uber eats", "¡Tienes 35% de descuento!", DateTime.Now.ToString("h:mm tt")),
                new Email("Uber eats", "¡Tienes 35% de descuento!", DateTime.Now.ToString("h:mm tt")),
                new Email("Uber eats", "¡Tienes 35% de descuento!", DateTime.Now.ToString("h:mm tt")),
                new Email("Uber eats", "¡Tienes 35% de descuento!", DateTime.Now.ToString("h:mm tt")),
                new Email("Uber eats", "¡Tienes 35% de descuento!", DateTime.Now.ToString("h:mm tt")),
                new Email(name, subject, DateTime.Now.ToString("h:mm tt"))
            };
        }

        private async void OnPlaceSelected(Email email)
        {
            await App.Current.MainPage.DisplayAlert(email.Name, email.Subject, "OK");
        }
    }
}
