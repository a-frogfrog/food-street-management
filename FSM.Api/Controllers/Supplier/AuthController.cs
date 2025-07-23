using FSM.Infrastructure.Dto.Api.Request.Admin.Login;
using FSM.Infrastructure.Helpers;
using FSM.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FSM.Api.Controllers.Supplier
{
    /// <summary>
    /// Auth 模块
    /// </summary>
    public class AuthController : SupplierController
    {
        private readonly IAuthService _authService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="authService"></param>
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Supplier 登录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login([FromBody] LoginRequestDto dto) 
        {
            if (!ModelState.IsValid)
            {
                return Ok(ResponseHelper.BadRequest());
            }

            var result = _authService.SupplierLogin(dto);
            return Ok(result);    
        }

        /// <summary>
        /// Supplier 检查登录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult CheckLogin()
        {
            return Ok();
        }
    }
}
