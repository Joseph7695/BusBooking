using BusBooking.Helpers;
using BusBooking.Model;
using BusBooking.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.Services
{
    public class ApiServices
    {
        DateTime tokenExpireDate = new DateTime();

        public async Task<bool> RegisterAsync(string email, string password, string confirmPassword)
        {
            var client = new HttpClient();

            var model = new RegisterBindingModel
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("https://rsmswebapi.azurewebsites.net/api/Account/Register", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<List<Location>> GetLocationAsync(string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                "Bearer", accessToken);

            var json = await client.GetStringAsync("https://rsmswebapi.azurewebsites.net/api/Location");
            var location = JsonConvert.DeserializeObject<List<Location>>(json);

            return location;
        }

        public async Task<List<Location>> GetLocationDetailAsync()
        {
            var client = new HttpClient();

            var json = await client.GetStringAsync("https://rsmswebapi.azurewebsites.net/api/Location");
            var location = JsonConvert.DeserializeObject<List<Location>>(json);

            return location;
        }

        public async Task<BookingStatus> GetBookingStatusAsync(string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                "Bearer", accessToken);

            var json = await client.GetStringAsync("https://rsmswebapi.azurewebsites.net/api/Account/UserInfo");
            var bookingStatus = JsonConvert.DeserializeObject<BookingStatus>(json);

            return bookingStatus;
        }

        public async Task<BusBookingDetail> GetBusBookingDetailAsync(string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                "Bearer", accessToken);

            var json = await client.GetStringAsync("https://rsmswebapi.azurewebsites.net/api/Account/UserInfo");
            var busBookingDetail = JsonConvert.DeserializeObject<BusBookingDetail>(json);

            return busBookingDetail;
        }

        public async Task<UserPersonalDetail> GetUserPersonalDetailAsync(string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                "Bearer", accessToken);

            var json = await client.GetStringAsync("https://rsmswebapi.azurewebsites.net/api/Account/UserInfo");
            var userPersonalDetail = JsonConvert.DeserializeObject<UserPersonalDetail>(json);

            return userPersonalDetail;
        }

        public async Task<string> LoginAsync(string userName, string password)
        {
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", userName),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password"),
            };

            var request = new HttpRequestMessage(
                HttpMethod.Post, "https://rsmswebapi.azurewebsites.net/Token");

            request.Content = new FormUrlEncodedContent(keyValues);

            var client = new HttpClient();
            var response = await client.SendAsync(request);

            var jwt = await response.Content.ReadAsStringAsync();

            JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(jwt);
            
            var accessToken = jwtDynamic.Value<string>("access_token");
            var accessTokenExpiration = jwtDynamic.Value<DateTime>(".expires");
            Settings.AccessTokenExpiration = accessTokenExpiration;

            //tokenExpireDate = DateTime.Parse(jwtDynamic.Value<string>(""));
            //DateTime.Now
            return accessToken;
        }

        public async Task<UserInfo> GetUserInfoAsync(string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                "Bearer", accessToken);

            var json = await client.GetStringAsync("https://rsmswebapi.azurewebsites.net/api/Account/UserInfo");
            var info = JsonConvert.DeserializeObject<UserInfo>(json);

            return info;
        }

        // PUT api/UserDetail/{id}
        //public async Task<bool> PutUserDetailAsync(string accessToken )
    }
}
