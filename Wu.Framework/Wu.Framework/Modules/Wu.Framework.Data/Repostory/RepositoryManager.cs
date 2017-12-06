using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wu.Framework.Data
{
    public class RepositoryManager
    {
        public static RepositoryManager Default { get; set; }

         static RepositoryManager()
        {
            Default = new RepositoryManager(); //Core.Ioc.container.Kernel.Resolve<RepositoryManager>();

        }
        public IRepository<T> Of<T>() where T : class
        {
             return Core.Ioc.container.Kernel.Resolve<IRepository<T>>();
        }

    }
}
