using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.Dto.Api.Request.Admin.Login;
using FSM.Infrastructure.Dto.Common;
using FSM.Infrastructure.Dto.Service.Status;
using FSM.Infrastructure.EFCore.MySql.Models;
using FSM.Infrastructure.Helpers;
using FSM.Infrastructure.Tools;
using FSM.Service.Dependencies;
using FSM.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace FSM.Service.Instance
{
    [Inject]
    public class AuthService : ResponseHelper,  IAuthService
    {
        private readonly AuthDependencies _auth;
        private readonly GuidGenerator _guidGenerator;
        private readonly HttpContextUtils _httpContextUtils;

        public AuthService(AuthDependencies auth,
            GuidGenerator guidGenerator,
            HttpContextUtils httpContextUtils
           )
        {
            _auth = auth;
            _guidGenerator = guidGenerator;
            _httpContextUtils = httpContextUtils;
        }

        public async Task<ApiResponse> Login(LoginRequestDto dto)
        {
            var query = await _auth._user.QueryAll(q => q.Account == dto.Account).ToListAsync();
            if (!query.Any()) return Ok("账号不存在");

            //TODO: 密码校验
            var user = query.SingleOrDefault()!;
            bool isVerified = _auth.IsAuthenticated(dto.Password, user.PasswordHash, user.PasswordSalt);
            if (!isVerified)
            {
                var message = "账号或密码错误";
                await AddLoginLog(dto.Payload, LoginStatus.PasswordError, user.UserId, user.UserName, message);
                return Ok(message);
            }
            int isSuccess = await AddLoginLog(dto.Payload, LoginStatus.Success, user.UserId, user.UserName);

            return isSuccess >= 1 ? Ok( "登录成功")
                : Failed( "登录失败");
        }


        /// <summary>
        /// 记录登录日志
        /// </summary>
        /// <param name="session"></param>
        /// <param name="status"></param>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<int> AddLoginLog(string session, LoginStatus status, string userId, string userName, string? message = null)
        {
            var now = DateTime.Now;
            var loginLog = new Loginlog()
            {
                LogId = _guidGenerator.GenerateSequentialGuid(),
                UserId = userId,
                UserName = userName,
                LoginType = "",
                Status = (int)status,
                ErrorMessage = message,
                SessionId = session,
                CreateTime = now,
                LoginTime = now,
                IpAddress = _httpContextUtils.GetIpAddress(),
                UserAgent = _httpContextUtils.GetUserAgent(),
                Source = _httpContextUtils.DetectSource()
            };
                loginLog.Location = await _httpContextUtils.GetLocation(loginLog.IpAddress);
            _auth._loginLog.Add(loginLog);
            return await _auth._loginLog.SaveChangesAsync();

        }

        public bool ValidateToken(string token)
        {
            var query = _auth._loginLog.QueryAll(
                false, o => o.CreateTime,
                q => q.SessionId == token).ToList();

            if (!query.Any()) return false;
            var loginLog = query.SingleOrDefault();

            if (loginLog == null) return false;
            if (loginLog.Status != (int)LoginStatus.Success) return false;
            return true;


        }
    }
}
