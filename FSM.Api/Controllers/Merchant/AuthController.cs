using FSM.Api.Options;
using FSM.Infrastructure.Dto.Api.Request.Admin.Login;
using FSM.Infrastructure.Dto.Common;
using FSM.Infrastructure.Helpers;
using FSM.Infrastructure.Tools;
using FSM.Service.Instance;
using FSM.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

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
        private readonly GuidGenerator _guidGenerator;
        private readonly JwtTokenGenerator _jwtTokenGenerator;
        private readonly IAuthService _authService;
        private readonly AuthOptions _authOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="baseService"></param>
        /// <param name="guidGenerator"></param>
        /// <param name="jwtTokenGenerator"></param>
        /// <param name="authService"></param>
        /// <param name="authOptions"></param>
        public AuthController(
            IBaseService baseService,
            GuidGenerator guidGenerator,
            JwtTokenGenerator jwtTokenGenerator,
            IAuthService authService,
               IOptions<AuthOptions> authOptions
            ) : base(baseService)
        {
            _guidGenerator = guidGenerator;
            _jwtTokenGenerator = jwtTokenGenerator;
            _authService = authService;
            _authOptions = authOptions.Value;
        }

        /// <summary>
        /// Merchant 登录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return Ok(ResponseHelper.BadRequest("Invalid request"));
            }

            dto.Account = dto.Account.Trim();
            dto.Password = dto.Password.Trim();
            dto.Payload = _guidGenerator.GenerateRandomGuid();

            var result = await _authService.MerchantLogin(dto);

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
        ///  Merchant 检查登录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = ApiRoles.Merchant)]
        public IActionResult CheckLogin()
        {
            return Ok();
        }
    }
}
