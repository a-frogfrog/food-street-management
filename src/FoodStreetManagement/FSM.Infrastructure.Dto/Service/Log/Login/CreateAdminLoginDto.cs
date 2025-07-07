namespace FSM.Infrastructure.Dto.Service.Log.Login
{
    /// <summary>
    /// Represents the data transfer object used to create an administrator login.
    /// 创建管理员登录日志DTO.
    /// </summary>
    /// <remarks>This class is typically used to encapsulate the necessary information for creating an
    /// administrator login in a system. It serves as a container for the required data during the login creation
    /// process.</remarks>
    public class CreateAdminLoginDto
    {
        /// <summary>
        /// 用户 ID
        /// </summary>
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// 登录状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 登录类型
        /// </summary>
        public string LoginType { get; set; } = string.Empty;

        /// <summary>
        /// 错误消息
        /// </summary>
        public string ErrorMessage { get; set; } = string.Empty;

        /// <summary>
        /// 登录信息
        /// </summary>
        public string SessionId { get; set; } = string.Empty;
    }
}
