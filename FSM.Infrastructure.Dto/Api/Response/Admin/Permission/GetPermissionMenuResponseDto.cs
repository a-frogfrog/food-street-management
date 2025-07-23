namespace FSM.Infrastructure.Dto.Api.Response.Admin.Permission
{
    /// <summary>
    /// Get Permission Menu Response Dto.
    /// 获取权限菜单响应Dto.
    /// </summary>
    public class GetPermissionMenuResponseDto
    {
        /// <summary>
        /// 权限ID.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// 权限名称.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 权限
        /// </summary>
        public string Url { get; set; } = string.Empty;

        /// <summary>
        /// 权限图标
        /// </summary>
        public string Icon { get; set; } = string.Empty;

        /// <summary>
        ///  父级权限ID
        /// </summary>
        public string? ParentId { get; set; }

        /// <summary>
        /// 子级权限
        /// </summary>
        public List<GetPermissionMenuResponseDto> Children { get; set; } = new List<GetPermissionMenuResponseDto>();
    }
}
