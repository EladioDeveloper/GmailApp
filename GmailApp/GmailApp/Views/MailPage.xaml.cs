using GmailApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GmailApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MailPage : ContentPage
    {
        public MailPage()
        {
            InitializeComponent();
            //BindingContext = new EmailsViewModel();
        }
    }
}