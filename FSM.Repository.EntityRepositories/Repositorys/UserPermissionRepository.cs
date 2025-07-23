using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.EFCore.MySql.Models;
using FSM.Repository.Interface;

namespace FSM.Repository.EntityRepositories.Repositorys
{
    [Provider, Inject]
    public class UserPermissionRepository : BaseRepository<UserPermission>
    {
        public UserPermissionRepository(IRepository<UserPermission> repository) : base(repository)
        {
        }
    }
}
