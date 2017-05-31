using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;
using ProvaApp.Services;
using ProvaApp.UWP;

[assembly: Dependency(typeof(AuthenticateUWP))]
namespace ProvaApp.UWP
{
    public class AuthenticateUWP : IAuthenticate
    {
        public async Task<MobileServiceUser> Authenticate(MobileServiceClient client, MobileServiceAuthenticationProvider provider)
        {
            try
            {
                return await client.LoginAsync(provider);
            }
            catch (Exception e)
            {

                return null;
            }
        }
    }
}
