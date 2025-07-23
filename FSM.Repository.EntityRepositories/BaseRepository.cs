using FSM.Repository.Interface;
using System.Linq.Expressions;

namespace FSM.Repository.EntityRepositories
{
    public class BaseRepository<T>: IBaseRepository<T> where T : class, new()
    {
        private readonly IRepository<T> _repository;

        public BaseRepository(IRepository<T> repository)
        {
            _repository = repository;
        }
        public void Add(T entity)
        {
            _repository.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _repository.AddRange(entities);
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _repository.DeleteRange(entities);
        }

        public IQueryable<T> QueryAll(Expression<Func<T, bool>>? where = null)
        {
            return _repository.QueryAll(where);
        }

        public IQueryable<T> QueryAll<TType>(bool isAsc, Expression<Func<T, TType>> order, Expression<Func<T, bool>>? where = null)
        {
            return _repository.QueryAll<TType>(isAsc, order, where);
        }

        public IQueryable<T> QueryAll<TType>(out int total, int page = 1, int limit = 10, bool isAsc = true, Expression<Func<T, TType>>? order = null, Expression<Func<T, bool>>? where = null)
        {
            return _repository.QueryAll<TType>(out total, (page - 1) * limit, limit, isAsc, order!, where);
        }

        public int SaveChanges()
        {
            return _repository.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _repository.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _repository.UpdateRange(entities);
        }
    }
}
