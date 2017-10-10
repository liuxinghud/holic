using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wu.Framework.Entity.Base;

namespace Wu.Framework.Entity
{
    public class User: BaseEntity<int>
    {
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }

        public virtual string Name { get; set; }
        public virtual bool Gender { get; set; }
        public virtual User CreatedBy { get; set; }
    }
}
