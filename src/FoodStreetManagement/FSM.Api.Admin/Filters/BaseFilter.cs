using Microsoft.AspNetCore.Mvc.Filters;

namespace FSM.Api.Filters
{
    /// <summary>
    /// 基础过滤器
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class BaseFilter: ActionFilterAttribute
    {
    }
}
