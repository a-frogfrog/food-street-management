using FSM.Infrastructure.Attribute;
using FSM.Infrastructure.EFCore.MySql.Models;
using FSM.Repository.Interface;

namespace FSM.Repository.EntityRepositories.Repositorys
{
    [Provider, Inject]
    public class DictionaryRepository : BaseRepository<Dictionary>
    {
        public DictionaryRepository(IRepository<Dictionary> repository) : base(repository)
        {
        }
    }
}
