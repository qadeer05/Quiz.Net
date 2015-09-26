using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Quiz.Data.Context.EntityFramework;
using Quiz.Data.Infrastructure.Interfaces.Repositories;

namespace Quiz.Data.Infrastructure.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class 
    {

        private DbSet<T> _dbSet;

        protected RepositoryBase(DbContext context)
        {
            _dbSet = context.Set<T>();
            Context = context;
        }

        protected DbContext Context { get; private set; }


        public virtual IQueryable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

        public virtual T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(params object[] keyValues)
        {
            T entityToDelete = _dbSet.Find(keyValues);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entityToDelete)
        {
            if (Context.Entry(entityToDelete).State ==  EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public virtual void Update(T entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
