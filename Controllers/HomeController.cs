using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Community2.Models;

namespace Community2.Controllers
{
    public class HomeController : Controller
    {
        Database1Entities7 ctx = new Database1Entities7();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Signup()
        {
            return View();
        }
        public ActionResult AllServices()
        {
            List<service> list = ctx.services.ToList();
            return View(list);
        }
    }
}