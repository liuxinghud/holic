using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wu.Framework.Enums
{
    public class EnumManager
    {
        /// <summary>
        ///操作类型（记日志用）
        /// </summary>
        public enum OperationType
        {
            /// <summary>
            /// 保存或添加
            /// </summary>
            [System.ComponentModel.Description("添加")]
            Add,
            /// <summary>
            /// 更新
            /// </summary>
            [System.ComponentModel.Description("更新")]
            Update,
            /// <summary>
            /// 审核
            /// </summary>
            [Description("审核")]
            Audit,
            /// <summary>
            /// 删除
            /// </summary>
            [System.ComponentModel.Description("删除")]
            Deleted,
            /// <summary>
            /// 读取/查询
            /// </summary>
            [System.ComponentModel.Description("读取/查询")]
            retrieve,
            /// <summary>
            /// 登录
            /// </summary>
            [System.ComponentModel.Description("登录")]
            Login,
            /// <summary>
            /// 查看
            /// </summary>
            [System.ComponentModel.Description("查看")]
            Look,
            /// <summary>
            /// 初始化
            /// </summary>
            [System.ComponentModel.Description("初始化")]
            Init,
            /// <summary>
            /// 系统
            /// </summary>
            [System.ComponentModel.Description("系统")]
            System

        }


        public enum LogLevelEnum
        {
            Trace,
            Debug,
            Info,
            Warn,
            Error,
            Fatal,
            Off
        }

    }
}
