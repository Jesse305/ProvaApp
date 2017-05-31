using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.WindowsAzure.MobileServices;
using ProvaApp.Services;
using ProvaApp.Views;

namespace ProvaApp.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        public Command LogarCommand { get; set; }
        readonly AzureService azureService;

        private string _texto;
        public string Texto
        {
            get { return _texto; }
            set { SetProperty(ref _texto, value); }
        }

        public LoginPageViewModel()
        {
            Texto = "Clique no botão\n para entrar!";
            azureService = new AzureService();
            LogarCommand = new Command(Logar);
        }

        private void Logar()
        {
            LogarAsync();
        }

        async Task LogarAsync()
        {
            var user = await azureService.LoginAsync();
            if(user != null)
            {

                await Application.Current.MainPage.Navigation.PushAsync(new ListCarsPage());
            }
            else
            {
                Texto = "Erro de Login, tente novamente!";
            }

        }
    }
}
