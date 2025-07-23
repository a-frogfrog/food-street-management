using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.Status;

namespace FSM.Infrastructure.Helpers
{
    /// <summary>
    /// Class for Global Status Helper.
    /// 全局状态帮助类.
    /// </summary>

    [Provider, Inject]
    public class GlobalStatusHelper
    {
        /// <summary>
        /// Login Status.
        /// 登录状态.
        /// </summary>
        public  GlobalLoginStatus LOGIN { get; private set; }

        /// <summary>
        /// User Status.
        /// 用户状态.
        /// </summary>
        public  GlobalUserStatus USER { get; private set; }

        /// <summary>
        /// Permission Status.
        /// 权限状态
        /// </summary>
        public  GlobalPermissionStatus PERMIDENT { get; private set; }
        public GlobalStatusHelper(
            GlobalLoginStatus login,
            GlobalUserStatus user, 
            GlobalPermissionStatus permission)
        {
            LOGIN = login;
            USER = user;
            PERMIDENT = permission;
        }
    }
}
