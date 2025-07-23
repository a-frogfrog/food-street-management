namespace FSM.Infrastructure.Dto.Api.Response.Admin.Permission
{
    /// <summary>
    /// Get Permission Response Dto.
    /// 获取权限响应数据传输对象
    /// </summary>
    public class GetPermissionResponseDto
    {
        /// <summary>
        /// ID.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// 权限名称
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 权限URL
        /// </summary>
        public string Url { get; set; } = string.Empty;

        /// <summary>
        /// 权限排序
        /// </summary>
        public int SerialNumber { get; set; }

        /// <summary>
        /// 权限类型
        /// </summary>
        public int  Type { get; set; } 

        /// <summary>
        /// 权限状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; } = string.Empty;

        /// <summary>
        /// 父级ID
        /// </summary>
        public string ParentId { get; set; } = string.Empty;

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string? Description { get; set; } = string.Empty;

        /// <summary>
        /// 子级权限
        /// </summary>
        public List<GetPermissionResponseDto>? Children { get; set; }

    }
}
