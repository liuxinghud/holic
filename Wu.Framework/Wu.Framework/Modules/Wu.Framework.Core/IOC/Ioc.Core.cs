using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Web.Mvc;
using System.Reflection;

namespace Wu.Framework.Core
{
    public partial class Ioc : IWindsorInstaller
    {
        public static IWindsorContainer container { get; set; }

       

        
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

           // container.AddFacility<LoggingFacility>(x => x.UseNLog());

            container.Register(Classes.FromThisAssembly()
                             .BasedOn<IController>()
                           .LifestyleTransient());//临时的

           
        }
    }
}
