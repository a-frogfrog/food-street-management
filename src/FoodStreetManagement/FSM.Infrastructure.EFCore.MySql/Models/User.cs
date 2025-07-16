using System;
using System.Collections.Generic;

namespace FSM.Infrastructure.EFCore.MySql.Models
{
    /// <summary>
    /// 管理员表
    /// </summary>
    public partial class User
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserId { get; set; } = null!;
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; } = null!;
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; } = null!;
        /// <summary>
        /// 哈希后的密码（加盐）
        /// </summary>
        public string PasswordHash { get; set; } = null!;
        /// <summary>
        /// 盐值（用于加密）
        /// </summary>
        public string PasswordSalt { get; set; } = null!;
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
    }
}
