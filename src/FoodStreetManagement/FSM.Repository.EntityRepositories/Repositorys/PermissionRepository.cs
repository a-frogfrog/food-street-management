using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.EFCore.MySql.Models;
using FSM.Repository.Interface;

namespace FSM.Repository.EntityRepositories.Repositorys
{
    [Provider, Inject]
    public class PermissionRepository : BaseRepository<Permission>
    {
        public PermissionRepository(IRepository<Permission> repository) : base(repository)
        {
        }
    }
}
