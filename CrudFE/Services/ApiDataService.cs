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

    }
}