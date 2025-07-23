using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.EFCore.MySql.Models;
using FSM.Repository.Interface;

namespace FSM.Repository.EntityRepositories.Repositorys
{
    [Provider, Inject]
    public class OrderRepository : BaseRepository<Order>
    {
        public OrderRepository(IRepository<Order> repository) : base(repository)
        {
        }
    }
}
