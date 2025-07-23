using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.EFCore.MySql.Models;
using FSM.Repository.Interface;

namespace FSM.Repository.EntityRepositories.Repositorys
{
    [Provider, Inject]
    public class MerchantRepository : BaseRepository<Merchant>
    {
        public MerchantRepository(IRepository<Merchant> repository) : base(repository)
        {
        }
    }
}
