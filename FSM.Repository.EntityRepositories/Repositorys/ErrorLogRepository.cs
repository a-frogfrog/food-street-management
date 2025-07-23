using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.EFCore.MySql.Models;
using FSM.Repository.Interface;

namespace FSM.Repository.EntityRepositories.Repositorys
{
    [Provider, Inject]
    public class ErrorLogRepository : BaseRepository<ErrorLog>
    {
        public ErrorLogRepository(IRepository<ErrorLog> repository) : base(repository)
        {
        }
    }
}
