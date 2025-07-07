using FSM.Infrastructure.Attribute;

namespace FSM.Infrastructure.Status
{
    /// <summary>
    /// 权限状态.
    /// </summary>
    [Provider, Inject]
    public class GlobalPermissionStatus
    {
        public int Active = 1;
        public int Banned = 0;
    }
}
