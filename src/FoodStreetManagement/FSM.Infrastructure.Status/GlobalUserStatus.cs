using FSM.Infrastructure.Attribute;

namespace FSM.Infrastructure.Status
{
    /// <summary>
    /// 用户状态.
    /// </summary>
    [Provider, Inject]
    public class GlobalUserStatus
    {
        public int Inactive = 0;
        public int Active = 1;
        public int Banned = 2;
        public int Deleted = 3;
    }
}
