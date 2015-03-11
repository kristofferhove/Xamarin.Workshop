using Fredrikstad.Forms.Views;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Fredrikstad.Forms
{
    public class App : Application
    {
        const string applicationURL = @"https://xamarinworkshop.azure-mobile.net/";
        const string applicationKey = @"AvPsdAyZoCFqltPAOOMBqFNcczEDYx22";
        static MobileServiceClient client;

        public App()
        {
            // The root page of your application
            client = new MobileServiceClient(applicationURL, applicationKey);
            MainPage = new NavigationPage(new ItemsTablePage(client));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}


//MainPage = new ContentPage
//            {
//                Content = new StackLayout
//                {
//                    VerticalOptions = LayoutOptions.Center,
//                    Children = {
//                        new Label {
//                            XAlign = TextAlignment.Center,
//                            Text = "Welcome to Xamarin Forms!"
//                        }
//                    }
//                }
//            };