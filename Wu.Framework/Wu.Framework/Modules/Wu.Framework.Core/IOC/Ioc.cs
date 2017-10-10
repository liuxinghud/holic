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
    public class Ioc : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility(new PersistenceFacility());
            //Classes.FromAssemblyInThisApplication()
            container.Register(Classes.FromThisAssembly()
                             .BasedOn<IController>()
                           .LifestyleTransient());//临时的

            //container.Register(Classes.FromAssemblyNamed(@"Wu.Framework.Web")
            //                    .BasedOn<IController>()
            //                  .LifestyleTransient());//临时的


            //container.Register(Classes.FromAssemblyNamed(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace).BasedOn<IController>().LifestyleTransient());

            //container.Register(
            //   // Classes.FromAssemblyInThisApplication().Where(Component.IsInSameNamespaceAs<IMemberShip>())
            //   Classes.FromAssembly(Assembly.Load("Wu.Framework.Data"))
            //    .Where(Component.IsInNamespace(@"Wu.Framework.Data",true))
            //    .WithService.AllInterfaces()//.DefaultInterfaces()
            //    .LifestylePerWebRequest()
            //    .AllowMultipleMatches()
            //    );
        }
    }
}
