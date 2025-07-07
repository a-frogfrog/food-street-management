using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.EFCore.MySql.Models;
using FSM.Repository.Interface;

namespace FSM.Repository.EntityRepositories.Repositorys
{
    [Provider, Inject]
    public class SupplierLoginLogRepository : BaseRepository<Supplierloginlog>
    {
        public SupplierLoginLogRepository(IRepository<Supplierloginlog> repository) : base(repository)
        {
        }
    }
}
