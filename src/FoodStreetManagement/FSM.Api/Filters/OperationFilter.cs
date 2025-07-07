using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.Dto.Service.Log.Operation;
using FSM.Service.Interface;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

namespace FSM.Api.Filters
{

    /// <summary>
    /// 操作日志过滤器
    /// </summary>
    public class OperationFilter : BaseFilter
    {
        private readonly ILogService _logService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="logService"></param>
        public OperationFilter(ILogService logService)
        {
            _logService = logService;
        }

        /// <summary>
        /// 执行结果
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (context.ActionDescriptor is not ControllerActionDescriptor descriptor)
            {
                await next();
                return;
            }

            var attribute = descriptor.MethodInfo.GetCustomAttribute<OperationAttribute>();
            if (attribute == null)
            {
                await next();
                return;
            }
            
            var httpContext = context.HttpContext;
            string sessionId = httpContext.User.Identity?.Name ?? "anonymous";
            
            var log = new CreateOperationDto()
            {
                Module = attribute.Module,
                Action = attribute.Action,
                OperationType = attribute.Type,    
                Status = httpContext.Response.StatusCode,
                Method = httpContext.Request.Method,
                
            };
            await _logService.WriteOperationLog(log);

            await base.OnResultExecutionAsync(context, next);
        }
    }
}
