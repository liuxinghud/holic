using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wu.Framework.Entity.Base;
using static Wu.Framework.Enums.EnumManager;

namespace Wu.Framework.Entity
{
   public class OperationLog:BaseEntity<long>
    {
        /// <summary>
        /// 操作者
        /// </summary>
        public virtual User Operater { get; set; }
        /// <summary>
        /// 操作类型
        /// </summary>
        public virtual OperationType OperationType { get; set; }

        public virtual LogLevelEnum Level { get; set; }


        public virtual string IP { get; set; }


        public virtual string Message { get; set; }

        public virtual string StackTrace { get; set; }

        public virtual string Exception { get; set; }
    }
}
