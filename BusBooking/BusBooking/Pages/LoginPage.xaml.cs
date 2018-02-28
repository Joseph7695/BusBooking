using BusBooking.Helpers;
using BusBooking.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BusBooking.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async Task Button_Clicked(object sender, EventArgs e)
        {
            var _apiServices = new ApiServices();
            var accesstoken = await _apiServices.LoginAsync(Username.Text, Password.Text);

            Settings.AccessToken = accesstoken;
            if (!string.IsNullOrEmpty(accesstoken))
                await Navigation.PushAsync(new MainPage());
        }
    }
}