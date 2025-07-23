using FSM.Infrastructure.Dto.Api.Request.Admin.User;
using FSM.Infrastructure.Dto.Api.Response.Admin.User;
using FSM.Infrastructure.Helpers;
using FSM.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FSM.Api.Controllers.Admin
{
    /// <summary>
    /// User 模块
    /// </summary>
    public class UserController : AdminController
    {
        private readonly IUserService _userService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="baseService"></param>
        /// <param name="userService"></param>
        public UserController(
            IBaseService baseService,
            IUserService userService
            ) : base(baseService)
        {
            _userService = userService;
        }



        /// <summary>
        /// 创建商户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateMerchant([FromBody] CreateMerchantRequestDto dto)
        {
            if (!ModelState.IsValid) 
            {
                return Ok(ResponseHelper.BadRequest("Invalid request data."));
            }

            var result = await _userService.CreateMerchant(dto);
            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> CreateSupplier([FromBody] CreateSupplierRequestDto dto)
        {
            if (!ModelState.IsValid) return Ok(ResponseHelper.BadRequest("Invalid request data."));

            var result = await _userService.CreateSupplier(dto);
            return Ok(result);
        }
    }
}
