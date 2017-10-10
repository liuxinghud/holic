using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wu.Framework.Entity.Mapping
{
   public class UserMap:ClassMap<User>
    {

        public UserMap()
        {
            Table("wu_base_user");
            Id(M => M.Id);
            Map(m => m.UserName);
            Map(m => m.Password);
            Map(m => m.Name);
            Map(m => m.CreatedAt);
            Map(m => m.IsDeleted);
            Map(m => m.Gender).Default("0");
            References(m => m.CreatedBy).Column("CreatedBy");

        }

    }
}
