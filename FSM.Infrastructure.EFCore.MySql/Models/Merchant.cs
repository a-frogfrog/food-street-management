using System;
using System.Collections.Generic;

namespace FSM.Infrastructure.EFCore.MySql.Models
{
    /// <summary>
    /// 商户表
    /// </summary>
    public partial class Merchant
    {
        /// <summary>
        /// 商户ID
        /// </summary>
        public string MerchId { get; set; } = null!;
        /// <summary>
        /// 商户名称
        /// </summary>
        public string MerchName { get; set; } = null!;
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; } = null!;
        /// <summary>
        /// 联系人
        /// </summary>
        public string Contacts { get; set; } = null!;
        /// <summary>
        /// 密码哈希值
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
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 商户类型
        /// </summary>
        public string? MerchType { get; set; }
        /// <summary>
        /// 营业执照编号
        /// </summary>
        public string? BusinessLicense { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string? Description { get; set; }
    }
}
