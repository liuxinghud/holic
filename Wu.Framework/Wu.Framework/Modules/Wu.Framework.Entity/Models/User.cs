using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wu.Framework.Entity.Base;

namespace Wu.Framework.Entity
{
    [DisplayName("用户")]
    public class User: BaseEntity<int>
    {
        [DisplayName("账号")]
        public virtual string UserName { get; set; }
       [Newtonsoft.Json.JsonIgnore]
        public virtual string Password { get; set; }
        [DisplayName("昵称")]
        public virtual string Name { get; set; }
        public virtual bool Gender { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public virtual User CreatedBy { get; set; }
    }
}
