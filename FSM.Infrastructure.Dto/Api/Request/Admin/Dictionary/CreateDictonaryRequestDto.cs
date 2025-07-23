using System.ComponentModel.DataAnnotations;

namespace FSM.Infrastructure.Dto.Api.Request.Admin.Dictionary
{
    /// <summary>
    /// Create Dictonary Request DTO.
    /// 创建字典请求DTO
    /// </summary>
    public class CreateDictonaryRequestDto
    {
        /// <summary>
        /// Dictionary Name.
        /// 字典名称
        /// </summary>
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "最大长度为50")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Dictionary Value.
        /// 字典值
        /// </summary>      
        [Required]
        [StringLength(maximumLength: 256, ErrorMessage = "最大长度为256")]
        public string Value { get; set; } = null!;

        /// <summary>
        /// Dictionary Code.
        /// 字典编码
        /// </summary>
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "最大长度为50")]
        public string Code { get; set; } = null!;

        /// <summary>
        /// Dictionary Parent Id.
        /// 字典父级ID
        /// </summary>
        [StringLength(maximumLength: 32, ErrorMessage = "最大长度为32")]
        public string? ParentId { get; set; }

        /// <summary>
        /// Dictionary Is Node.
        /// 是否为节点
        /// </summary>
        [Required]
        public int IsNode { get; set; }

        /// <summary>
        /// Dictionary Description.
        /// 字典描述
        /// </summary>
        [StringLength(maximumLength: 999, ErrorMessage = "描述")]
        public string? Description { get; set; }
    }
}
