using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.EFCore.MySql.Models;
using FSM.Repository.Interface;

namespace FSM.Repository.EntityRepositories.Repositorys
{
    [Provider, Inject]
    public class LoginLogRepository : BaseRepository<LoginLog>
    {
        public LoginLogRepository(IRepository<LoginLog> repository) : base(repository)
        {
        }
    }
}
