using System.ComponentModel.DataAnnotations;

namespace FSM.Infrastructure.Attribute
{
    /// <summary>
    /// Logging Operation Attribute
    /// 记入操作日志特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class OperationAttribute:System.Attribute
    {
        /// <summary>
        /// 操作模块
        /// </summary>
        [Required]
        public string Module { get; set; } = string.Empty;

        /// <summary>
        /// 操作行为
        /// </summary>
        [Required]
        public string Action { get; set; } = string.Empty;

        /// <summary>
        /// 操作类型
        /// </summary>
        [Required]
        public string Type { get; set; } = string.Empty;
    }
}
