namespace FSM.Infrastructure.Dto.Service.Log.Login
{
 
    /// <summary>
    /// 创建登录日志DTO.
    /// </summary>
    public class CreateLoginLogDto
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
