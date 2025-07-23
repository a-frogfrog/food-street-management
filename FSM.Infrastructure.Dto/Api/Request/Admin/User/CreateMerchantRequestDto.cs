using System.ComponentModel.DataAnnotations;

namespace FSM.Infrastructure.Dto.Api.Response.Admin.User
{

    /// <summary>
    /// 创建商户请求DTO.
    /// </summary>
    public class CreateMerchantRequestDto
    {
        /// <summary>
        /// 商户账号
        /// </summary>
        [Required]
        [StringLength(maximumLength: 11, MinimumLength = 11)]
        public string Account { get; set; } = string.Empty;

        /// <summary>
        /// 商户名称
        /// </summary>
        [Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 商户联系人
        /// </summary>
        [Required]
        public string Contacts { get; set; } = string.Empty;

        /// <summary>
        /// 商户类型
        /// </summary>
        [Required]
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// 营业执照编号
        /// </summary>
        [Required]
        public string BusinessLicense { get; set; } = string.Empty;


        /// <summary>
        /// 商户描述
        /// </summary>
        public string Description { get; set; } = string.Empty;

    }
}
