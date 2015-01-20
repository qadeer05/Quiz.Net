using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Data.Infrastructure.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Delete(T entity);

        IEnumerable<T> Get(
            Expression<Func<T, bool>> filter,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
            string includeProperties);

        void Insert(T entity);

        void Update(T entity);

    }
}
