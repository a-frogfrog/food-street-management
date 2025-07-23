namespace FSM.Infrastructure.Attribute
{
    /// <summary>
    /// Attribute for Provider
    /// 标记接口或类为Provider
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class)]
    public class ProviderAttribute:System.Attribute
    {
    }
}
