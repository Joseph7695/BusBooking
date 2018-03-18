using BusBooking.Helpers;
using BusBooking.Model;
using BusBooking.Models;
using BusBooking.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BusBooking.ViewModels
{
    //public class Keyword
    //{
    //    public string text { get; set; }

    //    public Keyword()
    //    {
    //        text = "ExampleString";
    //    }
    //}

    public class AccountViewModel : INotifyPropertyChanged
    {
        private ApiServices _apiServices = new ApiServices();
        private UserInfo _userInfo { get; set; }
        private UserPersonalDetail _userPersonalDetail { get; set; }

        //public Keyword keyword { get; set; }
        public string keyword { get; set; }

        public UserInfo UserInfo
        {
            get { return _userInfo; }
            set
            {
                _userInfo = value;
                OnPropertyChanged();
            }
        }

        public UserPersonalDetail UserPersonalDetail
        {
            get { return _userPersonalDetail; }
            set
            {
                _userPersonalDetail = value;
                OnPropertyChanged();
            }
        }

        public AccountViewModel()
        {
            Initialise();
        }

        public async Task Initialise()
        {
            var accesstoken = Settings.AccessToken;
            if (!string.IsNullOrEmpty(accesstoken))
            {
                var UserPersonalDetailArray = await _apiServices.GetUserPersonalDetailAsync(accesstoken);
                UserPersonalDetail = UserPersonalDetailArray[5];
                UserInfo = await _apiServices.GetUserInfoAsync(accesstoken);
                //UserPersonalDetail = await _apiServices.GetUserPersonalDetailAsync(accesstoken);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand LogoutCommand
        {
            get
            {
                return new Command(() =>
                {
                    Settings.AccessToken = "";
                    Settings.Username = "";
                    Settings.Password = "";
                });
            }
        }

        public ICommand SaveChangesCommand
        {
            get
            {
                return new Command(async() =>
                {
                    if (_userPersonalDetail != null)
                    {
                        await _apiServices.PutUserDetailAsync(_userPersonalDetail.Id, _userPersonalDetail);
                    }
                });
            }
        }

        public ICommand TestingLoadCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var accesstoken = Settings.AccessToken;
                    if (!string.IsNullOrEmpty(accesstoken))
                    {
                        var UserPersonalDetailArray = await _apiServices.GetUserPersonalDetailAsync(accesstoken);
                        UserPersonalDetail = UserPersonalDetailArray[6];
                    }
                });
            }
        }

        public ICommand LoadProfileWithKeywordCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var accesstoken = Settings.AccessToken;
                    if (!string.IsNullOrEmpty(accesstoken) && (!string.IsNullOrEmpty(keyword)))
                    {
                        var UserPersonalDetailArray = await _apiServices.GetUserPersonalDetailAsync(accesstoken);
                        foreach (UserPersonalDetail user in UserPersonalDetailArray)
                        {
                            if (user.FullName == keyword)
                            {
                                UserPersonalDetail = user;
                                break;
                            }
                        }
                    }
                });
            }
        }
    }
}
