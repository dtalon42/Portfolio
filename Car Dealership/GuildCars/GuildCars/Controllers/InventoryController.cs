using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.Controllers
{
    [AllowAnonymous]
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            ViewBag.Message = "New inventory will be here.";
            return View();

        }

        public ActionResult Used()
        {
            ViewBag.Message = "Used inventory will be here.";
            return View();
        }

        public ActionResult Details(int id)
        {
            ViewBag.Message = "Vehicle Details";
            return View();
        }
    }
}