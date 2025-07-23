using System;
using System.Collections.Generic;

namespace FSM.Infrastructure.EFCore.MySql.Models
{
    /// <summary>
    /// 错误日志表
    /// </summary>
    public partial class ErrorLog
    {
        /// <summary>
        /// 日志ID
        /// </summary>
        public string LogId { get; set; } = null!;
        /// <summary>
        /// 错误Code
        /// </summary>
        public string ErrorCode { get; set; } = null!;
        /// <summary>
        /// 错误消息
        /// </summary>
        public string ErrorMessage { get; set; } = null!;
        /// <summary>
        /// 错误类型
        /// </summary>
        public string ErrorType { get; set; } = null!;
        /// <summary>
        /// 堆栈信息
        /// </summary>
        public string? StackTrace { get; set; }
        /// <summary>
        /// HTTP请求状态码
        /// </summary>
        public int? HttpStatusCode { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
