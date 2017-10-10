using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wu.Framework.Enums;

namespace Wu.Framework.Entity.Mapping
{
   public class OperationLogMap:ClassMap<OperationLog>
    {
        public OperationLogMap()
        {
            Table("wu_base_log");
            Id(M => M.Id);
            Map(m => m.Date);
            Map(m => m.Level);
            References(m => m.Operater).Column("Operater");
            Map(m => m.OperationType);
            Map(m => m.IP);
            Map(m => m.Message);
            Map(m => m.StackTrace);
            Map(m => m.Exception).CustomType<CustomJsonType<Exception>>();
            Map(m => m.IsDeleted);
            Map(m => m.CreatedAt);
        }
    }
}
