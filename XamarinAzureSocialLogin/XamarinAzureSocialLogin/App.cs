using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

namespace XamarinAzureSocialLogin
{
	public class App : Application
	{
		public App ()
		{
            var welcomeLabel = new Label
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            var fbButton = new Button
            {
                Text = "Facebook",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.FromHex("#3b5998")
            };
            var googleButton = new Button
            {
                Text = "Google+",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.FromHex("#d50f25")
            };
            var twitterButton = new Button
            {
                Text = "Twitter",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.FromHex("#55acee")
            };

		    fbButton.Clicked += async (sender, args) =>
		    {
		        var user = await SocialLogin.AuthenticateFacebook();
		        welcomeLabel.Text = string.Format("Welcome {0}!", user.Message.Email);
		    };

            googleButton.Clicked += async (sender, args) =>
            {
                var user = await SocialLogin.AuthenticateGoogle();
                welcomeLabel.Text = string.Format("Welcome {0}!", user.Message.Email);
            };

            twitterButton.Clicked += async (sender, args) =>
            {
                var user = await SocialLogin.AuthenticateTwitter();
                welcomeLabel.Text = string.Format("Welcome {0}!", user.Message.Email);
            };

            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
					    fbButton,
                        googleButton,
                        twitterButton,
					    welcomeLabel
				    }
                }
            };
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
