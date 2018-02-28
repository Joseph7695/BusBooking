using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.Models
{
    public class BusBookingDetail
    {
        public int Id { get; set; }
        public int UserDetailId { get; set; }
        public string FullName { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public string PickupDateTime { get; set; }
        public string BookingStatus { get; set; }
    }
}
