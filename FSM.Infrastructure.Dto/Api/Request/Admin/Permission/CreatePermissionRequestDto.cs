using System.ComponentModel.DataAnnotations;

namespace FSM.Infrastructure.Dto.Api.Request.Admin.Permission 
{
    /// <summary>
    /// Create Permission Request Dto.
    /// 创建权限请求Dto.
    /// </summary>
    public class CreatePermissionRequestDto 
    {
        /// <summary>
        /// 权限名称.
        /// </summary>
        [Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 权限标识.
        /// </summary>
        [Required]
        public string Url { get; set; } = string.Empty;

        /// <summary>
        /// 权限类型 /是否为菜单.
        /// </summary>
        [Required]
        public int Type { get; set; } = 0;

        /// <summary>
        /// 权限图标.
        /// </summary>
        public string Icon { get; set; } = string.Empty;

        /// <summary>
        /// 权限父级Id.
        /// </summary>
        public string? ParentId { get; set; }

        /// <summary>
        /// 权限描述.
        /// </summary>
        public string? Description { get; set; }
    }
}


