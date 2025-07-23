using FSM.Api.Configs;
using FSM.Infrastructure.Dto.Api.Response.Admin.Upload;
using FSM.Infrastructure.Dto.Common;
using FSM.Infrastructure.Tools;
using FSM.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FSM.Api.Controllers.Admin
{

    /// <summary>
    /// 文件上传 File upload
    /// </summary>
    public class UploadController : AdminController
    {
        private readonly UploadFileUtils _uploadFileUtils; //文件上传工具类 File upload tool class
        private readonly FileStorageConfig _fileStorageConfig;
        private readonly FileUploadConfig _fileUploadConfig;
        private readonly long _maxFileSize;
        private readonly string[] _allowedExtensions;
        private readonly string _uploadDirectory; //上传目录  Upload directory



      


        /// <summary>
        /// 构造函数 
        /// </summary>
        /// <param name="baseService"></param>
        /// <param name="uploadFileUtils"></param>
        /// <param name="fileStorageConfig"></param>
        /// <param name="fileUploadConfig"></param>
        public UploadController(
            IBaseService baseService,
            UploadFileUtils uploadFileUtils,
            FileStorageConfig fileStorageConfig,
            FileUploadConfig fileUploadConfig
            ) : base(baseService)
        {
            _uploadFileUtils = uploadFileUtils;
            _fileStorageConfig = fileStorageConfig;
            _fileUploadConfig = fileUploadConfig;

            //获取文件大小限制
            _maxFileSize = _fileUploadConfig.GetMaxFileSize(); //10M
            //获取允许的文件类型
            _allowedExtensions = _fileUploadConfig.GetAllowedExtensions();

            // 获取上传目录
            _uploadDirectory = _fileStorageConfig.GetImageDirectory();
            if (!Directory.Exists(_uploadDirectory))
                Directory.CreateDirectory(_uploadDirectory);
        }



        /// <summary>
        ///  单个文件上传 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        [RequestSizeLimit(1024 * 1024 * 10)] //10M
        //[Authorize]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("文件不能为空");
            }

            //判断文件大小是否超过限制
            bool isFileSizeExceeded = _uploadFileUtils.IsFileSizeExceeded(file.Length, _maxFileSize);
            if (isFileSizeExceeded) return BadRequest("文件大小超过限制");

            //判断文件类型是否允许
            bool isFileTypeAllowed = _uploadFileUtils.IsFileExtensionAllowed(file.FileName, _allowedExtensions);
            if (isFileTypeAllowed) return BadRequest("文件类型不允许");

            //生成文件名
            string fileName = _uploadFileUtils.GenerateFileName(file.FileName);
            var filePath = Path.Combine(_uploadDirectory, fileName);

            //保存文件
            var result = await _uploadFileUtils.SaveFileAsync(file, filePath);
            if (!result) return BadRequest("文件上传失败");


            //返回文件路径
            return Ok(new ApiResponse<SingleFileUploadResponseDto>()
            {
                Code = 0,
                Message = "上传成功！",
                Data = new SingleFileUploadResponseDto()
                {
                    FileName = fileName,
                    FileType = file.ContentType,
                    FileSize = file.Length,
                    FileUrl = _fileStorageConfig.GetImageUrl(fileName)
                }
            });
        }
    }
}
