using System;
using System.Collections.Generic;

namespace FSM.Infrastructure.EFCore.MySql.Models
{
    /// <summary>
    /// 权限表
    /// </summary>
    public partial class Permission
    {
        /// <summary>
        /// 权限ID
        /// </summary>
        public string PermId { get; set; } = null!;
        /// <summary>
        /// 权限名称
        /// </summary>
        public string PermName { get; set; } = null!;
        /// <summary>
        /// 权限地址
        /// </summary>
        public string Url { get; set; } = null!;
        /// <summary>
        /// 权限状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 父级权限
        /// </summary>
        public string? ParentId { get; set; }
        /// <summary>
        /// 权限类型
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 权限图标
        /// </summary>
        public string Icon { get; set; } = null!;
        /// <summary>
        /// 序号
        /// </summary>
        public int SerialNumber { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CrateTime { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string? Description { get; set; }
    }
}
