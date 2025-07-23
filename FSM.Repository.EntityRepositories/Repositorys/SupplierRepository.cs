using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.EFCore.MySql.Models;
using FSM.Repository.Interface;

namespace FSM.Repository.EntityRepositories.Repositorys
{
    [Provider, Inject]
    public class SupplierRepository : BaseRepository<Supplier>
    {
        public SupplierRepository(IRepository<Supplier> repository) : base(repository)
        {
        }
    }
}
