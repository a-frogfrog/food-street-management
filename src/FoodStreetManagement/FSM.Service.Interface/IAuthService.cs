using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.Dto.Api.Request.Admin.Login;
using FSM.Infrastructure.Dto.Common;

namespace FSM.Service.Interface
{
    /// <summary>
    /// 认证服务接口
    /// </summary>
    [Provider]
   public interface IAuthService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<ApiResponse> Login(LoginRequestDto dto);

        /// <summary>
        /// 验证token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        bool ValidateToken(string token);
    }
}
