using FSM.Infrastructure.Attribute;
using FSM.Repository.EntityRepositories.Repositorys;

namespace FSM.Service.Dependencies
{

    /// <summary>
    /// Log Service Dependencies
    /// 日志服务依赖
    /// </summary>
    [Provider, Inject]
    public class LogDependencies
    {
        public readonly LoginLogRepository LoginLog;
        public readonly OperationLogRepository OperationLog;
        public readonly ErrorLogRepository ErrorLog;
        public readonly SupplierLoginLogRepository SupplierLoginLog;
        public readonly MerchantLoginLogRepository MerchantLoginLog;

        public LogDependencies(
            LoginLogRepository loginLog,
            OperationLogRepository operationLog,
            ErrorLogRepository errorLog,
            SupplierLoginLogRepository supplierLoginLog,
            MerchantLoginLogRepository merchantLoginLog
            ) 
        {
            // TODO: 完成成员初始化
            // TODO: Complete member initialization
            LoginLog = loginLog;
            OperationLog = operationLog;
            ErrorLog = errorLog;
            SupplierLoginLog = supplierLoginLog;
            MerchantLoginLog = merchantLoginLog;

        }
    }
}
