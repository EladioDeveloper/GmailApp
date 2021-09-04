using GmailApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GmailApp.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected BaseViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        protected INavigationService NavigationService { get; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
