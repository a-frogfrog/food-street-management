using FSM.Infrastructure.Attribute;
using System.Reflection;

namespace FSM.Api.utils
{
    /// <summary>
    /// 扩展注入
    /// </summary>
    public static class InjectionExtensions
    {
        /// <summary>
        /// Scope注入
        /// </summary>
        /// <param name="services"></param>
        /// <param name="providers"></param>
        /// <param name="injects"></param>
        public static void AddScoped(this IServiceCollection services, Assembly providers, Assembly injects)
        {
            var providerTypes = providers.GetTypes()
                .Where(type => type.GetCustomAttribute(typeof(ProviderAttribute)) != null).ToList();
            var injectTypes = injects.GetTypes()
                .Where(type => type.GetCustomAttribute(typeof(InjectAttribute)) != null).ToList();

            providerTypes.ForEach(proType =>
            {
                var injTypes = injectTypes.Where(inj => proType.IsAssignableFrom(inj)).ToList();
                injTypes.ForEach(injType => services.AddScoped(proType, injType));
            });
        }

        /// <summary>
        /// Transient注入
        /// </summary>
        /// <param name="services"></param>
        /// <param name="providers"></param>
        /// <param name="injects"></param>
        public static void AddTransient(this IServiceCollection services, Assembly providers, Assembly injects)
        {
            var providerTypes = providers.GetTypes()
                .Where(type => type.GetCustomAttribute(typeof(ProviderAttribute)) != null).ToList();
            var injectTypes = injects.GetTypes()
                .Where(type => type.GetCustomAttribute(typeof(InjectAttribute)) != null).ToList();

            providerTypes.ForEach(proType =>
            {
                var injTypes = injectTypes.Where(inj => proType.IsAssignableFrom(inj)).ToList();
                injTypes.ForEach(injType => services.AddScoped(proType, injType));
            });
        }

        /// <summary>
        /// Singleton注入
        /// </summary>
        /// <param name="services"></param>
        /// <param name="providers"></param>
        /// <param name="injects"></param>
        public static void AddSingleton(this IServiceCollection services, Assembly providers, Assembly injects)
        {
            var providerTypes = providers.GetTypes()
                .Where(type => type.GetCustomAttribute(typeof(ProviderAttribute)) != null).ToList();
            var injectTypes = injects.GetTypes()
                .Where(type => type.GetCustomAttribute(typeof(InjectAttribute)) != null).ToList();

            providerTypes.ForEach(proType =>
            {
                var injTypes = injectTypes.Where(inj => proType.IsAssignableFrom(inj)).ToList();
                injTypes.ForEach(injType => services.AddScoped(proType, injType));
            });
        }
    }
}
