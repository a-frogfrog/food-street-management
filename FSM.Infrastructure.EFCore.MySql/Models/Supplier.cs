using System;
using System.Collections.Generic;

namespace FSM.Infrastructure.EFCore.MySql.Models
{
    /// <summary>
    /// 供应商表
    /// </summary>
    public partial class Supplier
    {
        /// <summary>
        /// 供应商ID
        /// </summary>
        public string SuppId { get; set; } = null!;
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string SuppName { get; set; } = null!;
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; } = null!;
        /// <summary>
        /// 联系人
        /// </summary>
        public string Contacts { get; set; } = null!;
        /// <summary>
        /// 密码
        /// </summary>
        public string PasswordHash { get; set; } = null!;
        /// <summary>
        /// 密码盐值
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
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        public string? Description { get; set; }
    }
}
