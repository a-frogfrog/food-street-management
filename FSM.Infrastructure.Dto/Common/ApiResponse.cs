namespace FSM.Infrastructure.Dto.Common
{

    /// <summary>
    /// 接口响应类型 泛型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResponse<T>
    {
        /// <summary>
        /// 接口响应类型
        /// </summary>
        public ApiResponseCode Code { get; set; }

        /// <summary>
        /// 接口响应消息
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// 接口响应数据
        /// </summary>
        public T? Data { get; set; }

    }

    /// <summary>
    /// 接口响应类型
    /// </summary>
    public class ApiResponse : ApiResponse<object>
    {

    }
}
