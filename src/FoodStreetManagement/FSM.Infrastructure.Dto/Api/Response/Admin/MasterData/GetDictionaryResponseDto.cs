namespace FSM.Infrastructure.Dto.Api.Response.Admin.MasterData
{
    /// <summary>
    /// Get Dictionary Response DTO.
    /// 获取字典响应DTO
    /// </summary>
    public class GetDictionaryResponseDto
    {
        /// <summary>
        /// Dictionary Id.
        /// 字典ID
        /// </summary>
        public string Id { get; set; } = null!;

        /// <summary>
        /// Dictionary Name.
        /// 字典名称
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Dictionary Value.
        /// 字典值
        /// </summary>
        public string Value { get; set; } = null!;

        /// <summary>
        /// Dictionary Code.
        /// 字典编码
        /// </summary>
        public string Code { get; set; } = null!;

        /// <summary>
        /// Dictionary Serial Number.
        /// 字典序号
        /// </summary>
        public int SerialNumber { get; set; }

        /// <summary>
        /// Dictionary Parent Id.
        /// 字典父级ID
        /// </summary>
        public string? ParentId { get; set; }

        /// <summary>
        /// Dictionary Level.
        /// 字典层级
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Dictionary Is Node.
        /// 是否为节点
        /// </summary>
        public int IsNode { get; set; }

        /// <summary>
        /// Dictionary Status.
        /// 字典状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Dictionary Update Time.
        /// 字典更新时间
        /// </summary>
        public string UpdateTime { get; set; } = null!;

        /// <summary>
        /// Dictionary Create Time.
        /// 字典创建时间
        /// </summary>
        public string CreateTime { get; set; } = null!;


        /// <summary>
        /// Dictionary Description.
        /// 字典描述
        /// </summary>
        public string? Description { get; set; }



        /// <summary>
        /// Dictionary Children.
        /// 字典子项
        /// </summary>
        public List<GetDictionaryResponseDto>? Children { get; set; }
    }
}
