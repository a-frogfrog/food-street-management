namespace FSM.Infrastructure.Dto.Common
{
    /// <summary>
    /// API Response Code
    /// 接口响应码
    /// </summary>
    public enum ApiResponseCode
    {
        /// <summary>
        /// Success
        /// 成功
        /// </summary>
        Ok = 0,
        /// <summary>
        /// Failed
        /// 失败
        /// </summary>
        Failed = -1,

        /// <summary>
        /// Exception
        /// 异常
        /// </summary>
        Error = 500,

        /// <summary>
        /// Bad Request
        /// 请求错误
        /// </summary>
        BadRequest = 400,

        /// <summary>
        /// Unauthorized
        /// 未授权
        /// </summary>
        Unauthorized = 401,

        /// <summary>
        /// Forbidden
        /// 拒绝访问
        /// </summary>
        Forbidden = 403,
    }
}
