using FSM.Infrastructure.Dto.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FSM.Api.Filters
{
    /// <summary>
    /// 响应过滤器
    /// </summary>

    [AttributeUsage(AttributeTargets.Method)]
    public class ResponseFilter : BaseFilter
    {

        /// <summary>
        /// 执行结果后
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public override Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {

            var result = (ObjectResult)context.Result;

            if (result.Value is not ApiResponse response)
            {
                return base.OnResultExecutionAsync(context, next);
            }

            if (response.Data is null)
            {
                context.Result = new ObjectResult(new
                {
                    response.Code,
                    response.Message,
                });
            }

            return base.OnResultExecutionAsync(context, next);
        }
    }
}
