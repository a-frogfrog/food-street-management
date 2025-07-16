using FSM.Api.Options;
using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.Dto.Api.Request.Admin.Login;
using FSM.Infrastructure.Dto.Common;
using FSM.Infrastructure.Helpers;
using FSM.Infrastructure.Tools;
using FSM.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FSM.Api.Controllers.Admin
{
    /// <summary>
    /// Auth 模块
    /// </summary>
    public class AuthController : AdminController
    {
        private readonly IAuthService _authService;
        private readonly JwtTokenGenerator _jwtTokenGenerator;
        private readonly GuidGenerator _guidGenerator;
        private readonly AuthOptions _authOptions;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="authService"></param>
        /// <param name="jwtTokenGenerator"></param>
        /// <param name="guidGenerator"></param>
        /// <param name="baseService"></param>
        /// <param name="authOptions"></param>
        public AuthController(IAuthService authService,
            JwtTokenGenerator jwtTokenGenerator,
            GuidGenerator guidGenerator,
            IBaseService baseService,
            IOptions<AuthOptions> authOptions
            ) : base(baseService)
        {
            _authService = authService;
            _jwtTokenGenerator = jwtTokenGenerator;
            _guidGenerator = guidGenerator;
            _authOptions = authOptions.Value;
        }


        /// <summary>
        /// Admin 登录 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Permission(Urls = new[] {"/log"})]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return Ok(ResponseHelper.BadRequest("Invalid request"));
            }

            dto.Account = dto.Account.Trim();
            dto.Password = dto.Password.Trim();
            dto.Payload = _guidGenerator.GenerateRandomGuid();

            var result = await _authService.AdminLogin(dto);

            if (result.Code != ApiResponseCode.Ok) return Unauthorized(result);

            var token = _jwtTokenGenerator.GenerateToken(
                code: dto.Payload,
                securityKey: _authOptions.SecretKey,
                issuer: _authOptions.Issuer,
                audience: _authOptions.Audience,
                role: ApiRoles.Admin);

            result.Data = new { token };

            return Ok(result);
        }

        /// <summary>
        /// Admin 检查登录状态
        /// </summary>
        /// <returns></returns>             
        [HttpGet]
        [Authorize(Roles = ApiRoles.Admin)]
        [Operation(Module = "Auth", Action = "检查登录状态", Type = "query")]
        public IActionResult CheckLogin()
        {
            var user = GetCurrentUser();
            if (user == null) return Ok(ResponseHelper.Unauthorized());
            var result = new ApiResponse() { Code = 0, Message = "success", Data = new { user.Account, user.UserName } };
            return Ok(result);
        }
    }
}
