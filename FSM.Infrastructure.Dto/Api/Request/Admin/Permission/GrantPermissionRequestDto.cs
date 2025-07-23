using System.ComponentModel.DataAnnotations;

namespace FSM.Infrastructure.Dto.Api.Request.Admin.Permission
{
    /// <summary>
    /// Grant Permission Request Dto.
    /// 授权请求Dto.
    /// </summary>
    public class GrantPermissionRequestDto
    {
        /// <summary>
        /// 用户ID.
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// 权限集合.
        /// </summary>
        [Required]
        public List<string> Permissions { get; set; } = new();
    }
}
