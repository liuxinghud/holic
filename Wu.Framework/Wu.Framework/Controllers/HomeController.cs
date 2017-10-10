using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wu.Framework.Data;

namespace Wu.Framework.Controllers
{
    public class HomeController : Controller
    {
        public UserService UserService { get; set; }

        public ActionResult Index()
        {
        var user = UserService.GetUser(1000);
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
    }
}