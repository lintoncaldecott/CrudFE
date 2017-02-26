using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrudFE.Models;
using CrudFE.Services;
using System.Threading.Tasks;
using PagedList;
namespace CrudFE.Controllers
{
    
    public class UserController : Controller
    {
        IApiDataService _service;
        public UserController(ApiDataService service)
        {
            _service = service;
        }
        // GET: User
        public async Task<ActionResult> UserList(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var users = await _service.GetUserList();
            //var contacts = from s in dbContext.ContactModels
            //               select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.LastName.ToUpper().Contains(searchString.ToUpper())
                                       || s.FirstName.ToUpper().Contains(searchString.ToUpper())).ToList();
            }
            switch (sortOrder)
            {
                case "name_desc":
                    users = users.OrderByDescending(s => s.LastName).ToList();
                    break;
                default:  // Name ascending 
                    users = users.OrderBy(s => s.LastName).ToList();
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(users.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Edit(UserModel user)
        {
            return View(user);
        }

        [ActionName("Edit")]
        [HttpPost]
        public async Task<ActionResult> Edit_User([Bind(Include = "UserId,UserName,FirstName,LastName,ContactNumber")] UserModel user)
        {
            var result = await _service.UpdateUserAsync(user);

            return RedirectToAction("UserList");
        }

        public async Task<ActionResult> Details(int? id)
        {
            var user = await _service.GetUser(id.Value);

            return View(user);
        }

        public ActionResult Delete(UserModel user)
        {
            return View(user);
        }

        [ActionName("Delete")]
        [HttpPost]
        public async Task<ActionResult> Delete_User(int? userId)
        {
            var result = await _service.DeleteUserAsync(userId.Value);
            return RedirectToAction("UserList");
        }

        public ActionResult Create()
        {
            var user = new UserModel{};
            return View(user);
        }

        [ActionName("Create")]
        [HttpPost]
        public async Task<ActionResult> Create_user(UserModel user)
        {
            var result = await _service.CreateUserAsync(user);

            return RedirectToAction("UserList");
        }
    }
}