using FSM.Infrastructure.Attribute;
using FSM.Repository.EntityRepositories.Repositorys;

namespace FSM.Service.Dependencies
{
    /// <summary>
    /// Product Service Dependencies.
    /// 商品服务依赖
    /// </summary>
    [Provider, Inject]
    public class ProductDependencies
    {
        public readonly ProductRepository Product;

        public ProductDependencies(ProductRepository product)
        {
            Product = product;
        }
    }
}
