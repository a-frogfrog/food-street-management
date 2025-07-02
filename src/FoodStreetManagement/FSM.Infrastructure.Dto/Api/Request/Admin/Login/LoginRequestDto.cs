using System.ComponentModel.DataAnnotations;

namespace FSM.Infrastructure.Dto.Api.Request.Admin.Login
{
    /// <summary>
    /// 登录请求 DTO
    /// </summary>
    public class LoginRequestDto
    {
        /// <summary>
        /// 账号
        /// </summary>
        [Required(ErrorMessage = "账号不为空")]
        [StringLength(maximumLength: 11, ErrorMessage = "账号长度为11位", MinimumLength = 11)]
        public string Account { get; set; } = string.Empty;

        /// <summary>
        /// 密码 
        /// </summary>
        [Required(ErrorMessage = "密码不为空")]
        [StringLength(maximumLength: 32, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// 验证
        /// </summary>
        public string Payload { get; set; } = string.Empty;
    }
}
