using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrudFE.Models;
using System.Threading.Tasks;

namespace CrudFE.Services
{
    public class ApiDataService
    {
        static UserRequestClient requestClient = new UserRequestClient();
        public async Task<List<UserModel>> GetUserList()
        {
            var users = await requestClient.GetUsersAsync();
            return users;
        }

        public async Task<UserModel> GetUser(int userId)
        {
            var users = await requestClient.GetUserAsync(userId);
            return users;
        }

        public async Task<bool> UpdateUserAsync(UserModel user)
        {
            return await requestClient.UpdateUserAsync(user);
        }

        public async Task<bool> CreateUserAsync(UserModel user)
        {
            return await requestClient.CreateUserAsync(user);
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            return await requestClient.DeleteUserAsync(userId);
        }
    }
}