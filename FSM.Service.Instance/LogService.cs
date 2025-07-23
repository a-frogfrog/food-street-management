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

        public async Task<bool> WriteAdminLoginLog(CreateLoginLogDto dto)
        {
            var now = DateTime.Now;
            var ipAddress = _httpContextUtils.GetIpAddress();
            var location = await _httpContextUtils.GetLocation(ipAddress);

            var log = new LoginLog()
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

            _log.LoginLog.Add(log);
            int result = await _log.LoginLog.SaveChangesAsync();
            return result != 0;
        }

        public async Task WriteErrorLog(CreateErrorDto dto)
        {
            //TODO:add error log
            var log = new ErrorLog()
            {
                LogId = _guidGenerator.GenerateSequentialGuid(),
                ErrorCode = dto.ErrorCode,
                ErrorMessage = dto.ErrorMessage,
                ErrorType = dto.ErrorType,
                HttpStatusCode = dto.HttpStatusCode,
                StackTrace = dto.StackTrace,
                CreateTime = DateTime.Now
            };

            _log.ErrorLog.Add(log);
            await _log.ErrorLog.SaveChangesAsync();
        }

        public async Task<bool> WriteMerchantLoginLog(CreateLoginLogDto dto)
        {
            var now = DateTime.Now;
            var ipAddress = _httpContextUtils.GetIpAddress();
            var location = await _httpContextUtils.GetLocation(ipAddress);

            var log = new MerchantLoginLog()
            {
                LogId = _guidGenerator.GenerateSequentialGuid(),
                MerchId = dto.UserId,
                MerchName = dto.UserName,
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

            _log.MerchantLoginLog.Add(log);
            int result = await _log.MerchantLoginLog.SaveChangesAsync();
            return result != 0;
        }

        public async Task WriteOperationLog(CreateOperationDto dto)
        {
            //TODO:add operation log
            var log = new OperationLog()
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

            _log.OperationLog.Add(log);
            await _log.OperationLog.SaveChangesAsync();
        }

        
    }
}
