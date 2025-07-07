using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.Dto.Service.Log.Error;
using FSM.Infrastructure.Dto.Service.Log.Login;
using FSM.Infrastructure.Dto.Service.Log.Operation;

namespace FSM.Service.Interface
{
    /// <summary>
    /// 日志服务接口
    /// </summary>
    [Provider]
    public interface ILogService
    {
        /// <summary>
        /// 写入操作日志
        /// </summary>
        /// <param name="dto"></param>
        Task WriteOperationLog(CreateOperationDto dto);

        /// <summary>
        /// 写入错误日志
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task WriteErrorLog(CreateErrorDto dto);


        Task<bool> WriteAdminLoginLog(CreateAdminLoginDto dto);
    }
}
