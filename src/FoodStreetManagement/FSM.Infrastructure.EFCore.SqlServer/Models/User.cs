using System;
using System.Collections.Generic;

namespace FSM.Infrastructure.EFCore.SqlServer.Models
{
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
        /// 用户账号
        /// </summary>
        public string Account { get; set; } = null!;
        /// <summary>
        /// 哈希后的密码
        /// </summary>
        public string PasswordHash { get; set; } = null!;
        /// <summary>
        /// 密码盐值，用户密码哈希
        /// </summary>
        public string PasswordSalt { get; set; } = null!;
        /// <summary>
        /// 用户状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 用户创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 修改用户信息时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
    }
}
