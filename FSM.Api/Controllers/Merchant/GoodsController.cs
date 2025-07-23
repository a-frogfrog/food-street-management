using FSM.Service.Interface;

namespace FSM.Api.Controllers.Merchant
{

    /// <summary>
    /// 商户商品管理
    /// </summary>
    public class GoodsController : MerchantController
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="baseService"></param>
        public GoodsController(IBaseService baseService) : base(baseService)
        {
        }
    }
}
