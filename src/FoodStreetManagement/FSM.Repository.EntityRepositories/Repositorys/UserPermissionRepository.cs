using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.EFCore.MySql.Models;
using FSM.Repository.Interface;

namespace FSM.Repository.EntityRepositories.Repositorys
{
    [Provider, Inject]
    public class UserPermissionRepository : BaseRepository<Userpermission>
    {
        public UserPermissionRepository(IRepository<Userpermission> repository) : base(repository)
        {
        }
    }
}
