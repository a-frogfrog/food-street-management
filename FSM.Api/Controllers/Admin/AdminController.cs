using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.Dto.Service.User;
using FSM.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FSM.Api.Controllers.Admin
{
    /// <summary>
    /// Admin 模块
    /// </summary>
    [Route("api/admin/[controller]/[action]")]
    [Permission]
    public class AdminController : ControllerBase
    {

        private readonly IBaseService _baseService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="baseService"></param>
        public AdminController(IBaseService baseService)
        {
            _baseService = baseService;
        }


        /// <summary>
        /// Get User Info
        /// </summary>
        /// <returns></returns>
        protected GetUserInfoDto GetCurrentUser()
        {
            var sessionId = HttpContext.User.Identity?.Name ?? "";
            return _baseService.GetUserInfo(sessionId);
        }
    }
}
