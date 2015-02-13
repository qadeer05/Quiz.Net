using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz.Data.Context.EntityFramework;
using Quiz.Data.Infrastructure.Interfaces.UnitOfWork;
using Quiz.Data.Infrastructure.Repositories;
using Quiz.Infrastructure.Services;

namespace Quiz.Data.Infrastructure.UnitOfWork
{
    public abstract class BaseUnitOfWork<T> : IDisposable, IUnitOfWork<T>
        where T : DbContext
    {

        private bool _disposed;

        public T Context { get; protected set; }

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        private void Dispose(bool disposing)
        {
            if (Context != null && !_disposed && disposing)
            {
                Context.Dispose();
            }

            _disposed = true;
        }

        public void Save()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                LoggingService.LogException(ex);
            }
        }

    }
}
