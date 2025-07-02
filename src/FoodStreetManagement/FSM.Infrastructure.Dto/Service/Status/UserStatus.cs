using FSM.Infrastructure.Attribute;

namespace FSM.Infrastructure.Dto.Service.Status
{
    /// <summary>
    /// 用户状态
    /// </summary>
    public enum UserStatus
    {
        /// <summary>
        /// 未激活
        /// </summary>
        Inactive = 0,
        /// <summary>
        /// 激活
        /// </summary>
        Active = 1,
        /// <summary>
        /// 封禁
        /// </summary>
        Banned = 2,
        /// <summary>
        /// 已删除
        /// </summary>
        Deleted = 3,
    }
}
