using System;
using System.Collections.Generic;

namespace FSM.Infrastructure.EFCore.MySql.Models
{
    /// <summary>
    /// 操作日志表
    /// </summary>
    public partial class OperationLog
    {
        /// <summary>
        /// 日志ID
        /// </summary>
        public string LogId { get; set; } = null!;
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserId { get; set; } = null!;
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; } = null!;
        /// <summary>
        /// 操作模块
        /// </summary>
        public string Module { get; set; } = null!;
        /// <summary>
        /// 行为
        /// </summary>
        public string Action { get; set; } = null!;
        /// <summary>
        /// 操作类型
        /// </summary>
        public string OperationType { get; set; } = null!;
        /// <summary>
        /// 模块地址
        /// </summary>
        public string ModuleUrl { get; set; } = null!;
        /// <summary>
        /// 参数
        /// </summary>
        public string Parameters { get; set; } = null!;
        /// <summary>
        /// HTTP请求方法
        /// </summary>
        public string Method { get; set; } = null!;
        /// <summary>
        /// 状态，是否成功
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// IP地址
        /// </summary>
        public string IpAddress { get; set; } = null!;
        /// <summary>
        /// IP地址转换为实际地址
        /// </summary>
        public string Location { get; set; } = null!;
        /// <summary>
        /// 用户设备信息
        /// </summary>
        public string? UserAgent { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperationTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; }
    }
}
