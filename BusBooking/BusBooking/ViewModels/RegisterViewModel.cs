using BusBooking.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BusBooking.ViewModels
{
    public class RegisterViewModel
    {
        Services.ApiServices _apiServices = new Services.ApiServices();

        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {
                    bool result = await _apiServices.RegisterAsync(
                        Email, Password, ConfirmPassword);
                    bool a = result;

                    Settings.Username = Email;
                    Settings.Password = Password;

                });
            }
        }
    }
}
