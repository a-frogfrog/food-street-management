namespace FSM.Infrastructure.Dto.Service.Permission
{
    /// <summary>
    /// Check User Permission Dto.
    /// 检查用户权限Dto.
    /// </summary>
    public class CheckUserPermissionDto
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserId { get; set; } = null!;

        /// <summary>
        /// 权限
        /// </summary>
        public List<string> Permissions { get; set; } = null!;
    }
}
