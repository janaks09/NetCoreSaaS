using System;
using System.Linq;
using System.Linq.Expressions;

namespace NetCoreSaaS.Data.Abstracts
{
    public interface IRepository<T> where T : class
    {
        int Count();

        int Count(Expression<Func<T, bool>> predicate);

        T GetSingle(int id);

        T GetSingle(Expression<Func<T, bool>> predicate);

        T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> GetAllIncluding(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> GetAll();
        IQueryable<T> GetAll(int count);

        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void DeleteWhere(Expression<Func<T, bool>> predicate);
    }
}
