using BusBooking.Helpers;
using BusBooking.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace BusBooking
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            SetMainPage();
            //MainPage = new NavigationPage( new BusBooking.Pages.RegisterPage());
        }

        private void SetMainPage()
        {
            if (!string.IsNullOrEmpty(Settings.AccessToken))
            {
                if (DateTime.UtcNow.AddHours(1) > Settings.AccessTokenExpiration)
                {
                    var vm = new LoginViewModel();
                    vm.LoginCommand.Execute(null);
                }
                MainPage = new NavigationPage(new BusBooking.MainPage());
            }
            else if (!string.IsNullOrEmpty(Settings.Username)
                && !string.IsNullOrEmpty(Settings.Password))
                MainPage = new NavigationPage(new BusBooking.Pages.LoginPage());
            else
                MainPage = new NavigationPage(new BusBooking.Pages.RegisterPage());
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
