using FSM.Infrastructure.Attribute;
using FSM.Repository.EntityRepositories.Repositorys;

namespace FSM.Service.Dependencies
{
    /// <summary>
    /// Dictionary Service Dependencies
    /// 字典服务依赖
    /// </summary>
    [Provider, Inject]
    public class DictionaryDependencies
    {
        public readonly DictionaryRepository Dictionary;

        public DictionaryDependencies(DictionaryRepository dictionary)
        {
            Dictionary = dictionary;
        }
    }
}
