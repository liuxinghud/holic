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


        private ISession session;
        public UserService(ISession session)
        {
            this.session = session;
        }

        public User GetUser(int Id)
        {
          
          return session.Get<User>(Id);
        }

    }
}
