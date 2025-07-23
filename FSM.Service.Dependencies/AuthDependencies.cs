using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.Tools;
using FSM.Repository.EntityRepositories.Repositorys;

namespace FSM.Service.Dependencies
{
    /// <summary>   
    /// User Authentication Service Dependencies
    /// 用户认证服务依赖
    /// </summary>
    [Provider, Inject]
    public class AuthDependencies
    {
        public readonly UserRepository User;
        public readonly LoginLogRepository LoginLog;
        public readonly SupplierRepository Supplier;
        public readonly MerchantRepository Merchant;

        public AuthDependencies(
            UserRepository user,
            LoginLogRepository loginLog,
            SupplierRepository supplier,
            MerchantRepository merchant)
        {
            User = user;
            LoginLog = loginLog;
            Supplier = supplier;
            Merchant = merchant;
            
        }


        /// <summary>
        /// 验证用户密码
        /// </summary>
        /// <param name="inputPassword">输入的密码</param>
        /// <param name="password">数据库哈希后的密码</param>
        /// <param name="salt">数据库盐值</param>
        /// <returns></returns>
        public bool IsAuthenticated(string inputPassword, string password, string salt)
        {
            //TODO: Check if user is authenticated
            var result = EncryptUtil.LoginMd5(inputPassword, salt);
            if (result != password) return false;
            return true;
        }
    }
}
