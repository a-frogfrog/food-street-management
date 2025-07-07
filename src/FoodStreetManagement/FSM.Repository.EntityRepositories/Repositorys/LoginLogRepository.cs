using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.EFCore.MySql.Models;
using FSM.Repository.Interface;

namespace FSM.Repository.EntityRepositories.Repositorys
{
    [Provider, Inject]
    public class LoginLogRepository : BaseRepository<Loginlog>
    {
        public LoginLogRepository(IRepository<Loginlog> repository) : base(repository)
        {
        }
    }
}
