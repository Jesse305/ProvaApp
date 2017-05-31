using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

namespace ProvaApp.Services
{
    public class AzureService
    {
        static readonly string AppUrl = "endereço do seu backend"; //O endereço onde Mobile Service Azure
        public MobileServiceClient Client { get; set; } = null;

        public void Initialize()
        {
            Client = new MobileServiceClient(AppUrl);
        }

        public async Task<MobileServiceUser> LoginAsync()
        {
            Initialize();
            var auth = DependencyService.Get<IAuthenticate>();
            var user = await auth.Authenticate(Client, MobileServiceAuthenticationProvider.Facebook);


            if(user == null)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Ops! ", "Não conseguimos validar seu login!", "OK");
                });
                return null;
            }
            await App.Current.MainPage.DisplayAlert("Obrigado! ", "Login validado com sucesso!", "OK");
            return user;
        }
        
    }
}
