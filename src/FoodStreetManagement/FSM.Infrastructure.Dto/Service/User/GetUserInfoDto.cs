
namespace FSM.Infrastructure.Dto.Service.User
{
    /// <summary>
    /// 服务层获取用户信息Dto
    /// </summary>
    public class GetUserInfoDto
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public string UserId { get; set; } = null!;

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; } = null!;

        /// <summary>
        /// 用户账号
        /// </summary>
        public string Account { get; set; } = null!;

        /// <summary>
        /// 用户密码
        /// </summary>
        public string PasswordHash { get; set; } = null!;


        /// <summary>
        /// 用户密码盐
        /// </summary>
        public string PasswordSalt { get; set; } = null!;


        /// <summary>
        /// 用户状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
    }
}
