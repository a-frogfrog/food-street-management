using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.EFCore.MySql.Models;
using FSM.Repository.Interface;

namespace FSM.Repository.EntityRepositories.Repositorys
{
    [Provider, Inject]
    public class ErrorLogRepository : BaseRepository<Errorlog>
    {
        public ErrorLogRepository(IRepository<Errorlog> repository) : base(repository)
        {
        }
    }
}
