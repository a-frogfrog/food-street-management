using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.Dto.Service.Permission;
using FSM.Infrastructure.Helpers;
using FSM.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

namespace FSM.Api.Filters
{
    /// <summary>
    /// 权限过滤器
    /// </summary>
    public class PermissionFilter : BaseFilter
    {
        private readonly IBaseService _baseService;
        private readonly IPermissionService _permissionService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="baseService"></param>
        /// <param name="permissionService"></param>
        public PermissionFilter(
            IBaseService baseService,
            IPermissionService permissionService
            )
        {
            _baseService = baseService;
            _permissionService = permissionService;
        }

        /// <summary>
        /// 权限验证
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // TODO: 权限验证
            var action = context.ActionDescriptor as ControllerActionDescriptor; //获取当前控制器方法

            var controllerAttr = action!.ControllerTypeInfo.GetCustomAttribute<PermissionAttribute>(); //获取当前控制器类的PermissionAttribute特性
            if (controllerAttr == null)
            {
                return;
            }

            if (!controllerAttr.IsCheck)
            {
                return;
            }

            var attribute = action!.MethodInfo.GetCustomAttribute<PermissionAttribute>(); //获取当前控制器方法的PermissionAttribute特性
            if (attribute == null)
            {
                context.Result = new OkObjectResult(ResponseHelper.Forbidden());
                return;
            }

            var urls = attribute.Urls;
            string sessionId = context.HttpContext.User.Identity?.Name ?? "anonymous";
            var user = _baseService.GetUserInfo(sessionId); //获取当前用户信息

            if (user == null)
            {
                context.Result = new OkObjectResult(ResponseHelper.Forbidden());
                return;
            }

            bool result = _permissionService.CheckPermission(new CheckUserPermissionDto()
            {
                UserId = user.UserId,
                Permissions = new List<string>(urls!)
            });
            if (!result)
            {
                context.Result = new OkObjectResult(ResponseHelper.Forbidden());
                return;
            }


            base.OnActionExecuting(context);
        }

    }
}
