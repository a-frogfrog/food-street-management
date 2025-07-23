using FSM.Infrastructure.Attribute;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using UAParser;

namespace FSM.Infrastructure.Tools
{
    /// <summary>
    /// Http上下文工具类
    /// </summary>
    [Provider, Inject]
    public class HttpContextUtils
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _responseUrl;
        private readonly string _responseToken;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        public HttpContextUtils(
            IHttpContextAccessor httpContextAccessor,
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;
            _responseUrl = _configuration["IPInfo:Url"];
            _responseToken = _configuration["IPInfo:Token"];
        }

        /// <summary>
        /// 获取当前请求的 UserAgent
        /// </summary>
        /// <returns></returns>
        public string GetUserAgent()
        {
            return _httpContextAccessor.HttpContext.Request.Headers["User-Agent"].FirstOrDefault() ?? "Unknown";
        }

        /// <summary>
        /// 获取当前请求的 IP 地址
        /// </summary>
        /// <returns></returns>
        public string GetIpAddress()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null) return "";

            // 优先从 ForwardedHeaders 中间件获取
            var remoteIp = httpContext.Connection.RemoteIpAddress;
            if (remoteIp != null && !remoteIp.IsIPv4MappedToIPv6 && !remoteIp.IsIPv6LinkLocal)
            {
                return remoteIp.ToString();
            }

            // 尝试从 X-Forwarded-For 头获取
            var forwardedFor = httpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (!string.IsNullOrEmpty(forwardedFor))
            {
                return forwardedFor.Split(',').First().Trim();
            }

            return httpContext.Connection.RemoteIpAddress?.ToString() ?? "";
        }

        /// <summary>
        /// 获取当前请求的 URL
        /// </summary>
        /// <returns></returns>
        public string GetRquestUrl()
        {
            return _httpContextAccessor.HttpContext.Request.Path;
        }

        /// <summary>
        /// 判断当前请求的来源设备
        /// </summary>
        /// <returns></returns>
        public string DetectSource()
        {
            var context = _httpContextAccessor.HttpContext;
            if (context == null) return "未知";

            var userAgent = GetUserAgent();
            if (string.IsNullOrEmpty(userAgent)) return "未知";

            var parser = Parser.GetDefault();
            var clientInfo = parser.Parse(userAgent);


            // 判断是否为移动设备（手机或平板）
            var deviceFamily = clientInfo.Device.Family?.ToLower() ?? "";
            var osFamily = clientInfo.OS.Family?.ToLower() ?? "";

            // 常见平板设备标识
            bool isTablet =
                deviceFamily.Contains("tablet") ||
                (osFamily.Contains("ios") && deviceFamily.Contains("ipad")) ||
                (osFamily.Contains("android") && !deviceFamily.Contains("mobile"));

            // 常见移动设备标识
            bool isMobile =
                deviceFamily.Contains("mobile") ||
                (osFamily.Contains("ios") && deviceFamily.Contains("iphone")) ||
                isTablet; // 平板也算移动设备

            // 常见桌面设备标识
            bool isDesktop =
                osFamily.Contains("windows") ||
                osFamily.Contains("mac os x") ||
                osFamily.Contains("linux");

            return isTablet ? "Tablet" : isMobile ? "Mobile" : isDesktop ? "PC" : "Unknown";
        }

        /// <summary>
        /// 获取当前请求的地理位置
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        public async Task<string> GetLocation(string ipAddress)
        {
            return await GetGeolocationAsync(ipAddress, _responseUrl, _responseToken);

        }

        /// <summary>
        /// private 获取地理位置 内部方法
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="url"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        private async Task<string> GetGeolocationAsync(string ipAddress, string url, string apiKey)
        {
            var response = await _httpClient.GetAsync($"{url}?ip={ipAddress}&key={apiKey}");

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return json;
                }
                throw new Exception($"Error: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// 获取当前请求的方法
        /// </summary>
        /// <returns></returns>
        public string GetRequestMethod()
        {
            return _httpContextAccessor.HttpContext.Request.Method;
        }
    
    }
}
