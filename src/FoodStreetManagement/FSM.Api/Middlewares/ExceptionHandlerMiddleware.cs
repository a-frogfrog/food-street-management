using FSM.Infrastructure.Dto.Common;
using FSM.Infrastructure.Dto.Service.Log.Error;
using FSM.Infrastructure.Helpers;
using FSM.Infrastructure.Tools;
using FSM.Service.Interface;

namespace FSM.Api.MiddleWares
{
    /// <summary>
    /// 异常处理中间件
    /// </summary>
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _filePath;

        /// <summary>
        /// inject IConfiguration,RequestDelegate,ExceptionFileLogger service
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="next"></param>
        public ExceptionHandlerMiddleware(
            IConfiguration configuration,
            RequestDelegate next
            )
        {
            _next = next;
            string _fileName = "ExceptionLog-" + DateTime.Now.ToString("yyyy-MM-dd");

            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory) + _fileName
                ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory) + _fileName;
        }

        /// <summary>
        /// 处理异常
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exceptionFileLogger"></param>
        /// <param name="logService"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context, ExceptionFileLogger exceptionFileLogger, ILogService logService)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                await RunAsync(exceptionFileLogger, logService, ex, context);

                //返回异常信息
                context.Response.StatusCode = (int)ApiResponseCode.Error;
                context.Response.ContentType = "application/json";               
                var result = ResponseHelper.Error(ex.Message);

                await context.Response.WriteAsJsonAsync(result);
            }


        }

        /// <summary>
        /// 写入文件和数据库日志
        /// </summary>
        /// <param name="exceptionFileLogger"></param>
        /// <param name="logService"></param>
        /// <param name="ex"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private async Task RunAsync(ExceptionFileLogger exceptionFileLogger, ILogService logService, Exception ex, HttpContext context)
        {
            try
            {
                //记录文件异常日志
                exceptionFileLogger.LogAsync(_filePath, ex);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            try
            {
                //记录数据库日志
                await logService.WriteErrorLog(new CreateErrorDto()
                {
                    ErrorCode = ex.HResult.ToString(),
                    ErrorMessage = ex.Message,
                    HttpStatusCode = context.Response.StatusCode,
                    ErrorType = ex.GetType().ToString(),
                    StackTrace = ex.StackTrace
                });
            }
            catch (Exception e)
            {

                exceptionFileLogger.LogAsync(_filePath, e);
            }
        }
    }
}
