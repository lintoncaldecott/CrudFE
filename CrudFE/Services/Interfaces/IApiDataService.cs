using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudFE.Models;

namespace CrudFE.Services
{
    public interface IApiDataService
    {
        Task<List<UserModel>> GetUserList();

        Task<UserModel> GetUser(int userId);

        Task<bool> UpdateUserAsync(UserModel user);

        Task<bool> CreateUserAsync(UserModel user);

        Task<bool> DeleteUserAsync(int userId);       
    }
}
