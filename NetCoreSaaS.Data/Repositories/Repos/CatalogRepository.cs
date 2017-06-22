using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NetCoreSaaS.Data.Abstracts;
using NetCoreSaaS.Data.Contexts;

namespace NetCoreSaaS.Data.Repositories.Repos
{
    public class CatalogRepository<T> : IRepository<T>
        where T : EntityBase, new()
    {
        private readonly CatalogDbContext _context;

        public CatalogRepository(CatalogDbContext context)
        {
            _context = context;
        }

        public virtual void Add(T entity)
        {
            try
            {
                EntityEntry dbEntityEntry = _context.Entry(entity);
                _context.Set<T>().Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                var query = _context.Set<T>().AsNoTracking();
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
                return query.AsQueryable();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual int Count()
        {
            try
            {
                return _context.Set<T>().AsNoTracking().Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return _context.Set<T>().AsNoTracking().Where(predicate).Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public IQueryable<T> GetAll()
        {
            try
            {
                return _context.Set<T>().AsNoTracking().AsQueryable();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return _context.Set<T>().AsNoTracking().Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T GetSingle(int id)
        {
            try
            {
                return _context.Set<T>().AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                IQueryable<T> query = _context.Set<T>();
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }

                return query.AsNoTracking().Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual void Update(T entity)
        {
            try
            {
                EntityEntry dbEntityEntry = _context.Entry(entity);
                dbEntityEntry.State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual void Delete(T entity)
        {
            try
            {
                EntityEntry dbEntityEntry = _context.Entry<T>(entity);
                dbEntityEntry.State = EntityState.Deleted;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            try
            {
                var entites = _context.Set<T>().Where(predicate);
                foreach (var entity in entites)
                {
                    _context.Entry<T>(entity).State = EntityState.Deleted;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return _context.Set<T>().AsNoTracking().Where(predicate).AsQueryable();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IQueryable<T> GetAllIncluding(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                IQueryable<T> query = _context.Set<T>();
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }

                return query.AsNoTracking().Where(predicate).AsQueryable();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<T> GetAll(int count)
        {
            try
            {
                return _context.Set<T>().AsNoTracking().AsQueryable().Take(count);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
