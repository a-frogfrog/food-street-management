namespace FSM.Api.Configs
{
    /// <summary>
    /// File Upload Config
    /// 文件上传配置
    /// </summary>
    public class FileUploadConfig
    {
        /// <summary>
        /// File Uplad Max Size
        /// 文件上传最大值
        /// </summary>
        public long MaxFileSize { get; set; }

        /// <summary>
        /// Allowed File Upload Extensions
        /// 允许上传的文件扩展名
        /// </summary>
        public string[] AllowedExtensions { get; set; } = null!;

        /// <summary>
        /// Configuration Loader
        /// 加载配置
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static FileUploadConfig LoadConfig(IConfiguration configuration)
        {
            return configuration.GetSection("FileUpload").Get<FileUploadConfig>();
        }

        /// <summary>
        /// Get Max File Size
        /// 获取文件上传最大值
        /// </summary>
        /// <returns></returns>
        public long GetMaxFileSize()
        { 
            return MaxFileSize;
        }

        /// <summary>
        /// Get Allowed File Upload Extensions
        /// 获取允许上传的文件扩展名
        /// </summary>
        /// <returns></returns>
        public string[] GetAllowedExtensions()
        { 
            return AllowedExtensions;
        }
    }
}
