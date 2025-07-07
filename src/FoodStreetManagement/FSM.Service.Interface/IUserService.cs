using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.Dto.Service.User;

namespace FSM.Service.Interface
{
    /// <summary>
    /// 用户服务接口
    /// </summary>
    [Provider]
    public interface IUserService
    {
        /// <summary>
        /// 通过sessionId获取用户信息
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        GetUserInfoDto GetUserBySessionId(string sessionId);

        /// <summary>
        /// 是否存在用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        bool IsExistUser(string userId);
    }
}
