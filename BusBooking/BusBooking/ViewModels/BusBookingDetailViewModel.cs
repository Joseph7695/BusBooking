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
    public class BusBookingDetailViewModel
    {
        private ApiServices _apiServices = new ApiServices();
        private BusBookingDetail _busBookingDetail { get; set; }

        public BusBookingDetail busBookingDetail
        {
            get { return _busBookingDetail; }
            set
            {
                _busBookingDetail = value;
                OnPropertyChanged();
            }
        }

        public BusBookingDetailViewModel()
        {
            Initialise();
        }

        public async Task Initialise()
        {
            var accesstoken = Settings.AccessToken;
            if (!string.IsNullOrEmpty(accesstoken))
                busBookingDetail = await _apiServices.GetBusBookingDetailAsync(accesstoken);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
