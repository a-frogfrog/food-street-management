using FSM.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FSM.Repository.Instance
{
    public class MySqlRepository<T> : IRepository<T> where T : class, new()
    {
        private readonly DbContext _dbContext;

        public MySqlRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().AddRange(entities);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().UpdateRange(entities);
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        public IQueryable<T> QueryAll(Expression<Func<T, bool>>? where = null)
        {
            return _dbContext.Set<T>().AsQueryable().Where(where ?? (x => true));
        }

        public IQueryable<T> QueryAll<TType>(bool isAsc, Expression<Func<T, TType>> order,
            Expression<Func<T, bool>>? where = null)
        {
            var query = QueryAll(where);
            return isAsc ? query.OrderBy(order) : query.OrderByDescending(order);
        }

        public IQueryable<T> QueryAll<TType>(out int total, int skip, int take, bool isAsc,
            Expression<Func<T, TType>> order, Expression<Func<T, bool>>? where = null)
        {
            var query = QueryAll(isAsc, order, where);
            total = query.Count();
            return query.Skip(skip).Take(take);
        }
    }
}
