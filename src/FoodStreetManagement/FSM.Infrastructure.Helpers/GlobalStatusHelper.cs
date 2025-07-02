using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.Dto.Service.Status;

namespace FSM.Infrastructure.Helpers
{
    /// <summary>
    /// Class for Global Status Helper
    /// 全局状态帮助类
    /// </summary>

    [Provider, Inject]
    public class GlobalStatusHelper
    {
        /// <summary>
        /// 权限激活状态
        /// </summary>
        public readonly int PermissionActive = (int)PermissionStatus.Active;

        /// <summary>
        /// 权限禁用状态
        /// </summary>
        public readonly int PermissionBanned = (int)PermissionStatus.Banned;
    }
}
