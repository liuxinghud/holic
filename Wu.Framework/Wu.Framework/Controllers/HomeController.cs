using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wu.Framework.Data;
using Wu.Framework.Entity;

namespace Wu.Framework.Controllers
{
    public class HomeController : Controller
    {
        public UserService UserService { get; set; }

        public ActionResult Index()
        {
            var ulist = UserService.UserList<User>(x => x.Gender);
            return View(ulist);
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