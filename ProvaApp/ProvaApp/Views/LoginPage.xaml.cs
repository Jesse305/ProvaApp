using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProvaApp.Services;
using ProvaApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProvaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {

        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginPageViewModel();
        }
    }

    
}