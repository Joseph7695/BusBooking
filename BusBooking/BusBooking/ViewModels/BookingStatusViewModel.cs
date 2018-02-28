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
    public class BookingStatusViewModel
    {
        private ApiServices _apiServices = new ApiServices();
        private BookingStatus _bookingStatus { get; set; }

        public BookingStatus bookingStatus
        {
            get { return _bookingStatus; }
            set
            {
                _bookingStatus = value;
                OnPropertyChanged();
            }
        }

        public BookingStatusViewModel()
        {
            Initialise();
        }

        public async Task Initialise()
        {
            var accesstoken = Settings.AccessToken;
            if (!string.IsNullOrEmpty(accesstoken))
                bookingStatus = await _apiServices.GetBookingStatusAsync(accesstoken);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
