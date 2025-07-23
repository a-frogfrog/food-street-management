using FSM.Infrastructure.Attribute;
using FSM.Repository.EntityRepositories.Repositorys;

namespace FSM.Service.Dependencies
{

    /// <summary>
    /// User Service Dependencies   
    /// 用户服务依赖
    /// </summary>
    [Provider, Inject]
    public class UserDependencies
    {
        public readonly UserRepository User;
        public readonly SupplierRepository Supplier;
        public readonly MerchantRepository Merchant;

        public UserDependencies(
            UserRepository user,
            SupplierRepository supplier,
            MerchantRepository merchant)
        {
            User = user;
            Supplier = supplier;
            Merchant = merchant;
        }
    }
}
