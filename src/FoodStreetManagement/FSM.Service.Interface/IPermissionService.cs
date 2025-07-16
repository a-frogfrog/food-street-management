using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.Dto.Api.Request.Admin.Permission;
using FSM.Infrastructure.Dto.Common;
using FSM.Infrastructure.Dto.Service.Permission;
using FSM.Infrastructure.EFCore.MySql.Models;

namespace FSM.Service.Interface
{
    /// <summary>
    /// PermissionService interface.
    /// 权限服务接口
    /// </summary>
    [Provider]
    public interface IPermissionService
    {
        /// <summary>
        /// 检查用户权限
        /// </summary>
        /// <param name="checkUserPermissionDto"></param>
        /// <returns></returns>
        bool CheckPermission(CheckUserPermissionDto checkUserPermissionDto);

        /// <summary>
        /// 创建权限
        /// </summary>
        /// <param name="permissionDto"></param>
        /// <returns></returns>
        Task<ApiResponse> CreatePermission(CreatePermissionRequestDto permissionDto);

        /// <summary>
        /// 获取权限列表
        /// </summary>
        /// <returns></returns>
        Task<ApiResponse> GetPermissionList();

       /// <summary>
       /// 获取用户权限菜单列表
       /// </summary>
       /// <param name="userId"></param>
       /// <returns></returns>
        Task<ApiResponse> GetUserPermissionMenuList(string userId);

        /// <summary>
        /// 授予权限
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<ApiResponse> GrantPermission(GrantPermissionRequestDto dto);

        /// <summary>
        /// 获取用户权限列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<UserPermission> GetUserPermissionList(string userId);
    }
}
