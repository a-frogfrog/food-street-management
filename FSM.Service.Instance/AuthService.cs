using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.Dto.Api.Request.Admin.Login;
using FSM.Infrastructure.Dto.Common;
using FSM.Infrastructure.Dto.Service.Log.Login;
using FSM.Infrastructure.Helpers;
using FSM.Service.Dependencies;
using FSM.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace FSM.Service.Instance
{
    [Inject]
    public class AuthService : ResponseHelper, IAuthService
    {
        private readonly AuthDependencies _auth;
        private readonly ILogService _logService;
        private readonly GlobalStatusHelper _globalStatusHelper;

        public AuthService(AuthDependencies auth,
            ILogService logService,
           GlobalStatusHelper globalStatusHelper
           )
        {
            _auth = auth;
            _logService = logService;
            _globalStatusHelper = globalStatusHelper;
        }

        public async Task<ApiResponse> AdminLogin(LoginRequestDto dto)
        {
            var query = await _auth.User.QueryAll(q => q.Account == dto.Account).ToListAsync();
            if (!query.Any()) return Failed("账号不存在");

            //TODO: 密码校验
            var user = query.FirstOrDefault()!;
            bool isVerified = _auth.IsAuthenticated(dto.Password, user.PasswordHash, user.PasswordSalt);
            if (!isVerified)
            {
                //TODO: 记入错误日志
                var message = "账号或密码错误";
                var errorLog = new CreateLoginLogDto()
                {
                    ErrorMessage = message,
                    Status = _globalStatusHelper.LOGIN.PasswordErrored,
                    LoginType = "",
                    UserId = user.UserId,
                    UserName = user.UserName,
                };

                await _logService.WriteAdminLoginLog(errorLog);
                return Failed(message);
            }

            var successLog = new CreateLoginLogDto()
            {
                Status = _globalStatusHelper.LOGIN.Success,
                LoginType = "",
                UserId = user.UserId,
                UserName = user.UserName,
                SessionId = dto.Payload
            };

            bool isSuccess = await _logService.WriteAdminLoginLog(successLog);

            return isSuccess ? Ok("登录成功") : Failed("登录失败");
        }


        public bool ValidateToken(string token)
        {
            var query = _auth.LoginLog.QueryAll(
                false, o => o.CreateTime,
                q => q.SessionId == token).ToList();

            if (!query.Any()) return false;
            var loginLog = query.SingleOrDefault();

            if (loginLog == null) return false;
            if (loginLog.Status != _globalStatusHelper.LOGIN.Success) return false;
            return true;


        }

        public Task<ApiResponse> SupplierLogin(LoginRequestDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse> MerchantLogin(LoginRequestDto dto)
        {
            var query = await _auth.Merchant.QueryAll(q => q.Account == dto.Account).ToListAsync();
            if (!query.Any()) return Failed("账号不存在");

            //TODO: 密码校验
            var user = query.FirstOrDefault()!;
            bool isVerified = _auth.IsAuthenticated(dto.Password, user.PasswordHash, user.PasswordSalt);

            if (!isVerified)
            {
                //TODO: 记入错误日志
                var message = "账号或密码错误";
                var errorLog = new CreateLoginLogDto()
                {
                    ErrorMessage = message,
                    Status = _globalStatusHelper.LOGIN.PasswordErrored,
                    LoginType = "",
                    UserId = user.MerchId,
                    UserName = user.MerchName,
                };

                await _logService.WriteMerchantLoginLog(errorLog);
                return Failed(message);
            }


            var successLog = new CreateLoginLogDto()
            {
                Status = _globalStatusHelper.LOGIN.Success,
                LoginType = "",
                UserId = user.MerchId,
                UserName = user.MerchName,
                SessionId = dto.Payload
            };

            bool isSuccess = await _logService.WriteMerchantLoginLog(successLog);

            return isSuccess ? Ok("登录成功") : Failed("登录失败");
        }
    }
}
