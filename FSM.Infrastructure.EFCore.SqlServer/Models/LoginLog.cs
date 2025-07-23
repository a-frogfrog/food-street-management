using System;
using System.Collections.Generic;

namespace FSM.Infrastructure.EFCore.SqlServer.Models
{
    public partial class LoginLog
    {
        /// <summary>
        /// 日志ID
        /// </summary>
        public string LogId { get; set; } = null!;
        /// <summary>
        /// 登录用户ID
        /// </summary>
        public string UserId { get; set; } = null!;
        /// <summary>
        /// 登录用户名称
        /// </summary>
        public string UserName { get; set; } = null!;
        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginTime { get; set; }
        /// <summary>
        /// 登录类型 （账号密码，扫码，验证码）
        /// </summary>
        public string LoginType { get; set; } = null!;
        /// <summary>
        /// 登录状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 登录 IP 地址
        /// </summary>
        public string IpAddress { get; set; } = null!;
        /// <summary>
        /// IP地址转换为实际地址
        /// </summary>
        public string Location { get; set; } = null!;
        /// <summary>
        /// 客户端信息（如浏览器类型、操作系统、设备型号等，用于分析登录设备分布）。
        /// </summary>
        public string? UserAgent { get; set; }
        /// <summary>
        /// 失败原因（如 “密码错误”“账户锁定” 等)
        /// </summary>
        public string? ErrorMessage { get; set; }
        /// <summary>
        /// 登录来源（如 “PC 端”“移动端”“API 接口” 等）
        /// </summary>
        public string? Source { get; set; }
        /// <summary>
        /// 会话 ID
        /// </summary>
        public string SessionId { get; set; } = null!;
        /// <summary>
        /// 日志创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
