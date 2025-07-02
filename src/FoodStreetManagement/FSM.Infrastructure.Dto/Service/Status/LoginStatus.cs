using FSM.Infrastructure.Attribute;

namespace FSM.Infrastructure.Dto.Service.Status
{
    /// <summary>
    /// 登录状态
    /// </summary>
    public enum LoginStatus
    {
        /// <summary>
        /// 成功
        /// </summary>
        Success = 1,
       /// <summary>
       /// 密码错误
       /// </summary>
        PasswordError = 2,
        /// <summary>
        /// 注销
        /// </summary>
        Logout = 3,
    }
}
