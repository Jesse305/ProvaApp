using System;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;
using ProvaApp.Droid;
using System.Threading.Tasks;
using ProvaApp.Services;

[assembly: Dependency(typeof(AuthenticateDroid))]
namespace ProvaApp.Droid
{
    public class AuthenticateDroid : IAuthenticate
    {

        public async Task<MobileServiceUser> Authenticate(MobileServiceClient client, MobileServiceAuthenticationProvider provider)
        {
            
            try
            {
                return await client.LoginAsync(Forms.Context, provider);
            }
            catch ( Exception)
            {
                
                return null;
            }
        }

        
    }    
}