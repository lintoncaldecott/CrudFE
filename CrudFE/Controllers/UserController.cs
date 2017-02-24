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
        public ActionResult Edit(UserModel user)
        {
            ApiDataService service = new ApiDataService();
            
            return View(user);
        }

        [ActionName("Edit")]
        [HttpPost]
        public async Task<ActionResult> Edit_User([Bind(Include = "UserId,UserName,FirstName,LastName,ContactNumber")] UserModel user)
        {
            ApiDataService service = new ApiDataService();
            var result = await service.UpdateUserAsync(user);

            return RedirectToAction("UserList");
        }
        public async Task<ActionResult> Details(int? id)
        {
            ApiDataService service = new ApiDataService();
            var user = await service.GetUser(id.Value);

            return View(user);
        }
        public ActionResult Delete()
        {
            var userList = new List<UserModel>
            {
               
            };

            return View(userList);
        }

        public ActionResult Create()
        {
            var user = new UserModel{};

            return View(user);
        }

        [ActionName("Create")]
        [HttpPost]
        public ActionResult Create_user(UserModel user)
        {
            var userList = new List<UserModel>
            {

            };

            return View();
        }
    }
}