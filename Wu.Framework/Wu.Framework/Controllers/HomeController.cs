using Newtonsoft.Json;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wu.Framework.Core;
using Wu.Framework.Data;
using Wu.Framework.Entity;

namespace Wu.Framework.Controllers
{
    public class HomeController : Controller
    {
        public UserService UserService { get; set; }
        public ActionResult Index()
        {
             var ulist = UserService.UserList(x=>x.IsDeleted==false,1,20);
            return View(ulist);
        }

        public ActionResult About()
        {
          var u=  RepositoryManager.Default.Of<User>().Get(1000);
            //  var nlog = UserService.Log();
            var log = new List<OperationLog>();
            ViewBag.Message = "Your application description page.";
            return View(log);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}