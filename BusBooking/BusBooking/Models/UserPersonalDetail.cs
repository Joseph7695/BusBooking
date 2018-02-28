using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.Models
{
    public class UserPersonalDetail
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string AspNetUserId { get; set; }
        public string IdentificationNumber { get; set; }
        public string ContactNumber { get; set; }
    }
}
