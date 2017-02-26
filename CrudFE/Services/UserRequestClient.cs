using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
using CrudFE.Models;
using Newtonsoft.Json;
using System.Configuration;
using System.Net.Http.Headers;
using CrudFE.Services;

namespace CrudFE.Services
{
    public class UserRequestClient : HttpClient, IUserRequestClient
    {
        static HttpClient client;
        public UserRequestClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["UserApi"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<UserModel>> GetUsersAsync()
        {
            List<UserModel> users = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync("/api/users");
                if (response.IsSuccessStatusCode)
                {
                    var userString = await response.Content.ReadAsAsync<string>();
                    users = JsonConvert.DeserializeObject<List<UserModel>>(userString);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return users;
        }

        public async Task<UserModel> GetUserAsync(int userId)
        {
            UserModel users = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync("/api/users/" + userId);
                if (response.IsSuccessStatusCode)
                {
                    var userString = await response.Content.ReadAsAsync<string>();
                    users = JsonConvert.DeserializeObject<UserModel>(userString);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return users;
        }

        public async Task<bool> UpdateUserAsync(UserModel user)
        {
            try
            {
                string postData = JsonConvert.SerializeObject(user);
                HttpResponseMessage response = await client.PutAsJsonAsync("/api/users/" + user.UserId, user);
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }

        public async Task<bool> CreateUserAsync(UserModel user)
        {
            try
            {
                string postData = JsonConvert.SerializeObject(user);
                HttpResponseMessage response = await client.PostAsJsonAsync("/api/users/" + user.UserId, user);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync("/api/users/" + userId);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}