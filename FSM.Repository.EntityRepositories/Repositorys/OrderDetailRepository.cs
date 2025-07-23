using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.EFCore.MySql.Models;
using FSM.Repository.Interface;

namespace FSM.Repository.EntityRepositories.Repositorys
{
    [Provider, Inject]
    public class OrderDetailRepository : BaseRepository<OrderDetail>
    {
        public OrderDetailRepository(IRepository<OrderDetail> repository) : base(repository)
        {
        }
    }
}
