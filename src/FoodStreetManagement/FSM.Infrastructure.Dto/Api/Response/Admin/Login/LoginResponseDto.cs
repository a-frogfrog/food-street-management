using System.ComponentModel.DataAnnotations;

namespace FSM.Infrastructure.Dto.Api.Response.Admin.Login
{
    /// <summary>
    /// 登录响应 DTO
    /// </summary>
    public class LoginResponseDto
    {
        /// <summary>
        /// sessionId
        /// </summary>
        [Required]
        public string SessionId { get; set; } = string.Empty;

        /// <summary>
        /// 凭据
        /// </summary>
        [Required]
        public string Token { get; set; } = string.Empty;
    }
}
