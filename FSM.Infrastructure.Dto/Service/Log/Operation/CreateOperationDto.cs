namespace FSM.Infrastructure.Dto.Service.Log.Operation
{
    /// <summary>
    /// 创建操作日志
    /// </summary>
    public class CreateOperationDto
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// 模块名称
        /// </summary>
        public string Module { get; set; } = string.Empty;

        /// <summary>
        /// 操作行为
        /// </summary>
        public string Action { get; set; } = string.Empty;

        /// <summary>
        /// 操作类型
        /// </summary>
        public string OperationType { get; set; } = string.Empty;

        /// <summary>
        /// 参数
        /// </summary>
        public string Parameters { get; set; } = string.Empty;

        /// <summary>
        /// 请求方法
        /// </summary>
        public string Method { get; set; } = string.Empty;

        /// <summary>
        /// 操作状态
        /// </summary>
        public int Status { get; set; }
    }
}
