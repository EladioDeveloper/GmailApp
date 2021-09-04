using GmailApp.Models;
using GmailApp.Services;
using GmailApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GmailApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ComposePage : ContentPage
    {
        public ComposePage()
        {
            InitializeComponent();
        }
        public ComposePage(ObservableCollection<Email> Emails)
        {
            InitializeComponent();
            BindingContext = new ComposeViewModel(new NavigationService(), Emails);
        }
    }
}