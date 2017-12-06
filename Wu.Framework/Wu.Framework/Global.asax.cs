using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Wu.Framework.Core;

namespace Wu.Framework.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
      //  private static IWindsorContainer container;
        protected void Application_Start()
        {
             Data.PersistenceFacility.CreateMysqlFactoryAsync();
            AreaRegistration.RegisterAllAreas();
            BootstrapContainer();
            var res = InitMvc();

        }

        private async Task<bool> InitMvc()
        {
           await Task.Run(() =>
            {
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                BundleConfig.RegisterBundles(BundleTable.Bundles);
            });
            return true;
        }



        protected void Application_End(object sender, EventArgs e)
        {

            Core.Ioc.container?.Dispose();
        }

        void Application_BeginRequest(object sender, EventArgs e)
        {
            Task.WaitAll();
           // MsSqlConnection.Context = HttpContext.Current;
            //每次请求时第一个出发的事件，这个方法第一个执行
        }
        void Application_EndRequest(object sender, EventArgs e)
        {


            //   MsSqlConnection.CloseSession();
        }
        void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            //在执行验证前发生，这是创建验证逻辑的起点
        }

        void Application_AuthorizeRequest(object sender, EventArgs e)
        {
            //当安全模块已经验证了当前用户的授权时执行
        }

        private   void BootstrapContainer()
        {
           Core.Ioc.container= new WindsorContainer()
                .Install(FromAssembly.InThisApplication());
            var controllerFactory = new WindsorControllerFactory(Core.Ioc.container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}
