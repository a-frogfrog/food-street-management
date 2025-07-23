using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.Dto.Api.Request.Admin.User;
using FSM.Infrastructure.Dto.Api.Response.Admin.User;
using FSM.Infrastructure.Dto.Common;
using FSM.Infrastructure.Dto.Service.User;

namespace FSM.Service.Interface
{
    /// <summary>
    /// 用户服务接口
    /// </summary>
    [Provider]
    public interface IUserService
    {
        /// <summary>
        /// 通过sessionId获取用户信息
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        GetUserInfoDto GetUserBySessionId(string sessionId);

        /// <summary>
        /// 是否存在用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        bool IsExistUser(string userId);


        /// <summary>
        /// 创建商户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<ApiResponse> CreateMerchant(CreateMerchantRequestDto dto);

        /// <summary>
        /// 创建供应商
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<ApiResponse> CreateSupplier(CreateSupplierRequestDto dto);
    }
}
