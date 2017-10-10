using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Reflection;

namespace Wu.Framework.Data
{
    public class IocForData : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //container.Register(
            // // Classes.FromAssemblyInThisApplication().Where(Component.IsInSameNamespaceAs<IMemberShip>())
            // Classes.FromAssembly(Assembly.Load("Wu.Framework.Data"))
            //  .Where(Component.IsInNamespace(@"Wu.Framework.Data", true))
            //  .WithService.AllInterfaces()//.DefaultInterfaces()
            //  .LifestylePerWebRequest()
            //  .AllowMultipleMatches()
            //  );

            container.Register(Classes.FromThisAssembly().InSameNamespaceAs<IocForData>(true)
               .WithService.AllInterfaces()//.DefaultInterfaces()
               .LifestylePerWebRequest()
               .AllowMultipleMatches()
               );

        }
    }
}
