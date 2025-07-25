﻿using System.Linq.Expressions;

namespace FSM.Repository.Interface
{
    public interface IRepository<T> where T : class, new()
    {
        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        void Delete(T entity);

        void DeleteRange(IEnumerable<T> entities);

        void Update(T entity);

        void UpdateRange(IEnumerable<T> entities);

        int SaveChanges();

        Task<int> SaveChangesAsync();

        IQueryable<T> QueryAll(Expression<Func<T, bool>>? where = null);

        IQueryable<T> QueryAll<TType>(bool isAsc, Expression<Func<T, TType>> order, Expression<Func<T, bool>>? where = null);

        IQueryable<T> QueryAll<TType>(out int total , int skip, int take, bool isAsc, Expression<Func<T, TType>> order, Expression<Func<T, bool>>? where = null);
    }
}
