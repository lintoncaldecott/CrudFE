using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrudFE.Models;
using CrudFE.Services;
using System.Threading.Tasks;

namespace CrudFE.Controllers
{
    
    public class UserController : Controller
    {
        // GET: User
        public async Task<ActionResult> UserList()
        {
            ApiDataService service = new ApiDataService();
            var users = await service.GetUserList();

            return View(users);
        }
        public ActionResult Edit()
        {


            return View(new List<UserModel>());
        }
        public ActionResult Details()
        {
            var userList = new List<UserModel>
            {
               
            };

            return View(userList);
        }
        public ActionResult Delete()
        {
            var userList = new List<UserModel>
            {
               
            };

            return View(userList);
        }
    }
}