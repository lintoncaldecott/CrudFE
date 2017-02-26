using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrudFE.Models;
using System.Threading.Tasks;

namespace CrudFE.Services
{
    public class ApiDataService : IApiDataService
    {

        IUserRequestClient _requestClient;
        public ApiDataService(UserRequestClient requestClient)
        {
            _requestClient = requestClient;
        }
        
        public async Task<List<UserModel>> GetUserList()
        {
            var users = await _requestClient.GetUsersAsync();
            return users;
        }

        public async Task<UserModel> GetUser(int userId)
        {
            var users = await _requestClient.GetUserAsync(userId);
            return users;
        }

        public async Task<bool> UpdateUserAsync(UserModel user)
        {
            return await _requestClient.UpdateUserAsync(user);
        }

        public async Task<bool> CreateUserAsync(UserModel user)
        {
            return await _requestClient.CreateUserAsync(user);
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            return await _requestClient.DeleteUserAsync(userId);
        }
    }
}