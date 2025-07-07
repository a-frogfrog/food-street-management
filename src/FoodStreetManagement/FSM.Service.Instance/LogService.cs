using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.Dto.Service.Log.Error;
using FSM.Infrastructure.Dto.Service.Log.Login;
using FSM.Infrastructure.Dto.Service.Log.Operation;
using FSM.Infrastructure.EFCore.MySql.Models;
using FSM.Infrastructure.Tools;
using FSM.Service.Dependencies;
using FSM.Service.Interface;

namespace FSM.Service.Instance
{
    [Inject]
    public class LogService : ILogService
    {
        private readonly LogDependencies _log;
        private readonly GuidGenerator _guidGenerator;
        private readonly HttpContextUtils _httpContextUtils;

        public LogService(LogDependencies log, GuidGenerator guidGenerator, HttpContextUtils httpContextUtils)
        {
            _log = log;
            _guidGenerator = guidGenerator;
            _httpContextUtils = httpContextUtils;
        }

        public async Task<bool> WriteAdminLoginLog(CreateAdminLoginDto dto)
        {
            var now = DateTime.Now;
            var ipAddress = _httpContextUtils.GetIpAddress();
            var location = await _httpContextUtils.GetLocation(ipAddress);

            var log = new Loginlog()
            {
                LogId = _guidGenerator.GenerateSequentialGuid(),
                UserId = dto.UserId,
                UserName = dto.UserName,
                Status = dto.Status,
                ErrorMessage = dto.ErrorMessage,
                SessionId = dto.SessionId,
                LoginType = dto.LoginType,
                IpAddress = ipAddress,
                Source = _httpContextUtils.DetectSource(),
                UserAgent = _httpContextUtils.GetUserAgent(),
                CreateTime = now,
                LoginTime = now,
                Location = location
            };

            _log._loginLog.Add(log);
            int result = await _log._loginLog.SaveChangesAsync();
            return result != 0;
        }

        public async Task WriteErrorLog(CreateErrorDto dto)
        {
            //TODO:add error log
            var log = new Errorlog()
            {
                LogId = _guidGenerator.GenerateSequentialGuid(),
                ErrorCode = dto.ErrorCode,
                ErrorMessage = dto.ErrorMessage,
                ErrorType = dto.ErrorType,
                HttpStatusCode = dto.HttpStatusCode,
                StackTrace = dto.StackTrace,
                CreateTime = DateTime.Now
            };

            _log._errorLog.Add(log);
            await _log._errorLog.SaveChangesAsync();
        }

        public async Task WriteOperationLog(CreateOperationDto dto)
        {
            //TODO:add operation log
            var log = new Operationlog()
            {
                LogId = _guidGenerator.GenerateSequentialGuid(),
                UserId = dto.UserId,
                UserName = dto.UserName,
                Module = dto.Module,
                OperationType = dto.OperationType,
                Parameters = dto.Parameters,
                Status = dto.Status,
                Action = dto.Action,
                Method = dto.Method,
                OperationTime = DateTime.Now,
                ModuleUrl = _httpContextUtils.GetRquestUrl(),
                UserAgent = _httpContextUtils.GetUserAgent(),
                IpAddress = _httpContextUtils.GetIpAddress(),
            };
            log.Location = await _httpContextUtils.GetLocation(log.IpAddress);

            _log._operationLog.Add(log);
            await _log._operationLog.SaveChangesAsync();
        }
    }
}
