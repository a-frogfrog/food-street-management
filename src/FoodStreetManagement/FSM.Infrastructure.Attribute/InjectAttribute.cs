namespace FSM.Infrastructure.Attribute
{
    /// <summary>
    /// Attribute class for injecting dependencies.
    /// 标记需要注入的接口或类
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class)]
    public class InjectAttribute:System.Attribute
    {
    }
}
