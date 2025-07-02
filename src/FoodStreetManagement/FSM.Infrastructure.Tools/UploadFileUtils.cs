using FSM.Infrastructure.Attribute;
using Microsoft.AspNetCore.Http;

namespace FSM.Infrastructure.Tools
{
    /// <summary>
    /// Upload file utils
    /// 上传文件工具类
    /// </summary>
    [Provider,Inject]
    public class UploadFileUtils
    {

        /// <summary>
        /// Check if file size is exceeded
        /// 检查文件大小是否超过限制
        /// </summary>
        /// <param name="fileSize"></param>
        /// <param name="maxFileSize"></param>
        /// <returns></returns>
        public bool IsFileSizeExceeded(long fileSize, long maxFileSize)
        {
            if (fileSize > maxFileSize)
                return true;
            return false;
        }


        /// <summary>
        /// Check if file extension is allowed
        /// 检查文件扩展名是否允许
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="allowedExtensions"></param>
        /// <returns></returns>
        public bool IsFileExtensionAllowed(string fileName, string[] allowedExtensions)
        {
            var extension = Path.GetExtension(fileName).ToUpperInvariant();
            if (allowedExtensions.Contains(extension))
                return true;
            return false;
        }


        /// <summary>
        /// Generate file name
        /// 生成文件名
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string GenerateFileName(string fileName)
        {
            string name = Path.GetFileNameWithoutExtension(fileName) 
                + "_" + Guid.NewGuid().ToString("N") 
                + "_" +DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")
                + Path.GetExtension(fileName);
            return name;
        }

        /// <summary>
        /// Save file
        /// 保存文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> SaveFileAsync(IFormFile file, string filePath)
        {
            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    
                    await file.CopyToAsync(stream);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
                
            }    
        }
    }
}
