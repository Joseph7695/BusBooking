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

        private async void SaveChangesButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
            //await Navigation.PopAsync();
        }
    }
}