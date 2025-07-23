using FSM.Infrastructure.Dto.Common;

namespace FSM.Infrastructure.Helpers
{
    /// <summary>
    /// Response Helper.
    /// 响应帮助类
    /// </summary>
    public abstract class ResponseHelper
    {
        /// <summary>
        /// Success.
        /// 成功
        /// </summary>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ApiResponse Ok(string message = "Success", object? data = default)
        {
            return new ApiResponse
            {
                Code = ApiResponseCode.Ok,
                Message = string.IsNullOrEmpty(message) ? "Success" : message,
                Data = data
            };
        }

        /// <summary>
        /// Success. T
        /// 成功(泛型)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ApiResponse<T> OkOf<T>(string message = "Success", T? data = default)
        {
            return new ApiResponse<T>
            {
                Code = ApiResponseCode.Ok,
                Message = string.IsNullOrEmpty(message) ? "Success" : message,
                Data = data
            };
        }

        /// <summary>
        ///  Failed.
        ///  失败
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ApiResponse Failed(string message = "Failed") 
        {
            return new ApiResponse() 
            {
                Code = ApiResponseCode.Failed,
                Message = string.IsNullOrEmpty(message) ? "Failed" : message
            };
        }

        /// <summary>
        /// Unauthorized.
        /// 未授权
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ApiResponse Unauthorized(string message = "Unauthorized") 
        {
            return new ApiResponse 
            {
                Code = ApiResponseCode.Unauthorized,
                Message = string.IsNullOrEmpty(message) ? "Unauthorized" : message
            };
        }

        /// <summary>
        /// Forbidden.
        /// 禁止
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ApiResponse Forbidden(string message = "Forbidden")
        {
            return new ApiResponse
            {
                Code = ApiResponseCode.Forbidden,
                Message = string.IsNullOrEmpty(message) ? "Forbidden" : message
            };
        }

        /// <summary>
        /// Error.
        /// 服务器内部错误
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ApiResponse Error(string message = "Error")
        {
            return new ApiResponse
            {
                Code = ApiResponseCode.Error,
                Message = string.IsNullOrEmpty(message) ? "Error" : message
            };
        }


        /// <summary>
        /// BadRequest.
        /// 请求错误
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ApiResponse BadRequest(string message = "Bad Request")
        {
            return new ApiResponse
            {
                Code = ApiResponseCode.BadRequest,
                Message = string.IsNullOrEmpty(message) ? "Bad Request" : message
            };
        }
    }
}
