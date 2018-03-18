using BusBooking.Helpers;
using BusBooking.Models;
using BusBooking.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.ViewModels
{
    public class LocationViewModel
    {
        private ApiServices _apiServices = new ApiServices();
        private Location[] _location { get; set; }

        public Location[] Location
        {
            get { return _location; }
            set
            {
                _location = value;
                OnPropertyChanged();
            }
        }

        public Location fromLocation { get; set; }
        public Location toLocation { get; set; }

        public LocationViewModel()
        {
            Initialise();
        }

        public async Task Initialise()
        {
            var accesstoken = Settings.AccessToken;
            if (!string.IsNullOrEmpty(accesstoken))
            {
                Location = await _apiServices.GetLocationDetailAsync();
                //var apiServices = new ApiServices();

                //Location = await _apiServices.GetLocationDetailAsync();
            }
                
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
