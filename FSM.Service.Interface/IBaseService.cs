using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.Dto.Service.User;

namespace FSM.Service.Interface
{
    [Provider]
    public interface IBaseService
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        GetUserInfoDto GetUserInfo(string sessionId);
    }
}
