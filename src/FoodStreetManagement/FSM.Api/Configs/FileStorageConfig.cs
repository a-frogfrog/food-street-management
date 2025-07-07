using Microsoft.AspNetCore.Mvc;

namespace FSM.Api.Configs
{
 
    /// <summary>
    /// File Storage Config
    /// 文件存储配置
    /// </summary>
    public class FileStorageConfig
    {
        /// <summary>
        /// Upload Base
        /// 上传文件基础路径
        /// </summary>
        public string BaseDirectory { get; set; } = null!;

        /// <summary>
        /// Upload Path
        /// 上传文件路径
        /// </summary>
        public string UploadPath { get; set; } = null!;


        /// <summary>
        /// Image Path
        /// 图片路径
        /// </summary>
        public string ImagePath { get; set; } = null!;

        /// <summary>
        ///  Base Url
        /// 基础地址
        /// </summary>
        public string BaseUrl { get; set; } = null!;



        /// <summary>
        /// Get Base Url
        /// 获取基础地址
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static FileStorageConfig LoadConfig(IConfiguration configuration)
        {
            return configuration.GetSection("FileStorage").Get<FileStorageConfig>();
        }




        /// <summary>
        /// Get File Uploaded Directory
        /// 获取静态资源目录
        /// </summary>
        /// <returns></returns>
        public string GetUploadDirectory()
        {
            string path = Path.Combine(BaseDirectory, UploadPath);
            if (File.Exists(path)) return path;

            Directory.CreateDirectory(path);
            return path;
        }


        /// <summary>
        /// Get Image Directory
        /// 获取图片目录
        /// </summary>
        /// <returns></returns>
        public string GetImageDirectory()
        {

            string path = Path.Combine(BaseDirectory, ImagePath);
            if (Directory.Exists(path)) return path;

            Directory.CreateDirectory(path);
            return path;
        }


        /// <summary>
        /// Get Image Url
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string GetImageUrl(string fileName)
        { 
            return Path.Combine(BaseUrl, ImagePath, fileName).Replace('\\', '/');
        }
    }
}
