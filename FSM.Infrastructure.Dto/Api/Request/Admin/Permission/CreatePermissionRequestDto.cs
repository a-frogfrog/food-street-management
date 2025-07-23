using System.ComponentModel.DataAnnotations;

namespace FSM.Infrastructure.Dto.Api.Request.Admin.Permission 
{
    /// <summary>
    /// Create Permission Request Dto.
    /// ����Ȩ������Dto.
    /// </summary>
    public class CreatePermissionRequestDto 
    {
        /// <summary>
        /// Ȩ������.
        /// </summary>
        [Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Ȩ�ޱ�ʶ.
        /// </summary>
        [Required]
        public string Url { get; set; } = string.Empty;

        /// <summary>
        /// Ȩ������ /�Ƿ�Ϊ�˵�.
        /// </summary>
        [Required]
        public int Type { get; set; } = 0;

        /// <summary>
        /// Ȩ��ͼ��.
        /// </summary>
        public string Icon { get; set; } = string.Empty;

        /// <summary>
        /// Ȩ�޸���Id.
        /// </summary>
        public string? ParentId { get; set; }

        /// <summary>
        /// Ȩ������.
        /// </summary>
        public string? Description { get; set; }
    }
}


