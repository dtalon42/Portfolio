using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieLibrary.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult MovieLibrary()
        {
            return View();
        }

        public ActionResult AddMovie()
        {
            return View();
        }

        public ActionResult EditMovie()
        {
            return View();
        }

        public ActionResult Details()
        { 
            return View();
        }
    }
}
