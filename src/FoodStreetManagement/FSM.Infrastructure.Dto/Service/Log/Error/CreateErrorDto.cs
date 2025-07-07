namespace FSM.Infrastructure.Dto.Service.Log.Error
{
    /// <summary>
    /// This class is used to create a error log
    /// </summary>
    public class CreateErrorDto
    {
        /// <summary>
        /// 错误代码
        /// </summary>
        public string ErrorCode { get; set; } = string.Empty;

        /// <summary>
        /// 错误消息
        /// </summary>
        public string ErrorMessage { get; set; } = string.Empty;

        /// <summary>
        /// 错误类型
        /// </summary>
        public string ErrorType { get; set; } = string.Empty;

        /// <summary>
        /// HTTP状态码 可为空
        /// </summary>
        public int? HttpStatusCode { get; set; }

        /// <summary>
        /// 错误堆栈
        /// </summary>
        public string? StackTrace { get; set; }
    }
}
