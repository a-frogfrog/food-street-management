namespace FSM.Infrastructure.Dto.Api.Request.Admin.Product
{
    /// <summary>
    /// Get Product Request DTO.
    /// 获取商品请求DTO
    /// </summary>
    public class GetProductRequestDto
    {
        /// <summary>
        /// 分页 page
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 分页 size
        /// </summary>
        public int PageSize { get; set; }


        /// <summary>
        /// 商品名称 Name
        /// </summary>
        public string Name { get; set; } = string.Empty;



    }
}
