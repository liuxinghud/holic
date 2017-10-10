using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wu.Framework.Entity.Base
{
    public class BaseEntity<Type>
    {
        public virtual Type Id { get; set; }

        public virtual DateTime CreatedAt  { get; set; }

        public virtual bool IsDeleted { get; set; }

    }
}
