using FSM.Infrastructure.Attribute;
using Microsoft.Extensions.Configuration;

namespace FSM.Infrastructure.Tools
{

    /// <summary>
    /// 读取配置文件工具类
    /// </summary>

    [Provider ,Inject]
    public class ReadConfigurationUtils
    {
        private readonly IConfiguration _configuration;

        public ReadConfigurationUtils(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        /// <summary>
        /// 获取配置文件中的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetValue(string key)
        {
            return _configuration[key] ?? string.Empty;
        }


        public string GetUserDefaultPassword()
        {
            return _configuration["UserKey:DefaultPassword"];
        }





    }
}
