using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.Dto.Common;
using FSM.Infrastructure.Helpers;
using FSM.Service.Dependencies;
using FSM.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace FSM.Service.Instance
{
    [Inject]
    public class ProductService : ResponseHelper, IProductService
    {
        private readonly ProductDependencies _productDependencies;

        public ProductService(ProductDependencies productDependencies)
        {
            _productDependencies = productDependencies;
        }

        public async Task<ApiResponse> GetProductList()
        {
            var query = await _productDependencies.Product.QueryAll().ToListAsync();

            return Ok("Success", query);
        }
    }
}
