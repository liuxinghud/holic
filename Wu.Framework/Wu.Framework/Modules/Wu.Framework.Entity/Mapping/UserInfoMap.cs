using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wu.Framework.Core;

namespace Wu.Framework.Entity.Mapping
{
   public class UserInfoMap:ClassMap<UserInfo>
    {

        public UserInfoMap()
        {
            Table("wu_base_userinfo");
            Id(M => M.Id);
            Map(m => m.CreatedAt);
            Map(m => m.IsDeleted);
            Map(m => m.User).CustomType<CustomJsonType<User>>();
        }

    }
}
