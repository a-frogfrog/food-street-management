using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.EFCore.MySql.Models;
using FSM.Repository.Interface;

namespace FSM.Repository.EntityRepositories.Repositorys
{
    [Provider, Inject]
    public class OperationLogRepository : BaseRepository<OperationLog>
    {
        public OperationLogRepository(IRepository<OperationLog> repository) : base(repository)
        {
        }
    }
}
