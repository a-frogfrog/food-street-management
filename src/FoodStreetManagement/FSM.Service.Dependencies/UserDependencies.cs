using FSM.Infrastructure.Attribute;
using FSM.Repository.EntityRepositories;

namespace FSM.Service.Dependencies
{

    /// <summary>
    /// User Service Dependencies   
    /// 用户服务依赖
    /// </summary>
    [Provider, Inject]
    public class UserDependencies
    {
        public readonly UserRepository _user;

        public UserDependencies(UserRepository user)
        {
            _user = user;
        }
    }
}
