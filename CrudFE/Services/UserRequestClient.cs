﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
using CrudFE.Models;
using Newtonsoft.Json;
using System.Configuration;
namespace CrudFE.Services
{
    public class UserRequestClient : HttpClient
    {
        static HttpClient client = new HttpClient();
        public UserRequestClient()
        {   
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["UserApi"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
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
            catch (Exception ex)
            {
                throw;
            }
            return users;
        }
    }
}