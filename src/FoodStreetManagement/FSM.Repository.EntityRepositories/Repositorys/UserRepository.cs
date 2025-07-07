using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.EFCore.MySql.Models;
using FSM.Repository.Interface;

namespace FSM.Repository.EntityRepositories.Repositorys
{
    [Provider, Inject]
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(IRepository<User> repository) : base(repository)
        {
        }
    }
}
