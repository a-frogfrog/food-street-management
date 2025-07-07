using FSM.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FSM.Api.Controllers.Admin
{
    /// <summary>
    /// Product 模块
    /// </summary>
    public class ProductController : AdminController
    {
        private readonly IProductService _productService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="baseService"></param>
        /// <param name="productService"></param>
        public ProductController(
            IBaseService baseService,
            IProductService productService) : base(baseService)
        {
            _productService = productService;
        }


        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetProductList()
        { 
            var result = await _productService.GetProductList();
            return Ok(result);
        }
    }
}
