using GuildCars.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Sales()
        {
            var context = new ApplicationDbContext();
            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);

            List<ApplicationUser> userList = new List<ApplicationUser>();
            userList = context.Users.ToList().Where(x => manager.IsInRole(x.Id, "Sales")).ToList();


            return View(userList);
        }

        public ActionResult Inventory()
        {
            return View();
        }
    }
}