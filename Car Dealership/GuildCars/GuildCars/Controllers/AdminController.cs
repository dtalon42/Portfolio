using GuildCars.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using GuildCars.Models.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GuildCars.Controllers
{
    [System.Web.Mvc.Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }


        // GET: Admin
        public ActionResult Vehicles()
        {
            return View();
        }

        public ActionResult AddVehicle()
        {
            return View();
        }

        public ActionResult EditVehicle(int id)
        {
            return View();
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Users()
        {
            var users = (from user in context.Users
                         select new
                         {
                             userId = user.Id,
                             lastName = user.lastName,
                             firstName = user.firstName,
                             Email = user.Email,
                             RoleNames = (from userRole in user.Roles
                                          join role in context.Roles on userRole.RoleId
                                          equals role.Id
                                          select role.Name).ToList()
                         }).ToList().Select(p => new Users()
                         {
                             userId = p.userId,
                             lastName = p.lastName,
                             firstName = p.firstName,
                             Email = p.Email,
                             Role = string.Join(",", p.RoleNames)
                         });
            return View(users);
        }
        [System.Web.Mvc.HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddUser(Users model)
        {
            if (string.IsNullOrEmpty(model.password))
            {
                ModelState.AddModelError("Password", "Password is required");
            }
            if (string.IsNullOrEmpty(model.confPassword))
            {
                ModelState.AddModelError("Password", "Password and password confirmation do not match");
            }
            if (model.password != model.confPassword)
            {
                ModelState.AddModelError("Password", "Password and password confirmation do not match");
            }

            if(!ModelState.IsValid)
            {
                return View(model);
            }
            
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var user = new ApplicationUser();
            user.firstName = model.firstName;
            user.lastName = model.lastName;
            user.Email = model.Email;
            user.UserName = model.Email;
            var result = await UserManager.CreateAsync(user, model.password);
            if(result.Succeeded)
            {
                await UserManager.AddToRoleAsync(user.Id, model.Role);
                return RedirectToAction("Users");
            }
            AddErrors(result);
            return View(model);
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult EditUser(string id)
        {
            var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(store);

            ApplicationUser appUser = new ApplicationUser();
            appUser = manager.FindById(id);
            Users userToEdit = new Users();
            userToEdit.userId = id;
            userToEdit.firstName = appUser.firstName;
            userToEdit.lastName = appUser.lastName;
            userToEdit.Email = appUser.Email;
            var roleID = appUser.Roles.SingleOrDefault().RoleId;
            userToEdit.Role = context.Roles.SingleOrDefault(r => r.Id == roleID).Name;

            return View(userToEdit);
        }

        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditUser(Users model)
        {
            if (!ModelState.IsValid) 
            { 
                return View(model);
            }
            var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(store);
            var currentUser = manager.FindById(model.userId);
            var oldRoleId = currentUser.Roles.SingleOrDefault().RoleId;
            var oldRoleName = context.Roles.SingleOrDefault(r => r.Id == oldRoleId).Name;

            if(oldRoleName != model.Role)
            {
                manager.RemoveFromRole(currentUser.Id, oldRoleName);
                manager.AddToRole(currentUser.Id, model.Role);
            }

            currentUser.firstName = model.firstName;
            currentUser.lastName = model.lastName;
            await manager.UpdateAsync(currentUser);
            var ctx = store.Context;
            ctx.SaveChanges();

            return RedirectToAction("Users");
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        public ActionResult Makes()
        {
            var context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user = UserManager.FindById(User.Identity.GetUserId());

            return View(user);
        }

        public ActionResult Models()
        {
            var context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user = UserManager.FindById(User.Identity.GetUserId());

            return View(user);
        }

        public ActionResult AddSpecials()
        {
            return View();
        }

        

    }
}