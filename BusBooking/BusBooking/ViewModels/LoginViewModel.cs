﻿using BusBooking.Helpers;
using BusBooking.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BusBooking.ViewModels
{
    public class LoginViewModel
    {
        //private INavigation navigation;
        private ApiServices _apiServices = new ApiServices();

        public string Username { get; set; }
        public string Password { get; set; }

        public LoginViewModel()
        {
            Username = Settings.Username;
            Password = Settings.Password;
        }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var accesstoken = await _apiServices.LoginAsync(Username, Password);
                    Settings.Username = Username;
                    Settings.Password = Password;
                    Settings.AccessToken = accesstoken;
                });
            }
        }
    }
}
