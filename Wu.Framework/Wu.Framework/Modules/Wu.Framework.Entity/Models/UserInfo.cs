using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wu.Framework.Entity.Base;

namespace Wu.Framework.Entity
{
    public  class UserInfo:BaseEntity<int>
    {
        public virtual User User { get; set; }
        public virtual string Address { get; set; }

    }
}
