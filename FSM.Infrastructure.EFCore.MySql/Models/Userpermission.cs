using System;
using System.Collections.Generic;

namespace FSM.Infrastructure.EFCore.MySql.Models
{
    /// <summary>
    /// 用户权限表
    /// </summary>
    public partial class UserPermission
    {
        /// <summary>
        /// 用户权限ID
        /// </summary>
        public string UserPermId { get; set; } = null!;
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserId { get; set; } = null!;
        /// <summary>
        /// 权限ID
        /// </summary>
        public string PermId { get; set; } = null!;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 权限生效时间/长时间权限为 null
        /// </summary>
        public DateTime? EffectiveTime { get; set; }
        /// <summary>
        /// 权限失效时间/长时间权限为 null
        /// </summary>
        public DateTime? ExpirationTime { get; set; }
    }
}
