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
	public partial class EditProfilePage : ContentPage
	{
		public EditProfilePage ()
		{
			InitializeComponent ();
		}

        private void SaveChangesButton_Clicked(object sender, EventArgs e)
        {
            var _apiServices = new ApiServices();

            if (!string.IsNullOrEmpty(Settings.AccessToken))
            {
                var accesstoken = Settings.AccessToken;

                // Use put
            }
        }
    }
}