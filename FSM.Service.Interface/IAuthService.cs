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
        /// Admin 登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<ApiResponse> AdminLogin(LoginRequestDto dto);

        /// <summary>
        /// Supplier 登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<ApiResponse> SupplierLogin(LoginRequestDto dto);

        /// <summary>
        /// Merchant 登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<ApiResponse> MerchantLogin(LoginRequestDto dto);

        /// <summary>
        /// 验证token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        bool ValidateToken(string token);
    }
}
