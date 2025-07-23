using FSM.Infrastructure.Dto.Service.User;
using FSM.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FSM.Api.Controllers.Merchant
{
    /// <summary>
    /// Merchant 模块
    /// </summary>
    [Route("api/merchant/[controller]/[action]")]
    [ApiController]
    public class MerchantController : ControllerBase
    {
        private readonly IBaseService _baseService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="baseService"></param>
        public MerchantController(IBaseService baseService)
        {
            _baseService = baseService;
        }

        /// <summary>
        /// 获取当前用户信息
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        protected GetUserInfoDto GetCurrentUser(string sessionId)
        {
            return _baseService.GetUserInfo(sessionId);
        }
    }
}
