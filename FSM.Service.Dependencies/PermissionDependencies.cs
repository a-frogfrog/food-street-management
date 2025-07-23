using FSM.Infrastructure.Attribute;
using FSM.Repository.EntityRepositories.Repositorys;

namespace FSM.Service.Dependencies
{
    /// <summary>
    /// Permission Service Dependencies
    /// 权限服务依赖
    /// </summary>
    [Provider,Inject]
    public class PermissionDependencies
    {
        public readonly PermissionRepository Permission;
        public readonly UserPermissionRepository UserPermission;

        public PermissionDependencies(
            PermissionRepository permission,
            UserPermissionRepository userPermission) 
        {
            Permission = permission;
            UserPermission = userPermission;
        }
    }
}
