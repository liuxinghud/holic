using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wu.Framework.Entity;

namespace Wu.Framework.Data
{
   public class UserService
    {

 public ISession Session { get; set; }

        public User GetUser(int Id)
        {
          
          return Session.Get<User>(Id);
        }


        public IEnumerable<T> UserList<T>(System.Linq.Expressions.Expression<Func<T,bool>> func) where T:class
        {
          return  Session.QueryOver<T>().Where(func).List();
        }
    }
}
