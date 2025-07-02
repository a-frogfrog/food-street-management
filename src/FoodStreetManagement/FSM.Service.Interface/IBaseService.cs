using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.Dto.Service.User;

namespace FSM.Service.Interface
{
    [Provider]
    public interface IBaseService
    {
        GetUserInfoDto GetUserInfo(string sessionId);
    }
}
