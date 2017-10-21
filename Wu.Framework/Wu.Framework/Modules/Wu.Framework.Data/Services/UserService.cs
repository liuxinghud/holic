using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wu.Framework.Core;
using Wu.Framework.Entity;

namespace Wu.Framework.Data
{
   public class UserService
    {
        public IRepository<User> Repository { get; set; }
 
        public IList<User> UserList(System.Linq.Expressions.Expression<Func<User, bool>> func,int page,int pagesize)
        {
            return Repository.List(func, page, pagesize);
        }
    



    }
}
