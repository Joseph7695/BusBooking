using BusBooking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.Services
{
    public class UserInfoServices
    {
        public UserInfo GetUserInfo()
        {
            var userinfo = new UserInfo
            {
                Email = "Placeholder Email",
                HasRegistered = true,
                LoginProvider = "Placeholder Provider",
            };

            return userinfo;
        }
    }
}
