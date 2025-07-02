using FSM.Infrastructure.Attribute;
using FSM.Repository.EntityRepositories;

namespace FSM.Service.Dependencies
{

    /// <summary>
    /// Log Service Dependencies
    /// 日志服务依赖
    /// </summary>
    [Provider, Inject]
    public class LogDependencies
    {
        public readonly LoginLogRepository _loginLog;
        public readonly OperationLogRepository _operationLog;
        public readonly ErrorLogRepository _errorLog;

        public LogDependencies(
            LoginLogRepository loginLog,
            OperationLogRepository operationLog,
            ErrorLogRepository errorLog
            ) 
        {
            // TODO: 完成成员初始化
            // TODO: Complete member initialization
            _loginLog = loginLog;
            _operationLog = operationLog;
            _errorLog = errorLog;
        }
    }
}
