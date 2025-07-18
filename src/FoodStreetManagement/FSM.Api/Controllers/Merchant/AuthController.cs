using FSM.Infrastructure.Dto.Api.Request.Admin.Login;
using FSM.Infrastructure.Helpers;
using FSM.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FSM.Api.Controllers.Merchant
{
    /// <summary>
    /// Provides authentication-related operations for merchants.
    /// </summary>
    /// <remarks>This controller is responsible for handling authentication workflows, such as login, logout, 
    /// and token management, for merchant users. It extends the <see cref="MerchantController"/>  to include
    /// authentication-specific functionality.</remarks>
    public class AuthController : MerchantController
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="baseService"></param>
        public AuthController(IBaseService baseService) : base(baseService)
        {
        }

        /// <summary>
        /// Merchant 登录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login([FromBody] LoginRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return Ok(ResponseHelper.BadRequest("Invalid request"));
            }
            return Ok();
        }


        /// <summary>
        ///  Merchant 检查登录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult CheckLogin()
        {
            return Ok();
        }
    }
}
