using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.Dto.Common;

namespace FSM.Service.Interface
{
    /// <summary>
    /// Product service interface.
    /// 商品服务接口
    /// </summary>
    [Provider]
    public interface IProductService
    {
        Task<ApiResponse> GetProductList();
    }
}
