using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace XamarinAzureSocialLogin
{
    public static class SocialLogin
    {
        private static readonly MobileServiceClient Client = new MobileServiceClient("YOUR_APP_URL", "YOUR_APP_KEY");

        private static async Task<SocialLoginResult> GetUserData()
        {
            return await Client.InvokeApiAsync<SocialLoginResult>("getextrauserinfo", HttpMethod.Get, null);
        }

        private static async Task<MobileServiceUser> Authenticate(MobileServiceAuthenticationProvider provider)
        {
            try
            {
#if __IOS__
                    return await Client.LoginAsync(UIKit.UIApplication.SharedApplication.KeyWindow.RootViewController, provider);
#elif WINDOWS_PHONE
                return await Client.LoginAsync(provider);
#else
                return await Client.LoginAsync(Xamarin.Forms.Forms.Context, provider);
#endif
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static async Task<SocialLoginResult> AuthenticateGoogle()
        {
            await Authenticate(MobileServiceAuthenticationProvider.Google);
            return await GetUserData();
        }

        public static async Task<SocialLoginResult> AuthenticateTwitter()
        {
            await Authenticate(MobileServiceAuthenticationProvider.Twitter);
            return await GetUserData();
        }

        public static async Task<SocialLoginResult> AuthenticateFacebook()
        {
            await Authenticate(MobileServiceAuthenticationProvider.Facebook);
            return await GetUserData();
        }
    }
}