using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.EFCore.MySql.Models;
using FSM.Repository.Interface;

namespace FSM.Repository.EntityRepositories.Repositorys
{
    [Provider, Inject]
    public class MerchantLoginLogRepository : BaseRepository<MerchantLoginLog>
    {
        public MerchantLoginLogRepository(IRepository<MerchantLoginLog> repository) : base(repository)
        {
        }
    }
}
