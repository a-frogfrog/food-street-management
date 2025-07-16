using System;
using System.Collections.Generic;

namespace FSM.Infrastructure.EFCore.MySql.Models
{
    /// <summary>
    /// 供应商登录日志表
    /// </summary>
    public partial class SupplierLoginLog
    {
        /// <summary>
        /// 日志ID
        /// </summary>
        public string LogId { get; set; } = null!;
        /// <summary>
        /// 供应商ID
        /// </summary>
        public string SuppId { get; set; } = null!;
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string SuppName { get; set; } = null!;
        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginTime { get; set; }
        /// <summary>
        /// 登录类型
        /// </summary>
        public string LoginType { get; set; } = null!;
        /// <summary>
        /// 状态（是否成功）
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
        /// 错误信息
        /// </summary>
        public string? ErrorMessage { get; set; }
        /// <summary>
        /// 登录来源（PC端，移动端等）
        /// </summary>
        public string Source { get; set; } = null!;
        /// <summary>
        /// 会话ID
        /// </summary>
        public string SessionId { get; set; } = null!;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
