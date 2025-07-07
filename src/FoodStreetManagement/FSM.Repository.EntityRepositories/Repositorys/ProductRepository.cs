using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.EFCore.MySql.Models;
using FSM.Repository.Interface;

namespace FSM.Repository.EntityRepositories.Repositorys
{
    [Provider, Inject]
    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository(IRepository<Product> repository) : base(repository)
        {
        }
    }
}
