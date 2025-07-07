using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.Dto.Api.Request.Admin.Permission;
using FSM.Infrastructure.Dto.Common;
using FSM.Infrastructure.Helpers;
using FSM.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FSM.Api.Controllers.Admin
{
    /// <summary>
    /// Permission 模块
    /// </summary>
    public class PermissionController : AdminController
    {
        private readonly IPermissionService _permissionService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="baseService"></param>
        /// <param name="permissionService"></param>
        public PermissionController(
            IBaseService baseService,
            IPermissionService permissionService) : base(baseService)
        {
            _permissionService = permissionService;
        }

        /// <summary>
        /// 获取权限列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetPermissionList()
        {
            var result = await _permissionService.GetPermissionList();
            return Ok(result);
        }

        /// <summary>
        /// 获取用户权限菜单列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetUserPermissionMenuList()
        {
            var user = GetCurrentUser();
            if (user == null) return Ok(ResponseHelper.Unauthorized());

            var result = await _permissionService.GetUserPermissionMenuList(user.UserId);
            return Ok(result);
        }

        /// <summary>
        /// 创建权限
        /// </summary>
        /// <param name="permissionDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreatePermission([FromBody] CreatePermissionRequestDto permissionDto)
        {
            var result = await _permissionService.CreatePermission(permissionDto);
            return Ok(result);
        }


        /// <summary>
        /// 授予用户权限
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GrantPermission(GrantPermissionRequestDto dto) 
        {
            var result = await _permissionService.GrantPermission(dto);
            return Ok(result);
        }
    }
}
