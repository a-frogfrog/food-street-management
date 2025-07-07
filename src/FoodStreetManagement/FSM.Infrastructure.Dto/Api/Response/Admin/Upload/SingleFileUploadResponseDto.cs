namespace FSM.Infrastructure.Dto.Api.Response.Admin.Upload
{
    /// <summary>
    /// Uploaded single file response DTO.
    /// 单个上传文件响应DTO
    /// </summary>
    public class SingleFileUploadResponseDto
    {
        /// <summary>
        /// File name.
        /// 文件名
        /// </summary>
        public string FileName { get; set; } = null!;

        /// <summary>
        /// File size.
        /// 文件大小
        /// </summary>
        public long FileSize { get; set; }

        /// <summary>
        /// File type.
        /// 文件类型
        /// </summary>
        public string FileType { get; set; } = null!;

        /// <summary>
        /// File URL.
        /// 文件URL
        /// </summary>
        public string FileUrl { get; set; } = null!;

    }
}
