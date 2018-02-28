using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusBooking.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BusBooking.Services;

namespace BusBooking.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            //Initialise();
            
            //PickerFrom.Items.Add("Some Values 1");
            //PickerFrom.Items.Add("Some Values 2");
            //PickerFrom.Items.Add("Some Values 3");
            //PickerFrom.Items.Add("Some Values 4");

            //PickerTo.Items.Add("Some Values 1");
            //PickerTo.Items.Add("Some Values 2");
            //PickerTo.Items.Add("Some Values 3");
            //PickerTo.Items.Add("Some Values 4");
        }

        //public async Task Initialise()
        //{
        //    var apiServices = new ApiServices();
        //    var Location = await apiServices.GetLocationDetailAsync();

        //    foreach (Location loc in Location)
        //    {
        //        FromPicker.Items.Add(loc.Name);
        //    }
        //}
        //private void PickerFrom_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    var name = PickerFrom.SelectedItem;

        //    DisplayAlert("Alert", "Selected value" + name.ToString(), "OK");
        //}
    }
}