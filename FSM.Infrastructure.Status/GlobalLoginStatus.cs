using FSM.Infrastructure.Attribute;

namespace FSM.Infrastructure.Status
{
    /// <summary>
    /// 登录状态.
    /// </summary>
    [Provider, Inject]
    public class GlobalLoginStatus
    {
        public int Success = 1;
        public int Failure = 2;
        public int PasswordErrored = 3;
    }
}
