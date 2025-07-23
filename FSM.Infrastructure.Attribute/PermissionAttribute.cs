namespace FSM.Infrastructure.Attribute
{
    /// <summary>
    /// Permission Attribute
    /// 权限特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class PermissionAttribute : System.Attribute
    {
        /// <summary>
        /// 接口所依附的地址
        /// </summary>
        public string[]? Urls { get; set; }

        /// <summary>
        /// 是否需要权限校验
        /// </summary>
        public bool IsCheck { get; set; } = false;
    }
}
